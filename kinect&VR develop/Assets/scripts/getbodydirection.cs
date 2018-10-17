using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getbodydirection : findbodyparts
{

    public bool isBodytilt_forward;
    public bool isBodytilt_back;
    public bool isBodytilt_Right;
    public bool isBodytilt_Left;
    public bool isRisehand_Right;
    public bool isRisehand_Left;
    public float bodyangle_FtoB;
    public float bodyangle_LtoR;
    public float Righthand_shoulder;
    public float Lefthand_shoulder;
    public float body_direction;

    // Update is called once per frame
    void Update()
    {
        find_bodyparts();

        if (Head_ != null) {

            Vector3 vecspineTop = SpineShoulder.position;
            Vector3 vecspineDown = SpineBase.position;
            Vector3 dot_bodyslope = vecspineTop - vecspineDown;

            //body_slope(left / right)or(Front / Rear)
            bodyangle_FtoB = smooth(dot(new Vector3(0, dot_bodyslope.y, dot_bodyslope.z), Vector3.up));
            if (dot(new Vector3(0, dot_bodyslope.y, dot_bodyslope.z), Vector3.forward) < 90.0f)
            {
                bodyangle_FtoB *= -1;
            }

            bodyangle_LtoR = smooth(dot(new Vector3(dot_bodyslope.x, dot_bodyslope.y, 0), Vector3.up)) * 2;
            if (dot(new Vector3(dot_bodyslope.x, dot_bodyslope.y, 0), Vector3.left) < 90.0f)
            {
                bodyangle_LtoR *= -1;
            }
            else if (bodyangle_LtoR < 5 && bodyangle_LtoR > -5)
            {
                bodyangle_LtoR = 0;
            }


            //bodyDirection(left / right)
            Vector3 vecbody_directionshoulder = Vector3.Cross((SpineShoulder.position - ShoulderRight.position).normalized, (SpineShoulder.position - ShoulderLeft.position).normalized);
            vecbody_directionshoulder = new Vector3(vecbody_directionshoulder.x, 0, vecbody_directionshoulder.z);
            body_direction = dot(vecbody_directionshoulder, Vector3.back);
            if (dot(vecbody_directionshoulder, Vector3.left) < 90.0f) body_direction *= -1;
            body_direction = smooth(body_direction);


            //bodySlope_check(forward / back)
            if (Mathf.Abs(vecspineTop.x - vecspineDown.x) < 1.0f && bodyangle_FtoB > 20.0f)
            {
                if (vecspineTop.z - vecspineDown.z > 0.5f) isBodytilt_back = true;
                if (vecspineTop.z - vecspineDown.z < -0.15f) isBodytilt_forward = true;
            }

            else
            {
                isBodytilt_back = false;
                isBodytilt_forward = false;
            }

            //bodySlope_check(left / right)
            if (bodyangle_LtoR > 15.0f) isBodytilt_Right = true;
            else if (bodyangle_LtoR < -15.0f) isBodytilt_Left = true;
            else
            {
                isBodytilt_Left = false;
                isBodytilt_Right = false;
            }

            //handRise(righthand / lefthand)
            if (Righthand_shoulder > 70.0f && isRisehand_Left == false) isRisehand_Right= true;

            else if (Lefthand_shoulder > 70.0f && isRisehand_Right == false) isRisehand_Left = true;

            else
            {
                isRisehand_Right = false;
                isRisehand_Left = false;
            }

            if (Righthand_shoulder > 70.0f && Lefthand_shoulder > 70.0f)
            {
                isRisehand_Right = false;
                isRisehand_Left = false;
            }
        }
    }

    public float dot(Vector3 vec1, Vector3 vec2)
    {
        float angle;
        angle = Mathf.Acos(Vector3.Dot(vec1.normalized, vec2.normalized)) * 180.0f / Mathf.PI;
        return angle;
    }

    public float smooth(float num1)
    {
        float num2 = 0;
        num1 = (num1 + num2) / 2;
        num2 = num1;
        return num1;
    }

}
