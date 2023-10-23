using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public enum ItemType { COOPER, EMERALD, ENEMY1, ENEMY2, PLANT };


    [SerializeField]
    public ItemType type { get; private set;}


}
