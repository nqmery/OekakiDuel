using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class costView : MonoBehaviour
{
    Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        this.textComponent = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        this.textComponent.text = "Cost: " + BattleManager.battleManager.cost;
    }
}
