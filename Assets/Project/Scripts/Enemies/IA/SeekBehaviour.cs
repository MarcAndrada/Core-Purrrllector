using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SeekBehaviour : SteeringBehaviou
{
    [SerializeField]
    private float targetRaechedThreshold = 0.5f;

    private bool reachedLastTarget = true;

    //DEBUG
    [SerializeField]
    private bool showGizmos = true;
    private Vector2 targetPositionCached;
    private float[] interestTemp;

    public override (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, IAData iaData)
    {
        // if... we don't have a target stop seeking
        // else... set a new target
        if (reachedLastTarget)
        {
            if (iaData.m_targets == null || iaData.m_targets.Count <= 0)
            {
                iaData.m_currentTarget = null;
                return (danger, interest);
            }
            else
            {
                reachedLastTarget = false;
                iaData.m_currentTarget = iaData.m_targets.OrderBy
                    (target => Vector2.Distance(target.position, transform.position)).FirstOrDefault();
            }
        }

        // Cache the last position only if we still see the target (if the targets collection is not empty)
        if (iaData.m_currentTarget != null && iaData.m_targets != null && iaData.m_targets.Contains(iaData.m_currentTarget))
        {
            targetPositionCached = iaData.m_currentTarget.position;
        }

        // First check if we have reached the target
        if (Vector2.Distance(transform.position, targetPositionCached) < targetRaechedThreshold)
        {
            reachedLastTarget = true;
            iaData.m_currentTarget = null;
            return (danger, interest); // Nothing to chase
        }

        // if we haven't yet reached the target do the main logic of finding the interest directions
        Vector2 directionToTarget = targetPositionCached - (Vector2)transform.position;
        for (int i = 0; i < interest.Length; i++)
        {
            // Closes direction
            float result = Vector2.Dot(directionToTarget.normalized, Directions.m_eightDirections[i]);

            // Accept only directions at the less than 90º to the target direction
            if (result > 0)
            {
                float valueToPutIn = result;
                if (valueToPutIn > interest[i])
                {
                    interest[i] = valueToPutIn;
                }
            }
        }
        interestTemp = interest;
        return (danger, interest);
    }

    private void OnDrawGizmos()
    {
        if (showGizmos == false)
            return;

        Gizmos.DrawSphere(targetPositionCached, 0.2f); 

        if(Application.isPlaying && interestTemp != null)
        {
            if (interestTemp != null)
            {
                Gizmos.color = Color.green; 
                for(int i = 0; i < interestTemp.Length; i++)
                {
                    Gizmos.DrawRay(transform.position, Directions.m_eightDirections[i] * interestTemp[i]);
                }
                if(reachedLastTarget == false)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(targetPositionCached, 0.1f); 
                }
            }
        }
    }

}
