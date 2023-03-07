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
        for (int i = 0; i < itemSlotsImages.Count - 1; i++)
        {
            itemSlotsImages[i] = itemSlotsImages[i + 1];
        }
        itemSlotsImages.RemoveAt(itemSlotsImages.Count - 1);
    }

    public void UpdateImages(List<Sprite> sprites)
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            itemSlotsImages[i].sprite = sprites[i];
        }
    }

}
