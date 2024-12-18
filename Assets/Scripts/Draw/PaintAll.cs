using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintAll : MonoBehaviour{
    [SerializeField]
    private PaintController paintController;
    [SerializeField]
    private RawImage rawImage;
    private Color color;
    Rect rect;
    void Start(){
        rect = rawImage.gameObject.GetComponent<RectTransform>().rect;
    }
    public void AllPaint(){
        color = paintController.paintColor;
        for(int w = 0; w < (int)rect.width; w++){
            for (int h = 0; h < (int)rect.height; h++){
                paintController.m_texture.SetPixel(w, h, color);
            }
        }
        paintController.m_texture.Apply();
    }
}
