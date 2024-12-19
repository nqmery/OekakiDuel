using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadingChange : MonoBehaviour{
    [SerializeField]
    Slider shading;
    [SerializeField]
    PaintController paintController;
    Color color;
    // Start is called before the first frame update
    void Start(){
        shading.value = 1f;
    }

    // Update is called once per frame
    void Update(){
        color = paintController.paintColor;
        paintController.paintColor = new Color(color.r, color.g, color.b, shading.value);
    }
}
