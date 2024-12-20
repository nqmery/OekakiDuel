using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSetsumei : MonoBehaviour
{

    [SerializeField]
    bool isMine;

    Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        this.textComponent = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMine) { this.textComponent.text = BattleManager.cardEffectExplainMe; }
        else { this.textComponent.text = BattleManager.cardEffectExplainRival; }
    }
    
}
