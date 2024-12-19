using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public class BattleNetworkManager : MonoBehaviour
{
    public static BattleNetworkManager battleNetworkManager;
    void Awake()
    {
        battleNetworkManager = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    async void Update()
    {
        if (NetworkManager.networkManager.GetMessage() != null)
        {
            byte signalType = NetworkManager.networkManager.GetMessage()[0];
            switch (signalType)
            {
                case 30:
                    //ターン開始信号の受信
                    //await Task.Delay(3000);
                    //ターンの処理が終了してから実行
                    if(BattleManager.gameState == BattleManager.GameState.TurnEnd)
                    {
                        BattleManager.battleManager.ChangeTurnCount(NetworkManager.networkManager.PopMessage()[2]);
                    }
                    break;

                case 31:
                    //自分がカードを選択してから実行
                    if (BattleManager.gameState == BattleManager.GameState.WaitingSelect)
                    {
                        //来たカードが相手のカードの時、相手のカードを取得
                        if (NetworkManager.networkManager.GetMessage()[1] != NetworkManager.playerID)
                        {
                            BattleManager.battleManager.SetRivalCard(NetworkManager.networkManager.PopMessage()[2]);
                        }
                    }
                    break;

                case 32:
                    BattleManager.battleManager.TurnProcess(NetworkManager.networkManager.PopMessage());
                    await Task.Delay(3000);
                    break;

                case 33:
                    break;

                default:
                    break;
            }
        }


    }
}
