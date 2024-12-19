using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GM1 : MonoBehaviour
{
    public TextMeshProUGUI WinText; // 勝利結果を表示するUIテキスト
    private GM2 gm2; // GM2スクリプトへの参照
    private GM3 gm3; // GM3スクリプトへの参照

    // Start is called before the first frame update
    void Start()
    {

        // GM2スクリプトの参照を取得
        gm2 = GameObject.Find("HPbar").GetComponent<GM2>();


        // GM3スクリプトの参照を取得
        gm3 = GameObject.Find("HPbarme").GetComponent<GM3>();


        // WinText初期化
        WinText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // 勝利条件を監視する
        CheckWinCondition();
    }
    void CheckWinCondition()
    {
        if (gm2.HPbar.value <= 0 && gm3.HPbarme.value > 0)
        {
            WinText.text = "Player 2 Wins!";
        }
        else if (gm3.HPbarme.value <= 0 && gm2.HPbar.value > 0)
        {
            WinText.text = "Player 1 Wins!";
        }
        else if (gm2.HPbar.value <= 0 && gm3.HPbarme.value <= 0)
        {
            WinText.text = "It's a Draw!";
        }
    }
}
