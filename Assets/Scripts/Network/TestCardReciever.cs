using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class TestCardReciever : MonoBehaviour
{

    private int recieveCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //メッセージがあるとき
        if (NetworkManager.networkManager.GetMessage() != null)
        {
            if (recieveCount < 4)
            {
                byte[] recievedData = NetworkManager.networkManager.PopMessage();
                if (recievedData[0] == 24 && recievedData[1] != NetworkManager.playerID)
                {
                    //カード情報の受信処理
                    byte[] imageBinary = recievedData.Skip(9).ToArray();
                    byte[] attackArray = new byte[] { recievedData[3], recievedData[4] };
                    byte[] defenceArray = new byte[] { recievedData[5], recievedData[6] };

                    Texture2D texture = new Texture2D(810, 1080);
                    CardFolder.cardFolder.rivalCard[recieveCount].attack = BitConverter.ToUInt16(attackArray, 0);
                    CardFolder.cardFolder.rivalCard[recieveCount].defence = BitConverter.ToUInt16(defenceArray, 0);
                    CardFolder.cardFolder.rivalCard[recieveCount].speed = recievedData[7];
                    CardFolder.cardFolder.rivalCard[recieveCount].effect = recievedData[8];
                    texture.LoadImage(imageBinary);
                    CardFolder.cardFolder.rivalCard[recieveCount].cardImage = texture;

                    CardTradeConsole.cardTradeConsole.addConsoleText("【受信】"+recieveCount.ToString() + "枚目のカード情報を受信完了");
                }

            }
            else if (recieveCount == 4)
            {
                CardTradeConsole.cardTradeConsole.addConsoleText("全てのカード情報を受信完了");
                NetworkManager.networkManager.isRecieveDone = true;
            }
            recieveCount++;
        }
    }
}