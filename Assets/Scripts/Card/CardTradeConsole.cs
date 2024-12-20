using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTradeConsole : MonoBehaviour
{
    public static CardTradeConsole cardTradeConsole;

    public string consoleText = "画像の交換を開始";
    Text textContent;
    // Start is called before the first frame update
    private void Awake()
    {
        cardTradeConsole = this;
    }
    void Start()
    {
        this.textContent = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        this.textContent.text = consoleText;
    }

    public void addConsoleText(string text)
    {
        consoleText += text;
        consoleText += "\n";
    }
}
