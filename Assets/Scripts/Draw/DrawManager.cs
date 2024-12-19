using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private PaintAll paintAll;
    private int nowCardDrawNumber;
    private float time;
    private bool bbbbbb;
    // Start is called before the first frame update
    void Start(){
        if(maxTime == 0){ //0除算対策
            maxTime = 1;
        }
        nowCardDrawNumber = 0;
        time = 0f;
        bbbbbb = false;
    }

    // Update is called once per frame
    void Update(){
        if(bbbbbb){
            time += Time.deltaTime;
            if(maxTime - time >= 0){
                slider.value = (maxTime - time) / maxTime;
                if((maxTime - time) / maxTime < 0.3){
                    timeFillImage.color = Color.red;
                }
            }
            if(maxTime - time <= 0){
                bbbbbb = false;
                Texture2D texture2D = (Texture2D)rawImage.texture;
                var rect = rawImage.gameObject.GetComponent<RectTransform>().rect;
                drawSave.CardSave(texture2D, nowCardDrawNumber);
                paintController.WhiteTexture((int)rect.width, (int)rect.height);
                paintController.enabled = false;
                paintAll.enabled = false;
                
                if(nowCardDrawNumber < 4){
                    nowCardDrawNumber++;
                }
            }
        }
    }
    public void bbbbbbTrue(){
        bbbbbb = true;
        paintController.enabled = true;
        paintAll.enabled = true;
        time = 0f;
        timeFillImage.color = Color.green;
    }
}
