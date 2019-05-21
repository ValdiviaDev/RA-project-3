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

    //Start label
    bool label_trigger = true;
    bool label_enabled = false;
    public GameObject start_label;
    float labelimer = 0.0f;
    public float labelTime = 5.0f;

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

        if (start_label.activeSelf)
        {
            labelimer += Time.deltaTime;
            if (labelimer >= labelTime)
            {
                start_label.SetActive(false);
                labelimer = 0.0f;
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
        if (label_trigger) {
            start_label.SetActive(true);
            label_trigger = false;
         }

        SheerHA.transform.position = Vector3.zero;
        canPlaySound = false;
        
    }

    protected override void OnTrackingLost()
    {
        SheerHA.transform.position = Vector3.zero;
    }
}