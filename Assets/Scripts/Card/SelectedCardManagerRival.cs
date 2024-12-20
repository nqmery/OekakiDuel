using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedCardManagerRival : MonoBehaviour
{
    public static SelectedCardManagerRival selectedCardManagerRival;

    [SerializeField]
    private Texture texture;
    [SerializeField]
    private RawImage rawImage;
    // Start is called before the first frame update
    void Start()
    {
        var rect = rawImage.gameObject.GetComponent<RectTransform>().rect;
        Texture2D texture = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGBA32, false);

        texture = BattleManager.rivalCardSelected.cardImage;
        rawImage.texture = texture;
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
