using UnityEngine;
using System.Collections;
using Vuforia;

public class TrackingCar : DefaultTrackableEventHandler
{
    public GameObject SheerHA;


    protected override void OnTrackingFound()
    {
        SheerHA.transform.position = Vector3.zero;
    }

    protected override void OnTrackingLost()
    {
        SheerHA.transform.position = Vector3.zero;
    }
}


