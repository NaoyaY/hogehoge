using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingbehavior : MonoBehaviour
{
    getbodydirection bodybones_states;
    Rigidbody rb;
    private float rotz;
    public float testfloat ;

    void Start()
    {
        bodybones_states = GetComponent<getbodydirection>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ///<summary>
        ///速度調整
        ///</summary>
        if (bodybones_states.isBodytilt_forward)
            rb.AddForce(transform.forward * -10f);
        else
            rb.velocity = transform.forward * -25f;
        rb.maxDepenetrationVelocity = -25.0f;


        ///<summary>
        ///ローカル角度
        ///</summary>
        if (Mathf.Abs(bodybones_states.bodyangle_LtoR) < 10)
        {
            if (isrightturn_short(transform.localEulerAngles.z))
                rotz -= Mathf.Lerp(0f, rotz, Time.deltaTime);
            else
                rotz += Mathf.Lerp(0f, Mathf.Abs(360f - rotz), Time.deltaTime);
        }
        else
            rotz = transform.localEulerAngles.z + 0.01f * bodybones_states.bodyangle_LtoR;

        if (isrightturn_short(transform.localEulerAngles.z))
        {
            rotz = Mathf.Min(rotz, 30);
        }
        else
            rotz = Mathf.Max(rotz, 330);
        transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, rotz);
        Debug.Log(rotz);


        ///<summary>
        ///トルク
        ///</summary>
        float torque_force = 0.1f;
        if (bodybones_states.isBodytilt_Right || bodybones_states.isBodytilt_Left)
        {
            if (bodybones_states.isBodytilt_Left)
                torque_force *= -1;
            rb.AddTorque(Vector3.up * torque_force);
        }
        else
        {
            if (rb.angularVelocity.y > 0)
                torque_force *= -1;
            rb.AddTorque(Vector3.up * torque_force *2f);
        }
        rb.maxAngularVelocity = Mathf.Clamp(rb.maxAngularVelocity ,- 3, 3);

        Physics.gravity = new Vector3(0, -4.9f, 0);

    }

    public bool isrightturn_short(float rot)
    {
        return rot < Mathf.Abs(360f - rot) ? true : false;
    }
}
