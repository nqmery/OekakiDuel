using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeWebSocket;
using System.Linq;


public class TestCardTrader : MonoBehaviour
{
    public static TestCardTrader testCardTrader = null;

    // Start is called before the first frame update
    void Start()
    {
        testCardTrader = this;

    }

    // Update is called once per frame
    void Update()
    {

    }
    //テスト用 カード情報送信関数
    public void OnPressed()
    {
        Texture2D image = PaintController.paintController.GetTexture();
        byte[] imageBinary = image.GetRawTextureData();
        byte[] sendData = (new byte[] {24, NetworkManager.playerID,0,0,0,0,0,0,0 }).Concat(imageBinary).ToArray();
        NetworkManager.networkManager.SendWebSocketMessage(sendData);
        //テスト用 画像送信関数
        /*public void SendImage(Texture2D image)
        {
            NetworkManager.networkManager.SendWebSocketMessage(image.GetRawTextureData());
        }*/
    }
}
