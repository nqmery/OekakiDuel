using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFolder : MonoBehaviour
{
    public static CardFolder cardFolder;

    public CardData[] myCard = new CardData[5];
    public CardData[] rivalCard = new CardData[5];

    void Awake()
    {
        if (cardFolder == null)
        {
            cardFolder = this;
            DontDestroyOnLoad(gameObject); // シーン遷移時に破棄されないように設定
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //カード情報の初期化
        myCard = new CardData[5];
        rivalCard = new CardData[5];
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
}
