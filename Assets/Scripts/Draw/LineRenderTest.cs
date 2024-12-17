using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LineRenderTest : MonoBehaviour{
    [SerializeField] Material lineMaterial;
    [SerializeField] Color lineColor;
    [Range(0.1f, 0.5f)]
    [SerializeField] float lineWidth;
    
    //追加　LineRdenerer型のリスト宣言
    List<LineRenderer> lineRenderers;
    
    void Start(){
        //追加　Listの初期化
        lineRenderers = new List<LineRenderer>();
    }
    void Update(){
        //追加 クリックをしたタイミング
       if (Input.GetMouseButtonDown(0)){
            //lineObjを生成し、初期化する
            _addLineObject();
        }
        
        //追加　クリック中（ストローク中）
        if (Input.GetMouseButton(0)){
            _addPositionDataToLineRendererList();
        }
    }

    //追加　クリックしたら発動
    void _addLineObject(){
        //空のゲームオブジェクト作成
        GameObject lineObj = new GameObject();
        //オブジェクトの名前をStrokeに変更
        lineObj.name = "Stroke";
        //lineObjにLineRendereコンポーネント追加
        lineObj.AddComponent<LineRenderer>();
        //lineRendererリストにlineObjを追加
        lineRenderers.Add(lineObj.GetComponent<LineRenderer>());
        //lineObjを自身の子要素に設定
        lineObj.transform.SetParent(transform);
        //lineObj初期化処理
        _initRenderers();
    }

    //lineObj初期化処理
    void _initRenderers(){
        //線をつなぐ点を0に初期化
        lineRenderers.Last().positionCount = 0;
        //マテリアルを初期化
        lineRenderers.Last().material = lineMaterial;
        //色の初期化
        lineRenderers.Last().material.color = lineColor;
        //太さの初期化
        lineRenderers.Last().startWidth = lineWidth;
        lineRenderers.Last().endWidth = lineWidth;
    }
    
    void _addPositionDataToLineRendererList(){
        //マウスポインタがあるスクリーン座標を取得
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f );
        
        //スクリーン座標をワールド座標に変換
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint( mousePosition);
        
        //ワールド座標をローカル座標に変換
        Vector3 localPosition = transform.InverseTransformPoint(worldPosition.x, worldPosition.y, -1.0f);
        
        //lineRenderersの最後のlineObjのローカルポジションを上記のローカルポジションに設定
        lineRenderers.Last().transform.localPosition = localPosition;
        
        //lineObjの線と線をつなぐ点の数を更新
        lineRenderers.Last().positionCount += 1;
        
        //LineRendererコンポーネントリストを更新
        lineRenderers.Last().SetPosition(lineRenderers.Last().positionCount - 1, worldPosition);
        
        //あとから描いた線が上に来るように調整
        lineRenderers.Last().sortingOrder = lineRenderers.Count;
    }
}
