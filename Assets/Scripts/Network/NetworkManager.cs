using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeWebSocket;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager networkManager;
    WebSocket websocket = null;

    // メッセージ受信時のイベント
    public event Action<byte[]> OnMessageReceived;

    async void Awake()
    {
        networkManager = this;
        websocket = new WebSocket("ws://localhost:3000");

        websocket.OnMessage += (bytes) =>
        {
            // メッセージをデコード
            //string message = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log("Message received: " + bytes.ToString());

            // イベントを発火して通知
            OnMessageReceived?.Invoke(bytes);
        };

        await websocket.Connect();
    }

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();
#endif
    }

    private async void OnApplicationQuit()
    {
        if (websocket != null)
        {
            await websocket.Close();
        }
    }
    public async void SendWebSocketMessage(byte[] message)
    {
        if (websocket.State == WebSocketState.Open)
        {
            // Sending bytes
            await websocket.Send(message);

        }
    }

}
