using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvertTest : MonoBehaviour
{
    public Texture2D texture_Before;
    public Image image_After;

    void Start()
    {
        //Texture->byte変換
        byte[] byte_Before = texture_Before.EncodeToPNG();

        //BASE64への変換
        string encodedText
            = System.Convert.ToBase64String(byte_Before);
        Debug.Log(encodedText);

        //BASE64からの変換
        byte[] byte_After
            = System.Convert.FromBase64String(encodedText);

        //byte->Texture変換
        Texture2D texture_After
        = new Texture2D(texture_Before.width, texture_Before.height,
                                        TextureFormat.RGBA32, false);
        texture_After.LoadImage(byte_After);

        //UIに変換後のTextureを表示
        image_After.material.mainTexture = texture_After;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
