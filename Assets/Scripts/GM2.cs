using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM2 : MonoBehaviour
{
    Slider HPbar;
    public int HP =150;
    public bool Attack_flag=false;

    // Start is called before the first frame update
    void Start()
    {
        HPbar=GameObject.Find("HPbar").GetComponent<Slider>();
        HPbar.maxValue = HP;
        HPbar.value = HP;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void Attack()
    {
    if (HPbar.value > 0) // HPが残っている場合
        {
            HPbar.value -= 10; // HPを10減少
        }
        else
        {
            Debug.Log("HPはもうありません！");
        }
    }
}
