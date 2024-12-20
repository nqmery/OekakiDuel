using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedCardManagerME : MonoBehaviour
{
    public static SelectedCardManagerME selectedCardManagerME;

    [SerializeField]
    private RawImage cardImage;
    // Start is called before the first frame update
    void Start()
    {
        this.cardImage = this.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableImage()
    {
        cardImage.gameObject.SetActive(false);
    }
    public void SetCardImage(Texture texture)
    {
        cardImage.texture = texture;
    }
}
