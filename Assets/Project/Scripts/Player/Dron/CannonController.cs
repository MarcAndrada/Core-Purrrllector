using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField]
    public List<Transform> l_lasers;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private float reloadDelay;

    private bool canShoot;
    private float currentDelay;

    private void Awake()
    {
        canShoot = true;
    }

    private void Update()
    {
        if(canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if(currentDelay <= 0)
            {
                canShoot=true;
            }
        }
    }

    public void Shoot()
    {
        if(canShoot) 
        {
            canShoot = false;
            currentDelay = reloadDelay;
            foreach(var laser in l_lasers)
            {
                GameObject l = Instantiate(laserPrefab);
                l.transform.position = laser.transform.position;
                l.transform.localRotation = laser.rotation;
                l.GetComponent<Laser>().Initialize();  
            }
        }
    }
}
