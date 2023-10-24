using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemNotificationController : MonoBehaviour
{
    [SerializeField]
    private float timeToDisapear;
    [SerializeField]
    private Image c_itemImage;
    private void Awake() 
    {
        Invoke("DisableNotification", timeToDisapear);
    }


    public void SetSprite(Sprite _itemImage)
    {
        c_itemImage.sprite = _itemImage;
    }
    private void DisableNotification()
    {
        Destroy(gameObject);
    }
}
