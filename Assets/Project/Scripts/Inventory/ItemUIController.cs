using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIController : MonoBehaviour
{
    [SerializeField]
    private Dictionary<ItemController.ItemType, Sprite> itemsSprite;



    private void Awake()
    {
    }

    private void DisplayObtainedItem(ItemController.ItemType _itemType, short _itemAmount)
    {

    }



    private void OnEnable()
    {
        EventManager.onItemChange += DisplayObtainedItem;
    }


    private void OnDisable()
    {
        EventManager.onItemChange -= DisplayObtainedItem;
    }





}
