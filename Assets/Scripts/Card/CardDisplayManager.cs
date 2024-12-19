using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    // Start is called before the first frame update
    void Start()
    {
        this.cardImage = this.GetComponent<RawImage>();
        if (isMine)
        {
            cardImage.texture = CardFolder.cardFolder.myCard[cardNum].cardImage;
        }
        else
        {
            cardImage.texture = CardFolder.cardFolder.rivalCard[cardNum].cardImage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
