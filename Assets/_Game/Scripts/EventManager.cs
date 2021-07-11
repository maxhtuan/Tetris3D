using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EventManager : MonoBehaviour
{
    public GameObject quad;
    public int totalRotate;
    public bool rotateAble;
    public ParticleSystem particleSys;
    public ParticleSystem particleStartMove;
    public ParticleSystem particleHit;
    public GameObject cameraShake;

    // Start is called before the first frame update

    void Start()
    {
        rotateAble = true;
        SpawnManager(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextScene();
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public Vector3 Round(Vector3 pos)
    {
        return new Vector3(Mathf.CeilToInt(pos.x), Mathf.CeilToInt(pos.y), Mathf.CeilToInt(pos.z));

    }

    public void SpawnPlayer(GameObject go, Vector3 pos)
    {
        Instantiate(go, pos, new Quaternion(0f, 0f, 0f, 0f));
    }




    public bool CheckIsOutOfRange(Vector3[] gridArray)
    {
        //check is any pos is out of range
        foreach (Vector3 pos in gridArray)
        {
            float i = (Mathf.Sqrt(FindObjectOfType<GridManager>().maxCubeBase - 1) / 2);
            if (pos.x > i || pos.x < -i || pos.z > i || pos.z < -i)
            {
                Debug.Log("Out of range");
                return false;
            }

        }
        Debug.Log("it ok");
        return true;

    }

    public void RotateBaseRight(GameObject go)
    {
        // foreach (GameObject go1 in go)
        {
            if (rotateAble)
            {
                rotateAble = false;
                {
                    Hashtable hash = new Hashtable();
                    hash.Add("amount", new Vector3(0, -90f, 0));
                    hash.Add("time", .2f);
                    hash.Add("onComplete", "onRotateComplete");
                    // hash.Add("easetype", iTween.EaseType.easeOutBounce);
                    hash.Add("easetype", iTween.EaseType.easeOutBack);
                    iTween.RotateAdd(go, hash);
                    totalRotate += 90;

                    switch (totalRotate)
                    {
                        case 270:
                            totalRotate = -90;
                            break;
                        case -270:
                            totalRotate = 90;
                            break;
                    }
                    //onRotateComplete();
                }
            }
        }

    }


    public void RotateBaseLeft(GameObject go)
    {
        // FindObjectOfType<PlayerController>().moveable = false;
        // foreach (GameObject go1 in go)
        {
            if (rotateAble)
            {
                rotateAble = false;
                {
                    Hashtable hash = new Hashtable();
                    hash.Add("amount", new Vector3(0, 90f, 0));
                    hash.Add("time", .2f);
                    hash.Add("onComplete", "onRotateComplete");
                    // hash.Add("easetype", iTween.EaseType.easeOutBounce);
                    hash.Add("easetype", iTween.EaseType.easeOutBack);
                    iTween.RotateAdd(go, hash);
                    totalRotate -= 90;
                    switch (totalRotate)
                    {
                        case 270:
                            totalRotate = -90;
                            break;
                        case -270:
                            totalRotate = 90;
                            break;
                    }
                    //onRotateComplete();
                }
            }
        }


    }

    public void AnimationBaseWhenLvComplete(GameObject[] go)
    {
        Hashtable firstHash = new Hashtable();
        firstHash.Add("scale", new Vector3(1, 0.5f, 1));
        firstHash.Add("time", 0.25f);
        firstHash.Add("delay", 0f);

        Hashtable SecHash = new Hashtable();
        SecHash.Add("scale", new Vector3(1, 1f, 1));
        SecHash.Add("time", 0.35f);
        SecHash.Add("delay", .25f);
        foreach (GameObject go1 in go)
        {
            iTween.ScaleTo(go1, firstHash);
            iTween.ScaleTo(go1, SecHash);
        }
    }

    public void onRotateComplete()
    {
        rotateAble = true;
        // FindObjectOfType<PlayerController>().moveable = true;
    }

    public void SpawnManager(int currentTetris)
    {
        Vector3 pos = new Vector3(8, 0, 0);
        SpawnPlayer(FindObjectOfType<LevelSetting>()._tetris[currentTetris], pos);
        FindObjectOfType<LevelSetting>().currentTetris++;
        // FindObjectOfType<LevelSetting>()._tetris[]
    }
}
