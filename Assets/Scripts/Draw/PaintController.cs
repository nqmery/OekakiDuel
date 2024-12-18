using System.Collections;
using System.Collections.Generic;
//using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaintController : MonoBehaviour{
    [SerializeField]
	private RawImage m_image = null;

    private Texture2D m_texture = null;

    public int m_width;
 
    public int m_height;
    public Color paintColor;
 
    private Vector2 m_prePos;
    private Vector2 m_TouchPos;
    
    private float m_clickTime, m_preClickTime;
    private Vector2 m_disImagePos;

	public void OnDrag( BaseEventData arg ){ //線を描画
        PointerEventData _event = arg as PointerEventData; //タッチの情報取得
        
        // 押されているときの処理
        //以下１行修正(2021/11/23)
        m_TouchPos = _event.position - m_disImagePos; //現在のポインタの座標
        // m_TouchPos = _event.position; //現在のポインタの座標
		m_clickTime = _event.clickTime; //最後にクリックイベントが送信された時間を取得

        float disTime = m_clickTime - m_preClickTime; //前回のクリックイベントとの時差

        int width  = m_width;  //ペンの太さ(ピクセル)
        int height = m_height; //ペンの太さ(ピクセル)

        var dir  = m_prePos - m_TouchPos; //直前のタッチ座標との差
        if(disTime > 0.01) dir = new Vector2(0,0); //0.1秒以上間隔があいたらタッチ座標の差を0にする

        var dist = (int)dir.magnitude; //タッチ座標ベクトルの絶対値

        dir = dir.normalized; //正規化
        
        //指定のペンの太さ(ピクセル)で、前回のタッチ座標から今回のタッチ座標まで塗りつぶす
        for(int d = 0; d < dist; ++d){
            var p_pos = m_TouchPos + dir * d; //paint position
            p_pos.y -= height/2.0f;
            p_pos.x -= width/2.0f;
            for ( int h = 0; h < height; ++h ){
                int y = (int)(p_pos.y + h);
                if ( y < 0 || y > m_texture.height ) {
                    continue;
                    } //タッチ座標がテクスチャの外の場合、描画処理を行わない

                for ( int w = 0; w < width; ++w ){
                    int x = (int)(p_pos.x + w);
                    if ( x >= 0 && x <= m_texture.width ){
                        m_texture.SetPixel( x, y, paintColor ); //線を描画
                    }
                }
            }
        }
        m_texture.Apply();
        m_prePos = m_TouchPos;
        m_preClickTime = m_clickTime;

        //テスト用
        //parameter表示
        ParamGenerator.paramGenerator.DebugLog(m_texture);
        //送信
        NetworkManager.networkManager.SendWebSocketMessage(m_texture.GetRawTextureData());
    }

    public void OnTap( BaseEventData arg ){ //点を描画
        PointerEventData _event = arg as PointerEventData; //タッチの情報取得
        
        // 押されているときの処理
        m_TouchPos = _event.position - m_disImagePos; //現在のポインタの座標
		// m_TouchPos = _event.position; //現在のポインタの座標

        int width  = m_width;  //ペンの太さ(ピクセル)
        int height = m_height; //ペンの太さ(ピクセル)

        var p_pos = m_TouchPos; //paint position
        p_pos.y -= height/2.0f;
        p_pos.x -= width/2.0f;

        for ( int h = 0; h < height; ++h ){
            int y = (int)(p_pos.y + h);
            if ( y < 0 || y > m_texture.height ){
                continue; //タッチ座標がテクスチャの外の場合、描画処理を行わない
            }
            for ( int w = 0; w < width; ++w ){
                int x = (int)(p_pos.x + w);
                if ( x >= 0 && x <= m_texture.width ){
                    m_texture.SetPixel( x, y, paintColor ); //点を描画
                }
            }
        }       
        m_texture.Apply();

        //テスト用
        //parameter表示
        ParamGenerator.paramGenerator.DebugLog(m_texture);
        //送信
        NetworkManager.networkManager.SendWebSocketMessage(m_texture.GetRawTextureData());

    }

    private void Start (){
        paintColor = Color.black;
        var rect = m_image.gameObject.GetComponent<RectTransform>().rect;
        m_texture = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGBA32, false);

        //下の行追加（2021/10/21）
        WhiteTexture((int)rect.width, (int)rect.height);

        m_image.texture = m_texture;
        // //以下追加(2021/11/23)
        // //ペイントエリアの指定
        var m_imagePos = m_image.gameObject.GetComponent<RectTransform>().anchoredPosition;
        m_disImagePos = new Vector2(m_imagePos.x - rect.width/2, m_imagePos.y - rect.height/2);

        
        //テスト用 画像がサーバーから来たら即時反映
        if (NetworkManager.networkManager != null)
        {
            // メッセージ受信時に HandleMessage を実行
            NetworkManager.networkManager.OnMessageReceived += WriteTexture;
            Debug.Log("Received");
        }
    }

    //下の関数を追加（2021/10/21）
    //テクスチャを白色にする関数
    private void WhiteTexture(int width, int height){
        for(int w = 0; w < width; w++){
            for (int h = 0; h < height; h++){
                m_texture.SetPixel(w, h, Color.white);
            }
        }
        m_texture.Apply();
    }

    //テスト用
    //画像がサーバーから来たら即時反映
    private void WriteTexture(byte[] bytes)
    {
        Debug.Log("Data: " + System.Text.Encoding.ASCII.GetString(bytes));
        m_texture.LoadRawTextureData(bytes);
        m_texture.Apply();

    }

}
