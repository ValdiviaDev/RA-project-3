using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheerController : MonoBehaviour
{
    AudioSource source;
    public AudioClip explosion;
    public AudioClip click;
    public AudioClip LookOverHere;

    public LevelsManager lvlManager;

    public TrackStatus sheer;
    bool game_Started = false;

    bool game_finished = false;

    bool waitToNextLvlM = false;

    MoveObjectFromJoystick sheerMovement;

    //Start label
    bool label_trigger = true;
    bool label_enabled = false;
    public GameObject start_label;
    float labelimer = 0.0f;
    public float labelTime = 5.0f;

    //Explosion
    public GameObject explosionParticle;
    float explosiontimer = 0.0f;
    public float explosionTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        sheerMovement = GetComponent<MoveObjectFromJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!game_Started && sheer.found)
        {
            source.PlayOneShot(LookOverHere);
            game_Started = true;

            if (label_trigger)
            {
                start_label.SetActive(true);
                label_trigger = false;
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

        if(waitToNextLvlM)
        {
            explosiontimer += Time.deltaTime;
            if(explosiontimer >= explosionTime)
            {
                explosionParticle.SetActive(true);
            }
        }

        if (waitToNextLvlM && !source.isPlaying)
        {
            waitToNextLvlM = false;
            lvlManager.NextLvl();
            transform.position = Vector3.zero;
            explosionParticle.SetActive(false);
            explosiontimer = 0;
            sheerMovement.canMove = true;
            game_finished = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            source.PlayOneShot(click);
            lvlManager.Restart();
        }

    }


    void OnTriggerEnter(Collider col)
    {
        if (!game_finished)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("FinishLine"))
            {
                source.PlayOneShot(explosion);
                lvlManager.ClearActualLvl();
                sheerMovement.canMove = false;
                waitToNextLvlM = true;
            }
            game_finished = true;
        }
    }

}
