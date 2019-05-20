using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectFromJoystick : MonoBehaviour
{

    protected Joystick joystick;
    protected Joybutton joybutton;

    public float velocity = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * velocity + Input.GetAxis("Horizontal") * velocity,
            joystick.Vertical * velocity + Input.GetAxis("Vertical") * velocity, rigidbody.velocity.z);
    }
}
