using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheerSoundControl : MonoBehaviour
{
    AudioSource source;
    public AudioClip explosion;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("FinishLine"))
            source.PlayOneShot(explosion);

    }

}
