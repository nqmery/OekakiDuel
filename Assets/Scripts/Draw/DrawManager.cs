using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class DrawManager : MonoBehaviour{
    [SerializeField]
    private int maxTime;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Image timeFillImage;
    [SerializeField]
    private RawImage rawImage;
    [SerializeField]
    private PaintController paintController;
    [SerializeField]
    private DrawSave drawSave;
    [SerializeField]
    private Text nowDrawNumberText;
    [SerializeField]
    private Text startText;
    [SerializeField]
    private Texture2D texture2D1;
    private int nowCardDrawNumber;
    private float time;
    public static bool canDraw;
    // Start is called before the first frame update
    void Start(){
        if(maxTime == 0){ //0除算対策
            maxTime = 1;
        }
        nowCardDrawNumber = 0;
        time = 0f;
        timeFillImage.color = Color.green;
        canDraw = false;
        nowDrawNumberText.text = $"{nowCardDrawNumber + 1}枚目";
        startText.text = "Ready?";
        Invoke("canDrawTrue", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canDraw)
        {
            time += Time.deltaTime;
            if (maxTime - time >= 0)
            {
                slider.value = (maxTime - time) / maxTime;
                if ((maxTime - time) / maxTime < 0.3)
                {
                    timeFillImage.color = Color.red;
                }
            }
            if (maxTime - time <= 0)
            {
                canDraw = false;
                // Texture2D texture2D = (Texture2D)rawImage[nowCardDrawNumber].texture;
                var rect = rawImage.gameObject.GetComponent<RectTransform>().rect;
                drawSave.CardSave((Texture2D)rawImage.texture, nowCardDrawNumber);
                texture2D1 = DrawSave.cardDatas[0].cardImage;
                paintController.WhiteTexture((int)rect.width, (int)rect.height);
                if (nowCardDrawNumber < 4)
                {
                    startText.enabled = true;
                    nowCardDrawNumber++;
                    nowDrawNumberText.text = $"{nowCardDrawNumber + 1}枚目";
                    startText.text = "Ready?";
                    Invoke("canDrawTrue", 2f);
                }
                else if (nowCardDrawNumber == 4)
                {
                    SceneManager.LoadScene("TradeCard");
                }
            }
        }
    }
    public void canDrawTrue(){
        canDraw = true;
        time = 0f;
        timeFillImage.color = Color.green;
        startText.text = "Go";
        Invoke("TextEnableFalse", 1f);
    }
    void TextEnableFalse(){
        startText.enabled = false;
    }
}
