using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_followtarget : MonoBehaviour {
    public Transform Target;
    public float PositionFolowForce = 5f;
    public float RotationFolowForce = 5f;
    void Start()
    {

    }

    void FixedUpdate()
    {
        var vector = Vector3.right;
        var dir = Target.rotation * Vector3.forward;
        dir.y = 0f;
        if (dir.magnitude > 0f) vector = dir / dir.magnitude;

        transform.position = Vector3.Lerp(transform.position, Target.position, PositionFolowForce * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vector), RotationFolowForce * Time.deltaTime);
    }
}


