using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIController : MonoBehaviour
{
    [SerializeField]
    private Dictionary<ItemController.ItemType, Image> itemsSprite;

    private Queue<GameObject> notificationToDelete;


    private void Awake()
    {
        notificationToDelete = new Queue<GameObject>();
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
        
    }



    

}
