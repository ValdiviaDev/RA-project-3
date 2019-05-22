using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheerSoundControl : MonoBehaviour
{
    AudioSource source;
    public AudioClip explosion;
    public AudioClip click;

    public LevelsManager lvlManager;

    bool game_finished = false;

    bool waitToNextLvlM = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitToNextLvlM && !source.isPlaying)
        {
            waitToNextLvlM = false;
            lvlManager.NextLvl();
            transform.position = Vector3.zero;
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
                waitToNextLvlM = true;
            }
            game_finished = true;
        }
    }

}
