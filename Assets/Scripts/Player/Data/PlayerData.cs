using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [Header("Movement State")]

    //speed
    public float walkingVelocity;
    public float trottingVelocity;
    public float canterVelocity;
    public float gallopVelocity;
    //stopping
    public float softDecelerationSpeed;
    public float hardDecelerationSpeed;
    public float stopVelocityThreshold;

}
