using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawNetwork : MonoBehaviour
{
    private void Start()
    {
        // メッセージ受信時の処理を登録
        NetworkManager.networkManager.OnMessageReceived += HandleMessage;

    }

    private void OnDestroy()
    {
        // シーン遷移やオブジェクト破棄時にイベント解除
        if (NetworkManager.networkManager != null)
        {
            NetworkManager.networkManager.OnMessageReceived -= HandleMessage;
        }
    }

    private void HandleMessage(byte[] message)
    {
        Debug.Log($"GameScene received message: {BitConverter.ToString(message)}");

        // メッセージ内容に応じた処理
        if (message.Length > 0)
        {
            byte signal = message[0];
            
        }
    }
}
