using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findbodyparts : MonoBehaviour {

    protected bool Isfind_bodyparts = false;

    public GameObject Head_ = null;
    [System.NonSerialized]
    public Transform 
        Head,
        SpineBase,
        SpineMid,
        Neck, 
        ShoulderLeft,
        SpineShoulder,
        ElbowLeft,
        WristLeft,
        HandLeft,
        HipLeft,
        KneeLeft,
        HandTipRight, 
        ThumbRight, 
        HandTipLeft, 
        ThumbLeft, 
        FootRight, 
        AnkleRight, 
        KneeRight, 
        HipRight, 
        HandRight, 
        WristRight, 
        ElbowRight, 
        ShoulderRight, 
        AnkleLeft, 
        FootLeft;

    public void find_bodyparts()
    {
        Head_ = GameObject.Find("Head");
        if (Head_ != null) Isfind_bodyparts = true;

        if (Isfind_bodyparts == true)
        {
            SpineShoulder = GameObject.Find("SpineShoulder").transform;
            SpineBase = GameObject.Find("SpineBase").transform;
            SpineMid = GameObject.Find("SpineMid").transform;
            Neck = GameObject.Find("Neck").transform;
            Head = GameObject.Find("Head").transform;
            ShoulderLeft = GameObject.Find("ShoulderLeft").transform;
            ElbowLeft = GameObject.Find("ElbowLeft").transform;
            WristLeft = GameObject.Find("WristLeft").transform;
            HandLeft = GameObject.Find("HandLeft").transform;
            HipLeft = GameObject.Find("HipLeft").transform;
            KneeLeft = GameObject.Find("KneeLeft").transform;
            AnkleLeft = GameObject.Find("AnkleLeft").transform;
            FootLeft = GameObject.Find("FootLeft").transform;
            ShoulderRight = GameObject.Find("ShoulderRight").transform;
            ElbowRight = GameObject.Find("ElbowRight").transform;
            WristRight = GameObject.Find("WristRight").transform;
            HandRight = GameObject.Find("HandRight").transform;
            HipRight = GameObject.Find("HipRight").transform;
            KneeRight = GameObject.Find("AnkleRight").transform;
            AnkleRight = GameObject.Find("AnkleRight").transform;
            FootRight = GameObject.Find("FootRight").transform;
            ThumbLeft = GameObject.Find("ThumbLeft").transform;
            HandTipLeft = GameObject.Find("HandTipLeft").transform;
            ThumbRight = GameObject.Find("ThumbRight").transform;
            HandTipRight = GameObject.Find("HandTipRight").transform;
            Isfind_bodyparts = !Isfind_bodyparts;
        }
    }
}
