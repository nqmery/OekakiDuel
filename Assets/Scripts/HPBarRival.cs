using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarRival : MonoBehaviour
{
    public Slider HPbar;
    // Start is called before the first frame update
    void Start()
    {
        HPbar = GameObject.Find("HPbar").GetComponent<Slider>();
        HPbar.maxValue = BattleManager.battleManager.rivalHP;
        HPbar.value = BattleManager.battleManager.rivalHP;
    }

    // Update is called once per frame
    void Update()
    {
        HPbar.value = BattleManager.battleManager.rivalHP;
    }
}
