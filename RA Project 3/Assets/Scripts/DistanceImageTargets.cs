using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceImageTargets : MonoBehaviour
{
    public GameObject point1 = null;
    public GameObject point2 = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(point1 && point2)
        {
            GetComponent<Text>().text = (point1.transform.position - point2.transform.position).ToString();
        }
    }
}
