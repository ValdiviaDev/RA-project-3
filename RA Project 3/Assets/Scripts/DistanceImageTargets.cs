using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceImageTargets : MonoBehaviour
{
    public GameObject point1 = null;
    public GameObject point2 = null;

    public Text p1t = null;
    public Text p2t = null;
    public Text distancet = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(point1 && point2 && p1t && p2t && distancet)
        {
            p1t.text = "Car position " + point1.transform.position.ToString();
            p2t.text = "Finish position " + point2.transform.position.ToString();
            distancet.text = "Distance " + (point1.transform.position - point2.transform.position).ToString();
        }
    }
}
