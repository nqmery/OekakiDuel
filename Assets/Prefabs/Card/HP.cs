using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    //最大HPと現在のHP。
   　public int maxHp = 155;
     private int currentHp;
    //Sliderを入れる
    public Slider opponentHpSlider;

    // Start is called before the first frame update
    void Start()
    {
        //Sliderを満タンにする。
        opponentHpSlider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }

    // HPを減少させるメソッド
    public void ReduceHp(int damage)
    {
        // ダメージ分HPを減少
        currentHp -= damage;

        // HPが0未満にならないように制御
        if (currentHp < 0)
        {
            currentHp = 0;
        }

        // Sliderの値を更新
        opponentHpSlider.value = currentHp;

        Debug.Log("Current HP after damage: " + currentHp);
    }
// Update is called once per frame
void Update()
    {
        
    }
}


