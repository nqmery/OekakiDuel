using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusText : MonoBehaviour
{
    public TextMeshProUGUI attackText; // 攻撃力を表示するText
    public TextMeshProUGUI defenseText; // 防御力を表示するText
    public TextMeshProUGUI costText; // コストを表示するText

    private int attack = 50; // 攻撃力
    private int defense = 30; // 防御力
    private int cost = 2; // コスト

    // Start is called before the first frame update
    void Start()
    { // ステータスをUIに反映
        attackText.text = "Attack: " + attack;
        defenseText.text = "Defense: " + defense;
        costText.text = "Cost: " + cost;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
