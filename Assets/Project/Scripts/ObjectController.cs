using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public enum ObjectType { COOPER, EMERALD, ENEMY1, ENEMY2, PLANT };


    [SerializeField]
    public ObjectType type { get; private set;}


}
