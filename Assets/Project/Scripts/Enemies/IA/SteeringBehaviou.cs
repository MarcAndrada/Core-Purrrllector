using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviou : MonoBehaviour
{
    public abstract (float[] danger, float[] interest) GetSteering(float[] _danger, float[] _interest, IAData _iaData);
}
