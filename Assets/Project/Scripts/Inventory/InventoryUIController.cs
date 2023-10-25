using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    private int itemIndex;
    private void OnEnable()
    {
        itemIndex = 0;
        Dictionary<ItemController.ItemType, short> items = InventoryManager.Instance.GetItems();

        foreach (KeyValuePair<ItemController.ItemType, short> item in items)
        {
            DisplayItem(item.Key, item.Value);
        }
    }

    private void DisplayItem(ItemController.ItemType _itemType, short _amount)
    {
        Sprite itemSprite = Resources.Load<Sprite>("MineralsTextures/" + _itemType.ToString());

    }

}
