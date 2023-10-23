using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    
    private Dictionary<ObjectController.ObjectType, short> items;

    private void Awake()
    {
        items = new Dictionary<ObjectController.ObjectType, short>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            AddObject(ObjectController.ObjectType.COOPER, 1);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddObject(ObjectController.ObjectType.COOPER, -1);
        }
    }

    public void AddObject(ObjectController.ObjectType _objectType, short _itemsToAdd)
    {
        if (!items.ContainsKey(_objectType))
        {
            items.Add(_objectType, _itemsToAdd);
        }
        else
        {
            items[_objectType] += _itemsToAdd;
            if (items[_objectType] < 0)
                items[_objectType] = 0;
        }



        Debug.Log(items[_objectType]);
    }
    
    public short GetObject(ObjectController.ObjectType _objectType)
    {
        return items[_objectType];
    }
}
