using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartsWhenDetect : MonoBehaviour
{
    public TrackStatus car;
    public TrackStatus finish;

    bool musicPlayed = false;

    public bool AllElementsTracked = false;

    // Update is called once per frame
    void Update()
    {
        if (!musicPlayed && car.found)
        {
            GetComponent<AudioSource>().Play();
            musicPlayed = true;
        }

        if (car.found && finish.found)
            AllElementsTracked = true;
    }
}
