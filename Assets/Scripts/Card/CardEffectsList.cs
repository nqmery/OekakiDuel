using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectsList : MonoBehaviour
{
    public static CardEffectsList cardEffectsList;
    // Start is called before the first frame update
    void Start()
    {
        cardEffectsList = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string returnEffectExplain(int effectNum)
    {
        switch (effectNum)
        {
            case 10:
                return "先制攻撃";

            case 11:
                return "相手の攻撃無効化";

            case 12:
                return "ターン開始時に体力全回復";

            case 13:
                return "ターン終了時に両者全回復";

            case 14:
                return "相手の防御力が云々";

            case 15:
                return "相手の素早さを下げる";

            case 16:
                return "両者の攻撃無効化";

            default:
                return "存在しない効果ID: " + effectNum.ToString();

        }
    }
}
