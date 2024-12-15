using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusText : MonoBehaviour
{
    public TextMeshProUGUI attackText; // �U���͂�\������Text
    public TextMeshProUGUI defenseText; // �h��͂�\������Text
    public TextMeshProUGUI costText; // �R�X�g��\������Text

    private int attack = 50; // �U����
    private int defense = 30; // �h���
    private int cost = 2; // �R�X�g

    // Start is called before the first frame update
    void Start()
    { // �X�e�[�^�X��UI�ɔ��f
        attackText.text = "Attack: " + attack;
        defenseText.text = "Defense: " + defense;
        costText.text = "Cost: " + cost;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
