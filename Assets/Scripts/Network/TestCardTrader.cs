using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeWebSocket;
using System.Linq;
using System;


public class TestCardTrader : MonoBehaviour
{
    private int sendCount = 0 ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sendCount < 5)
        {
            //データの変換
            Texture2D image = CardFolder.cardFolder.myCard[sendCount].cardImage;
            byte[] imageBinary = image.EncodeToPNG();
            byte idByte = (byte)CardFolder.cardFolder.myCard[sendCount].id;
            byte[] AttackArray = System.BitConverter.GetBytes((UInt16)CardFolder.cardFolder.myCard[sendCount].attack);
            byte[] DefenceArray = System.BitConverter.GetBytes((UInt16)CardFolder.cardFolder.myCard[sendCount].defence);
            byte speedByte = (byte)CardFolder.cardFolder.myCard[sendCount].speed;
            byte effectByte = (byte)CardFolder.cardFolder.myCard[sendCount].effect;

            byte[] sendData = (new byte[] { 24, NetworkManager.playerID, idByte, AttackArray[0], AttackArray[1], DefenceArray[0], DefenceArray[1], speedByte, effectByte }).Concat(imageBinary).ToArray();

            NetworkManager.networkManager.SendWebSocketMessage(sendData);
            Debug.Log("SendData: " + sendData.Take(9).ToString());
            CardTradeConsole.cardTradeConsole.addConsoleText("【送信】 "+sendCount.ToString() + "枚目のカード情報を送信完了");
        }
        else if (sendCount == 5)
        {
            CardTradeConsole.cardTradeConsole.addConsoleText("全てのカード情報を送信完了");
            NetworkManager.networkManager.isSendDone = true;
        }
    }
    //テスト用 カード情報送信関数
    public void OnPressed()
    {
        Texture2D image = PaintController.paintController.GetTexture();
        byte[] imageBinary = image.GetRawTextureData();
        byte[] sendData = (new byte[] {24, NetworkManager.playerID,0,0,0,0,0 }).Concat(imageBinary).ToArray();
        NetworkManager.networkManager.SendWebSocketMessage(sendData);
        //テスト用 画像送信関数
        /*public void SendImage(Texture2D image)
        {
            NetworkManager.networkManager.SendWebSocketMessage(image.GetRawTextureData());
        }*/
    }
}
