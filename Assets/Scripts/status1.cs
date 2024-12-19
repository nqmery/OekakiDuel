using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class status1 : MonoBehaviour
{
    public int attack = 0;
    public int defense = 0;
    public int cost = 0;
    Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        // ランダム値を設定
        attack = Random.Range(10, 101);  // 10から100の範囲でランダム値を生成
        defense = Random.Range(5, 51);  // 5から50の範囲でランダム値を生成
        cost = Random.Range(1, 21);     // 1から20の範囲でランダム値を生成

        // テキストコンポーネントを取得
        this.textComponent = GameObject.Find("Text").GetComponent<Text>();

        // テキストを更新
        UpdateStatusText();
    }
    // ステータスのテキストを更新するメソッド
    　public void UpdateStatusText()
    {
        this.textComponent.text =
            "Attack: " + attack.ToString() + "\n" +
            "Defense: " + defense.ToString() + "\n" +
            "Cost: " + cost.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
