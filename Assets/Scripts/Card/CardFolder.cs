using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //あとで消す
[DefaultExecutionOrder(-4)]
public class CardFolder : MonoBehaviour
{
    public static CardFolder cardFolder;

    public CardData[] myCard = new CardData[5];
    public CardData[] rivalCard = new CardData[5];

    void Awake()
    {
        cardFolder = this;

        //カード情報の初期化
        // myCard = new CardData[5];
        // rivalCard = new CardData[5];
        // myCard = DrawSave.cardDatas;

        for(int i = 0; i < 5; i++){
            Texture2D texture2D = ReadPng($"Assets/Resources/S__29163{i + 55}_0.jpg");
            Debug.Log("kokomadeiketeru");
            var cardParameter = ParamGenerator.paramGenerator.GenerateParams(texture2D);
            myCard[i].id = i + 1;
            myCard[i].attack = cardParameter.attack;
            myCard[i].defence = cardParameter.defense;
            myCard[i].cost = cardParameter.cost;
            myCard[i].speed = cardParameter.speed;
            myCard[i].effect = cardParameter.effect;
            myCard[i].cardImage = texture2D;
        }
        for(int i = 60; i <= 64; i++){
            Texture2D texture2D = ReadPng($"Assets/Resources/S__29163{i}_0.jpg");
            var cardParameter = ParamGenerator.paramGenerator.GenerateParams(texture2D);
            rivalCard[i - 60].id = i - 59;
            rivalCard[i - 60].attack = cardParameter.attack;
            rivalCard[i - 60].defence = cardParameter.defense;
            rivalCard[i - 60].cost = cardParameter.cost;
            rivalCard[i - 60].speed = cardParameter.speed;
            rivalCard[i - 60].effect = cardParameter.effect;
            rivalCard[i - 60].cardImage = texture2D;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string returnMyCardStatusText(int cardNum)
    {
        string cardStatusText = "";
        if (myCard[cardNum] != null)
        {
            cardStatusText = "攻撃力: " + myCard[cardNum].attack + "\n" +
                            "防御力: " + myCard[cardNum].defence + "\n" +
                            "素早さ: " + myCard[cardNum].speed + "\n" +
                            "コスト: " + myCard[cardNum].cost + "\n" +
                            "効果: " + CardEffectsList.cardEffectsList.returnEffectExplain(myCard[cardNum].effect);
        }
        return cardStatusText;
    }

    public string returnRivalCardStatusText(int cardNum)
    {
        string cardStatusText = "";
        if (rivalCard[cardNum] != null)
        {
            cardStatusText = "攻撃力: " + rivalCard[cardNum].attack + "\n" +
                            "防御力: " + rivalCard[cardNum].defence + "\n" +
                            "素早さ: " + rivalCard[cardNum].speed + "\n" +
                            "コスト: " + rivalCard[cardNum].cost + "\n" +
                            "効果: " + CardEffectsList.cardEffectsList.returnEffectExplain(rivalCard[cardNum].effect);
        }
        return cardStatusText;
    }

    //あとで消す
    public Texture2D ReadPng(string path){
        byte[] readBinary = ReadPngFile(path);

        int pos = 16; // 16バイトから開始

        int width = 0;
        for (int i = 0; i < 4; i++){
            width = width * 256 + readBinary[pos++];
        }

        int height = 0;
        for (int i = 0; i < 4; i++){
            height = height * 256 + readBinary[pos++];
        }

        Texture2D texture = new Texture2D(810, 1080);
        texture.LoadImage(readBinary);

        return texture;
    }
    byte[] ReadPngFile(string path){
    FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
    BinaryReader bin = new BinaryReader(fileStream);
    byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);
     
    bin.Close();
     
    return values;
}
}
