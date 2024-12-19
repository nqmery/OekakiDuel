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
        cardFolder = this;

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

}
