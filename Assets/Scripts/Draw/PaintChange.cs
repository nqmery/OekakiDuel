using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PaintChange : MonoBehaviour{
    [SerializeField]
    PaintController paintController;
    [SerializeField]
    Image nowColorImage;
    public void ChangeRed(){
        paintController.paintColor = Color.red;
    }
    public void ChangeBlack(){
        paintController.paintColor = Color.black;
    }
    public void ChangeWhite(){
        paintController.paintColor = Color.white;
    }
    public void ChangeBlue(){
        paintController.paintColor = Color.blue;
    }
    public void ChangeGreen(){
        paintController.paintColor = Color.green;
    }
    public void ChangeYellow(){
        paintController.paintColor = Color.yellow;
    }
    public void ChangeVeryThick(){
        paintController.m_height = 100;
        paintController.m_width = 100;
    }
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
        
    }
}
