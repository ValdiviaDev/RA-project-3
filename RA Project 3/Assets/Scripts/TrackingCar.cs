using UnityEngine;
using System.Collections;
using Vuforia;

public class TrackingCar : DefaultTrackableEventHandler
{
    public GameObject SheerHA;

    AudioSource source;
    public AudioClip LookOverHere;

    //Timer for sound
    bool canPlaySound = true;
    float soundTimer = 0.0f;
    public float soundTime = 5.0f;

    void Update()
    {
        //For playing Look Over Here sound
        if (!canPlaySound)
        {
            soundTimer += Time.deltaTime;
            if(soundTimer >= soundTime)
            {
                canPlaySound = true;
                soundTimer = 0.0f;
            }
        }
    }

    protected override void OnTrackingFound()
    {
        if (canPlaySound)
        {
            source = SheerHA.GetComponent<AudioSource>();
            source.PlayOneShot(LookOverHere);
        }

        SheerHA.transform.position = Vector3.zero;
        canPlaySound = false;
        
    }

    protected override void OnTrackingLost()
    {
        SheerHA.transform.position = Vector3.zero;
    }
}