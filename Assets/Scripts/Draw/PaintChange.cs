using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintChange : MonoBehaviour{
    [SerializeField]
    PaintController paintController;
    [SerializeField]
    Image nowColorImage;
    [SerializeField]
    Slider shading;
    public void ChangeRed(){
        paintController.paintColor = Color.red;
        shading.value = 1f;
    }
    public void ChangeBlack(){
        paintController.paintColor = Color.black;
        shading.value = 1f;
    }
    public void ChangeWhite(){
        paintController.paintColor = Color.white;
        shading.value = 1f;
    }
    public void ChangeBlue(){
        paintController.paintColor = Color.blue;
        shading.value = 1f;
    }
    public void ChangeGreen(){
        paintController.paintColor = Color.green;
        shading.value = 1f;
    }
    public void ChangeYellow(){
        paintController.paintColor = Color.yellow;
        shading.value = 1f;
    }
    public void ChangeGrey(){
        paintController.paintColor = Color.grey;
        shading.value = 1f;
    }
    public void ChangeSkin(){
        Color color = new Color(1f, 0.7647059f, 0.6666667f);
        paintController.paintColor = color;
        shading.value = 1f;
    }
    // public void ChangeVeryThick(){
    //     paintController.m_height = 100;
    //     paintController.m_width = 100;
    // }
    public void ChangeThick(){
        paintController.m_height = 50;
        paintController.m_width = 50;
    }
    public void ChangeUsually(){
        paintController.m_height = 30;
        paintController.m_width = 30;
    }
    public void ChangeThin(){
        paintController.m_height = 10;
        paintController.m_width = 10;
    }
    public void ChangeVeryThin(){
        paintController.m_height = 5;
        paintController.m_width = 5;
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        nowColorImage.color = paintController.paintColor;
    }
}
