using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestCardReciever : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //メッセージがあるとき
        if(NetworkManager.networkManager.GetMessage() != null)
        {
            byte[] recievedData = NetworkManager.networkManager.GetMessage();
            if(recievedData[0] == 24)
            {
                //カード情報の受信処理
                NetworkManager.networkManager.PopMessage();
                byte[] imageBinary = recievedData.Skip(7).ToArray();
                PaintController.paintController.SetTexture(imageBinary);
            }
        }
    }
}
