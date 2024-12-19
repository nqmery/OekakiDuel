using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM3 : MonoBehaviour
{
    Slider HPbarme;
    public int HP = 150;
    public bool Attackob_flag = false;

    // Start is called before the first frame update
    void Start()
    {
        HPbarme = GameObject.Find("HPbarme").GetComponent<Slider>();
        HPbarme.maxValue = HP;
        HPbarme.value = HP;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Attackob()
    {
        if (HPbarme.value > 0) // HPが残っている場合
        {
            HPbarme.value -= 10; // HPを10減少
        }
        else
        {
            Debug.Log("HPはもうありません！");
        }
    }
}
