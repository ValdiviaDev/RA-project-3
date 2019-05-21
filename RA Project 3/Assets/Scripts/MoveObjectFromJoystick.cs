using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectFromJoystick : MonoBehaviour
{

    protected Joystick joystick;
    protected Joybutton joybutton;

    public float velocity = 0.05f;
    private Vector3 initial_pos = new Vector3();


    int collision = 0;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        initial_pos = transform.position;
        collision = LayerMask.GetMask("Obstacles");

        Debug.Log(collision.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystick.Vertical * velocity + Input.GetAxis("Vertical") * velocity,
         rigidbody.velocity.y, -joystick.Horizontal * velocity + Input.GetAxis("Horizontal") * velocity);
    }


    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
            transform.position = initial_pos;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("FinishLine"))
            Debug.Log("Goal Reached");

    }

}
