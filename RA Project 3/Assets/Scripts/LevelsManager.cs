using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public enum Stage
    {
        NONE = -1,
        LVL_1,
        LVL_2,
        LVL_3
    }

    public Stage currentStage = Stage.NONE;

    StartsWhenDetect TrackedElements;

    bool start = false;

    public GameObject Level1Prefab;
    public GameObject Level2Prefab;
    public GameObject Level3Prefab;

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
            LevelsSpawner.transform.position = new Vector3(TrackedElements.finish.gameObject.transform.position.x, 0, TrackedElements.finish.gameObject.transform.position.z) / 2;
            Instantiate(Level1Prefab, LevelsSpawner.transform);
        }

    }

    public void Restart()
    {
        if (LevelsSpawner.transform.childCount > 0)
        {
            for (int i = 0; i <= LevelsSpawner.transform.childCount; i++)
                Destroy(LevelsSpawner.transform.GetChild(i++).gameObject);
        }
        switch (currentStage)
        {
            case Stage.LVL_1:
             {
                    Instantiate(Level1Prefab, LevelsSpawner.transform);
                    break;
             }
            case Stage.LVL_2:
                {
                    Instantiate(Level2Prefab, LevelsSpawner.transform);
                    break;
                }
            case Stage.LVL_3:
                {
                    Instantiate(Level3Prefab, LevelsSpawner.transform);
                    break;
                }
        }
    }

    public void NextLvl()
    {
        switch (currentStage)
        {
            case Stage.LVL_1:
                {
                    currentStage = Stage.LVL_2;
                    Instantiate(Level2Prefab, LevelsSpawner.transform);
                    break;
                }
            case Stage.LVL_2:
                {
                    currentStage = Stage.LVL_3;
                    Instantiate(Level3Prefab, LevelsSpawner.transform);
                    break;
                }
            case Stage.LVL_3:
                {
                    SceneManager.LoadSceneAsync("FinishScene");
                    break;
                }
        }
    }

    public void ClearActualLvl()
    {
        if (LevelsSpawner.transform.childCount > 0)
        {
            for (int i = 0; i <= LevelsSpawner.transform.childCount; i++)
                Destroy(LevelsSpawner.transform.GetChild(i++).gameObject);
        }
    }
}
