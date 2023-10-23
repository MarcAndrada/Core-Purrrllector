using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    private Transform transformPlayer;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float visionRange = 6.0f;
    [SerializeField]
    private float timeFollowingTarget = 20.0f; // seconds
    private float time = 0.0f; 

    private float distanceBetween;
    private bool isFollowing;

    void Start()
    {
        transformPlayer = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Update()
    {
        distanceBetween = Vector2.Distance(transform.position, transformPlayer.position);

        if (distanceBetween < visionRange)
        {
            isFollowing = true;
            time = 0.0f;
        }
        else if (timeFollowingTarget < time)
        {
            isFollowing = false;
            time = 0.0f; 
        }


        if(isFollowing)
        {
            time += Time.deltaTime; 
            Following(); 
        }
    }

    private void Following()
    {
        // ROTATION OF THE ENENMY WHILE FOLLOWING
        Vector2 direction = transformPlayer.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, transformPlayer.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
