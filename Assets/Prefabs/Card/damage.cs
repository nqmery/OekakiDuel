using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damage : MonoBehaviour
{
    public Slider opponentHpSlider; // 相手のHPゲージ（Slider）
    public int attackDamage = 10;  // カードの攻撃力

    // カードがクリックされたときに呼び出される
    public void OnCardClicked()
    {
        if (opponentHpSlider != null)
        {
            // 現在のHPを減少
            opponentHpSlider.value -= attackDamage;

            // HPが0未満にならないように制御
            if (opponentHpSlider.value <= 0)
            {
                opponentHpSlider.value = 0;
                Debug.Log("相手のHPが0になりました！");
            }
        }
        else
        {
            Debug.LogError("Opponent HP Slider is not assigned!");
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
