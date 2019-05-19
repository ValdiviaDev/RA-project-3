using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectFromJoystick : MonoBehaviour
{

    protected Joystick joystick;
    protected Joybutton joybutton;

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

        rigidbody.velocity = new Vector3(joystick.Horizontal * 0.01f + Input.GetAxis("Horizontal") * 0.01f,
            rigidbody.velocity.y,
            joystick.Vertical * 0.01f + Input.GetAxis("Vertical") * 0.01f);
    }
}
