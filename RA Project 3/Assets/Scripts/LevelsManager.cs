using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    enum Stage
    {
        NONE = -1,
        LVL_1,
        LVL_2
    }

    Stage currentStage = Stage.NONE;

    StartsWhenDetect TrackedElements;

    bool start = false;

    public GameObject Level1Prefab;
    public GameObject Level2Prefab;

    public GameObject LevelsSpawner;

    // Start is called before the first frame update
    void Start()
    {
        TrackedElements = GetComponent<StartsWhenDetect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TrackedElements.AllElementsTracked)
            start = true;

        if(start && currentStage == Stage.NONE)
        {
            currentStage = Stage.LVL_1;
            LevelsSpawner.transform.position = new Vector3(TrackedElements.finish.gameObject.transform.position.x, 0, TrackedElements.finish.gameObject.transform.position.z);
            Instantiate(Level1Prefab, LevelsSpawner.transform);
        }

    }
}
