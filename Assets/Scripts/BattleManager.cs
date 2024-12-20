using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager battleManager;

    //設定
    const UInt16 DefaultHP = 10000;
    const UInt16 DefaultCost = 100;
    const UInt16 DefaultCostHeal = 50;

    public enum GameState
    {
        BeforeGame, //ゲーム開始前
        CardSelect, //カード選択
        WaitingSelect, //相手のカード選択待ち
        TurnProcessing, //ターン処理中
        TurnEnd, //ターン終了
        End, //ゲーム終了
        none //なし
    }
    [SerializeField]
    public static GameState gameState = GameState.CardSelect;

    private int turnCount = 0; //ターン数

    public int myHP; //体力
    public int cost; //コスト
    public int costHeal; //コスト効果
    public int rivalHP; //相手の体力


    //選択したカードのインスタンス
    //自分のカード
    private CardData myCardSelected = null;
    //相手のカード
    private CardData rivalCardSelected = null;


    public static string cardEffectExplainMe = "";
    public static string cardEffectExplainRival = "";

    // Start is called before the first frame update
    void Awake()
    {
        battleManager = this;
    }
    void Start()
    {
        myCardSelected = null;
        rivalCardSelected = null;

        myHP = DefaultHP; 
        cost = DefaultCost; 
        costHeal  = DefaultCostHeal; 
        rivalHP = DefaultHP; 
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.BeforeGame:
                break;
            case GameState.CardSelect:
                //カードを選ぶ処理
                break;
            case GameState.WaitingSelect:
                //自分の選択したカードを表示
                break;
            case GameState.TurnProcessing:
                //自分と相手の選択したカードを表示
                break;
            case GameState.TurnEnd:
                break;
            case GameState.End:
                break;
            case GameState.none:
                break;
        }
    }

    //GameStateを変更するメソッド
    public void ChangeGameState(GameState state)
    {
        gameState = state;
        if(state == GameState.TurnEnd)
        {
            //コスト回復
            cost += costHeal;
        }
    }
    public void CostHealEffect(int value)
    {
        if (value == 0)
        {
            costHeal *= 2;
        }
        else
        {
            costHeal += value;
        }
    }

    //ターン数を変更するメソッド(BattleNetworkManagerから呼び出し,GameStateをCardSelectに, 選択カードオブジェクトを初期化)
    public void ChangeTurnCount(int count)
    {
        turnCount = count;
        ChangeGameState(GameState.CardSelect);
        //選択したカードを初期化
        SelectedCardManagerME.selectedCardManagerME.DisableImage();
        SelectedCardManagerRival.selectedCardManagerRival.DisableImage();
        myCardSelected = null;
        rivalCardSelected = null;
        //カードの説明を初期化
        cardEffectExplainMe = "";
        cardEffectExplainRival = "";
        Debug.Log("TurnCount: " + turnCount);
    }


    public void OnClickCard(int cardNum)
    {
        //カードのコストが足りない時メッセージを出す
        if (cost < CardFolder.cardFolder.myCard[cardNum].cost)
        {
            Debug.Log("コストが足りません");
            return;
        }
        else
        {
            //カードの選択完了
            myCardSelected = CardFolder.cardFolder.myCard[cardNum];
            //選択したカードを使用済みにする
            CardFolder.cardFolder.myCard[cardNum].isUsed = true;



            //カード選択完了信号を送信
            byte[] sendData = (new byte[] { 36, 0, NetworkManager.playerID, (byte)myCardSelected.id }).ToArray();
            NetworkManager.networkManager.SendWebSocketMessage(sendData);

            //GameStateをWaitingSelectに変更
            ChangeGameState(GameState.WaitingSelect);
            //相手のカードが選択済みのとき
            if (rivalCardSelected != null)
            {
                ChangeGameState(GameState.TurnProcessing);
            }

            Debug.Log("CardSelected: " + myCardSelected.id);
        }
    }

    public void SetRivalCard(int cardNum)
    {
        rivalCardSelected = CardFolder.cardFolder.rivalCard[cardNum];
        Debug.Log("RivalCardSelected: " + rivalCardSelected.id);

        //選択したカードを使用済みに
        CardFolder.cardFolder.rivalCard[cardNum].isUsed = true;

        //GameStateがWaitingSelectのとき、GameStateをTurnProcessingに変更
        if (gameState == GameState.WaitingSelect)
        {
            ChangeGameState(GameState.TurnProcessing);
            SelectedCardManagerME.selectedCardManagerME.SetCardImage(myCardSelected.cardImage);
            SelectedCardManagerRival.selectedCardManagerRival.SetCardImage(rivalCardSelected.cardImage);
        }
    }

    public void TurnProcess(byte[] recievedData)
    {
        Debug.Log(CardEffectsList.cardEffectsList.returnEffectExplain(recievedData[4]));
        //効果番号で分岐
        switch (recievedData[4])
        {
            case 1: //通常攻撃
                break;
            case 10: //先制攻撃
                break;
            case 11: //相手の攻撃無効化
                break;
            case 12: //ターン開始時に体力全回復
                break;
            case 13: //ターン終了時に両者全回復
                break;
            case 14: //相手の防御力が云々
                break;
            case 15: //相手の素早さを下げる
                break;
            case 16: //両者の攻撃無効化
                break;

            default:
                break;

        }

        //体力の更新
        //
        byte[] Player0Health = new byte[] { recievedData[7], recievedData[8] };
        byte[] Player1Health = new byte[] { recievedData[9], recievedData[10] };
        if (NetworkManager.playerID == 0)
        {
            myHP = BitConverter.ToUInt16(Player0Health, 0);
            rivalHP = BitConverter.ToUInt16(Player1Health, 0);
        }
        else
        {
            myHP = BitConverter.ToUInt16(Player1Health, 0);
            rivalHP = BitConverter.ToUInt16(Player0Health, 0);
        }

    }
    public async void GameEnd(byte winner)
    {
        gameState = GameState.End;
        switch (winner)
        {
            case 0:
                Debug.Log("You Win!");
                break;
            case 1:
                Debug.Log("You Lose...");
                break;
            case 2:
                Debug.Log("Hikiwake");
                break;
            default:
                Debug.Log("不正な値:" + winner);
                break;
        }
        await System.Threading.Tasks.Task.Delay(3000);
        //ゲーム終了後の処理
        Destroy(CardFolder.cardFolder.gameObject);
        Destroy(NetworkManager.networkManager.gameObject);
        SceneManager.LoadSceneAsync("Title");
    }
}
