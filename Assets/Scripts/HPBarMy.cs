using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPBarMy : MonoBehaviour
{
    public Slider HPbarme;
    // Start is called before the first frame update
    void Start()
    {
        HPbarme = GameObject.Find("HPbarme").GetComponent<Slider>();
        HPbarme.maxValue = BattleManager.battleManager.myHP;
        HPbarme.value = BattleManager.battleManager.myHP;
    }

    // Update is called once per frame
    void Update()
    {
        HPbarme.value = BattleManager.battleManager.myHP;
    }
}
