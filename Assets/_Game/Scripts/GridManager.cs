using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int maxValue;
    public int maxCubeBase;
    public bool finishPhase;
    public Vector3[] gridPosition;
    public GameObject[] gridGameObject;



    // Start is called before the first frame update
    void Start()
    {
        //setup two array
        gridPosition = new Vector3[maxCubeBase];
        gridGameObject = new GameObject[maxCubeBase];

        //fillup two array
        for (int i = 0; i < transform.childCount; i++)
        {
            gridPosition[i] = GetComponentsInChildren<Transform>()[i + 1].position;
            gridGameObject[i] = transform.GetChild(i).gameObject;
        }

        //setup maxValue
        maxValue = transform.childCount - 1;

    }

    // Update is called once per frame
    void Update()
    {
        //animation base
        //FindObjectOfType<EventManager>().RotateBase(gameObject);
    }

    public void GridUpdate(Vector3 pos, GameObject go)
    {
        maxValue += 1;
        gridPosition[maxValue] = pos;
        gridGameObject[maxValue] = go;

        //Finish phase
        if (maxValue == maxCubeBase - 1)
        {
            FinishPhase();
        }
    }


    //What happen when finish phase
    public void FinishPhase()
    {
        //set finish phase to not init new player
        finishPhase = true;

        //check everything is ok and animation the base
        // if (FindObjectOfType<EventManager>().CheckIsOutOfRange(gridPosition) && FindObjectOfType<PlayerController>().playerComplete)
        if (FindObjectOfType<EventManager>().CheckIsOutOfRange(gridPosition))
        {
            Invoke("AnimationAtEndPhase", .5f);
        }




    }
    public void AnimationAtEndPhase()
    {
        {
            FindObjectOfType<EventManager>().particleSys.Emit(1);
            // FindObjectOfType<EventManager>().AnimationBaseWhenLvComplete(GameObject.FindGameObjectsWithTag("Base"));
            FindObjectOfType<EventManager>().AnimationBaseWhenLvComplete(gridGameObject);
        }
    }


    public void onRotateComplete()
    {
        FindObjectOfType<EventManager>().rotateAble = true;
    }


    public void AnimationBase()
    {

    }
}
