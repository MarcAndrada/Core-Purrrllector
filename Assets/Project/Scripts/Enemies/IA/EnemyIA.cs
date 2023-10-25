using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyIA : MonoBehaviour
{
    [SerializeField]
    private List<SteeringBehaviou> steeringBehaviours;

    [SerializeField]
    private List<Detector> detectors;

    [SerializeField]
    private IAData iaData;

    [SerializeField]
    private float detectionDelay = 0.05f;

    [SerializeField]
    private ContextSolver movementDirectionSolver;

    private bool isFollowing = false;

    [SerializeField]
    private float speed = 5.0f; 

    private void Start()
    {
        // Detecting player and obstacles around
        InvokeRepeating("PerformDetection", 0, detectionDelay); 
    }

    private void PerformDetection()
    {
        // DETECTORS
        foreach (Detector detector in detectors)
        {
            detector.Detect(iaData);
        }

    }

    private void Update()
    {
        // Enemy AI movement based on target availability 
        if(iaData.m_currentTarget != null)
        {
            // Looking at the target
            if(isFollowing == false)
            {
                isFollowing = true;
            }
        }
        else if(iaData.GetTargetsCount() > 0) // pick a target if you don't have one
        {
            // Target acquisition logic
            iaData.m_currentTarget = iaData.m_targets[0]; 
        }
        else
        {
            isFollowing = false;
            Debug.Log("Stopping"); 
        }

        if(isFollowing)
        {
            Vector2 direction = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, iaData);

            //Vector2 destination = direction - (Vector2)transform.position;
            //transform.position = Vector2.MoveTowards(this.transform.position, destination, speed * Time.deltaTime);
            
            // ROTATION OF THE ENENMY WHILE FOLLOWING
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }


}
