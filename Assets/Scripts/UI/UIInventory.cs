using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    private List<Image> itemSlotsImages;

    private void Awake()
    {
        itemSlotsImages = gameObject.GetComponentsInChildren<Image>().ToList();
    }

    public void UpdateImages(List<Sprite> sprites)
    {
        int index = 0;
        foreach (Image image in itemSlotsImages)
        {
            image.sprite = sprites[index];
            index++;
        }
    }

}
