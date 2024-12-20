using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSave : MonoBehaviour
{
    //public static CardData[] cardDatas = new CardData[5];
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*public void CardSave(Texture2D texture2D, int cardNumber){
        CardData cardData = new CardData();
        // Debug.Log("CardSave起動");
        var cardParameter = ParamGenerator.paramGenerator.GenerateParams(texture2D);
        cardData.id = cardNumber + 1;
        cardData.attack = cardParameter.attack;
        cardData.defence = cardParameter.defense;
        cardData.cost = cardParameter.cost;
        cardData.speed = cardParameter.speed;
        cardData.effect = cardParameter.effect;
        cardData.cardImage = texture2D;
        // Debug.Log("記入完了");
        cardDatas[cardNumber] = cardData;
        // Debug.Log(cardDatas[cardNumber].attack);
        ParamGenerator.paramGenerator.DebugLog(texture2D);
        
    }*/

    //CardFolderに保存
    public void CardSave(Texture2D texture2D, int cardNumber)
    {
        
        // Debug.Log("CardSave起動");
        var cardParameter = ParamGenerator.paramGenerator.GenerateParams(texture2D);
        CardFolder.cardFolder.myCard[cardNumber].id = cardNumber;
        CardFolder.cardFolder.myCard[cardNumber].attack = cardParameter.attack;
        CardFolder.cardFolder.myCard[cardNumber].defence = cardParameter.defense;
        CardFolder.cardFolder.myCard[cardNumber].cost = cardParameter.cost;
        CardFolder.cardFolder.myCard[cardNumber].speed = cardParameter.speed;
        CardFolder.cardFolder.myCard[cardNumber].effect = cardParameter.effect;
        CardFolder.cardFolder.myCard[cardNumber].cardImage = texture2D;
        // Debug.Log("記入完了");
        //cardDatas[cardNumber] = cardData;
        // Debug.Log(cardDatas[cardNumber].attack);
        ParamGenerator.paramGenerator.DebugLog(texture2D);
    }
}