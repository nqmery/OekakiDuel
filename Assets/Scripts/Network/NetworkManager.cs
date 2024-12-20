using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeWebSocket;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;



public class NetworkManager : MonoBehaviour
{
    public static NetworkManager networkManager;
    WebSocket websocket = null;

    // メッセージ受信時のイベント
    public event Action<byte[]> OnMessageReceived;

    //通信内容を保持するリスト
    [SerializeField]
    private List<byte[]> messageList = new List<byte[]>();

    //プレイヤー番号を保持する変数
    public static byte playerID = 0; //仮で0に設定

    public Text statusText; // ステータスメッセージ
    private void Awake()
    {
        if (networkManager == null)
        {
            networkManager = this;
            DontDestroyOnLoad(gameObject); // シーン遷移時に破棄されないように設定
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    /// カード交換用
    public bool isSendDone = false;
    public bool isRecieveDone = false;

    public async void GameStart()
    {
        Button startbutton = GameObject.Find("StartButton").GetComponent<Button>();
        startbutton.gameObject.SetActive(false);

        networkManager = this;
        websocket = new WebSocket("ws://localhost:3000");

        websocket.OnMessage += (bytes) =>
        {
            // メッセージをデコード
            //string message = System.Text.Encoding.UTF8.GetString(bytes);
            //Debug.Log("Message received: " + bytes.ToString());

            // バイト配列を適切に表示
            string receivedData = BitConverter.ToString(bytes);
            Debug.Log($"Message received: {receivedData}");

            // 必要ならバイト配列をデコード（例: テキストの場合）
            //string decodedMessage = System.Text.Encoding.UTF8.GetString(bytes);
            //Debug.Log($"Decoded message: {decodedMessage}");

            // メッセージをリストに追加
            messageList.Add(bytes);


            // イベントを発火して通知
            OnMessageReceived?.Invoke(bytes);

            
        };

        await websocket.Connect();
    }

    void Update()
    {


        if (GetMessage() != null)
        {
            if (GetMessage()[0] == 10) //通信種別が10のとき
            {
                playerID = PopMessage()[1];
                Debug.Log("Player ID received: " + playerID);
                statusText.text = "対戦相手を待っています...";
            }
            else if (GetMessage()[0] == 0x10) // 0x10がゲーム開始シグナル
            {
                PopMessage();
                Debug.Log("Game start signal received. Loading next scene...");
                SceneManager.LoadScene("DrawScene");
            }
        }

        //カード交換が終わったらバトルシーンへ遷移
        if (isSendDone && isRecieveDone)
        {
            CardTradeConsole.cardTradeConsole.addConsoleText("カード交換が完了しました");
            SceneManager.LoadScene("BattleScene");
        }

#if !UNITY_WEBGL || UNITY_EDITOR
        websocket?.DispatchMessageQueue();
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
    public async void DisConnectWebsocket()
    {
        if (websocket != null)
        {
            await websocket.Close();
        }
    }

    public async void chuudanWebsocket()
    {
        if (websocket != null)
        {
            await websocket.Close();
        }
        Destroy(gameObject);
        SceneManager.LoadSceneAsync("TitleScene");
    }

}
