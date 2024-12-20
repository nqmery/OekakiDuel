using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedCardManagerRival : MonoBehaviour
{
    public static SelectedCardManagerRival selectedCardManagerRival;

    [SerializeField]
    private Texture texture;
    private RawImage rawImage;
    // Start is called before the first frame update
    void Start()
    {
        Transform childTransform = transform.Find("CardTexture");
        RawImage rawImage = childTransform.GetComponent<RawImage>();

        rawImage.texture = BattleManager.myCardSelected.cardImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableImage()
    {
        this.gameObject.SetActive(false);
    }

    public void SetCardImage(Texture texture)
    {
        rawImage.texture = texture;
    }


}
