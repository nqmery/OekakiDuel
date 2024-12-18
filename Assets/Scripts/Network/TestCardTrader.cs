using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeWebSocket;


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


    //テスト用 画像送信関数
    /*public void SendImage(Texture2D image)
    {
        NetworkManager.networkManager.SendWebSocketMessage(image.GetRawTextureData());
    }*/
}
