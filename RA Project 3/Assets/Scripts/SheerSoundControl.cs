using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheerSoundControl : MonoBehaviour
{
    AudioSource source;
    public AudioClip explosion;
    public AudioClip click;

    bool game_finished = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
            source.PlayOneShot(click);

    }


    void OnTriggerEnter(Collider col)
    {
        if(!game_finished)
            if (col.gameObject.layer == LayerMask.NameToLayer("FinishLine"))
                source.PlayOneShot(explosion);

        game_finished = true;
    }

}
