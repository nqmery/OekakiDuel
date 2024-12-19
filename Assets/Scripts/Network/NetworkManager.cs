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

    //通信内容を保持するリスト
    private List<byte[]> messageList = new List<byte[]>();

    //プレイヤー番号を保持する変数
    public static byte playerID = 0; //仮で0に設定

    async void Awake()
    {
        networkManager = this;
        websocket = new WebSocket("ws://localhost:3000");

        websocket.OnMessage += (bytes) =>
        {
            // メッセージをデコード
            //string message = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log("Message received: " + bytes.ToString());

            // メッセージをリストに追加
            messageList.Add(bytes);


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

    //====== messageList関連 ========
    // メッセージリストの先頭を読むだけ 空の場合はnullを返す
    public byte[] GetMessage()
    {
        if (messageList.Count == 0)
        {
            return null;
        }
        byte[] message = messageList[0];

        return message;
    }

    //メッセージリストの先頭を読み、削除して詰める 空の場合はnullを返す
    public byte[] PopMessage()
    {
        if (messageList.Count == 0)
        {
            return null;
        }
        byte[] message = messageList[0];
        messageList.RemoveAt(0);
        return message;
    }

}
