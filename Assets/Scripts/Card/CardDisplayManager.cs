using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDisplayManager : MonoBehaviour
{
    //カードの画像
    [SerializeField]
    private RawImage cardImage;

    //自分のカードかどうか
    [SerializeField]
    bool isMine;

    //カード番号
    [SerializeField]
    int cardNum;

    [SerializeField]
    bool Test;

    // Start is called before the first frame update
    void Start()
    {
        // this.cardImage = this.GetComponent<RawImage>();
        if (isMine)
        {
            var rect = cardImage.gameObject.GetComponent<RectTransform>().rect;
            Texture2D texture = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGBA32, false);
            texture = CardFolder.cardFolder.myCard[cardNum].cardImage;
            cardImage.texture = texture;
        }
        else
        {
            var rect = cardImage.gameObject.GetComponent<RectTransform>().rect;
            Texture2D texture = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGBA32, false);
            cardImage.texture = CardFolder.cardFolder.rivalCard[cardNum].cardImage;
            cardImage.texture = texture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //使用済みのカードは非表示
        if (CardFolder.cardFolder.myCard[cardNum].isUsed)
        { this.gameObject.SetActive(false); }
    }


    //自分のカード選択
    public void OnClickMyCard()
    {
        if (BattleManager.gameState == BattleManager.GameState.CardSelect)
        {
            BattleManager.battleManager.OnClickCard(cardNum);
        }
        Debug.Log("自分のカード選択" + cardNum.ToString());
        Test = true;
    }

    //文字表示

    public void CardExplainTextMe(int Num) {
        BattleManager.cardEffectExplainMe = "ATK: " + CardFolder.cardFolder.myCard[Num].attack.ToString()
                                                    + "\nDEF: " + CardFolder.cardFolder.myCard[Num].defence.ToString()
                                                    + "\nSPD: " + CardFolder.cardFolder.myCard[Num].speed.ToString()
                                                    + CardEffectsList.cardEffectsList.returnEffectExplain(CardFolder.cardFolder.myCard[Num].effect);
        //

    }
    public void CardExplainTextRival(int Num)
    {
        BattleManager.cardEffectExplainRival = "ATK: " + CardFolder.cardFolder.rivalCard[Num].attack.ToString()
                                                    + "\nDEF: " + CardFolder.cardFolder.rivalCard[Num].defence.ToString()
                                                    + "\nSPD: " + CardFolder.cardFolder.rivalCard[Num].speed.ToString()
                                                    + CardEffectsList.cardEffectsList.returnEffectExplain(CardFolder.cardFolder.rivalCard[Num].effect);
    }

    public void OnPointerEnter() { 
        if (BattleManager.gameState == BattleManager.GameState.CardSelect)
        {
            CardExplainTextMe(cardNum);
        }
        Debug.Log("文字表示" + cardNum.ToString());
    }

    public void OnPoiterExit()
    {
        if (BattleManager.gameState == BattleManager.GameState.CardSelect)
        {
            BattleManager.cardEffectExplainMe = "";
        }
        Debug.Log("文字非表示" + cardNum.ToString());
    }
}
