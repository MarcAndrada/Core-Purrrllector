using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField]
    private string detectionTag = "Player"; 
    private Transform targetTransform;

    [SerializeField]
    private Transform spawnPointTransform;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float timeFollowingTarget = 10.0f; // seconds
    private float time = 0.0f;

    private bool playerInArea;

    void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag(detectionTag).transform;
    }

    void Update()
    {
        if(playerInArea)
        {
            Following(targetTransform);

            time += Time.deltaTime;
            if (timeFollowingTarget < time)
            {
                playerInArea = false;
            }
        }
        else
        {
            Following(spawnPointTransform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectionTag))
        {
            playerInArea = true;
            time = 0.0f;
        }
    }

    private void Following(Transform target)
    {
        // ROTATION OF THE ENENMY WHILE FOLLOWING
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(spawnPointTransform.position, 0.5f);
    }
}
