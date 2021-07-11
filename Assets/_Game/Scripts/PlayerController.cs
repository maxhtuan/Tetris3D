using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool moveable;
    public float speed;
    // public GameObject preFabs;
    public Vector3 posRounded;
    public RaycastHit hit;
    public RaycastHit hitDinh;
    public float collisionCheckDistance;
    public Vector2 firstPressPos;
    public Vector2 secondPressPos;
    public Vector2 currentSwipe;
    public bool playerComplete = false;
    public Hashtable hashColor = new Hashtable();
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        // preFabs = Resources.Load("Prefabs/TetrisI") as GameObject;

        hashColor.Add("color", color);
        hashColor.Add("time", 1f);
    }

    // Update is called once per frame
    void Update()
    {

        InputGameplay();

        //when intouch
        if (!moveable && FindObjectOfType<EventManager>().rotateAble)
        {
            SetPosAfterAttach();
            // FindObjectOfType<EventManager>().AnimationColorChangeInBase();
        }
    }

    public void MovePlayer()
    {
        if (FindObjectOfType<EventManager>().rotateAble)
        {
            FindObjectOfType<EventManager>().rotateAble = false;
            this.gameObject.GetComponent<Rigidbody>().SweepTest(new Vector3(-1, 0, 0), out hit, 10f);
            Vector3 pos = hit.collider.transform.position + new Vector3(1, 0, 0);

            //Check dinh cua tetris point
            if (this.gameObject.name.Equals("TetrisPoint(Clone)"))
            {
                if (hit.transform.position.z < 0.8f && hit.transform.position.z > -0.8f)
                {
                    // Debug.Log("day la dinh");
                    pos.x += 1;
                }
                // else
                // {
                //     pos.x += 1;
                // }
            }

            //Check dinh cua tetris L
            if (this.gameObject.name.Equals("TetrisL(Clone)"))
            {

                if (hit.transform.position.z < -0.8f && hit.transform.position.z > -1.8f)
                {

                    Debug.Log("day la dinh");
                    pos.x += 1;
                }
                // else
                // {
                //     pos.x += 1;
                // }
            }

            pos.z = 0;
            Debug.Log(hit.collider.transform.position);

            FindObjectOfType<EventManager>().particleStartMove.Emit(30);

            Hashtable hash = new Hashtable();
            hash.Add("position", pos);
            hash.Add("time", .2f);
            // hash.Add("easeType", iTween.EaseType.easeOutBounce);
            hash.Add("easeType", iTween.EaseType.easeOutQuint);
            hash.Add("oncomplete", "onMoveComplete");
            iTween.MoveTo(this.gameObject, hash);

        }


        //iTween.MoveUpdate(gameObject, new Vector3(-speed, 0, 0), .2f);
        //transform.position = this.transform.position - new Vector3(speed, 0, 0);

        // FindObjectOfType<EventManager>().rotateAble = false;
        // gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-speed * 50, 0, 0));
        // iTween.MoveUpdate(gameObject, new Vector3(-1, 0, 0), 8f);





    }

    public void onMoveComplete()
    {
        moveable = false;
        FindObjectOfType<EventManager>().rotateAble = true;
        playerComplete = true;
        FindObjectOfType<EventManager>().particleHit.Emit(30);

        iTween.ShakePosition(FindObjectOfType<EventManager>().cameraShake, new Vector3(.3f, .3f, .3f), .2f);


    }
    public void SetPosAfterAttach()
    {
        //disable force
        // gameObject.GetComponent<Rigidbody>().Sleep();

        //setup new position
        // transform.position = new Vector3(posRounded.x, 0, 0);


        AddValueToArray();


        ////add animator
        // gameObject.AddComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/BaseAni") as RuntimeAnimatorController;




        //combine with base
        transform.SetParent(GameObject.Find("Base").transform);

        //set layer = base
        this.gameObject.tag = "Base";

        //set player input false
        GetComponent<PlayerInput>().enabled = false;

        //reset moveable
        moveable = true;

        //init new player
        if (!FindObjectOfType<GridManager>().finishPhase)
        {
            // int i = FindObjectOfType<LevelSetting>().currentTetris++;
            FindObjectOfType<EventManager>().SpawnManager(FindObjectOfType<LevelSetting>().currentTetris);
            // FindObjectOfType<EventManager>().SpawnPlayer(preFabs, new Vector3(8, 0, 0));
            //Instantiate(preFabs, new Vector3(8, 0, 0), new Quaternion(0f, 0f, 0f, 0f));
        }

        enabled = false;
    }
    public void InputGameplay()
    {

        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);
        //     if (touch.phase == UnityEngine.TouchPhase.Began)
        //     {
        //         MovePlayer();
        //     }

        // }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(touch.position.x, touch.position.y);

            }
            if (touch.phase == UnityEngine.TouchPhase.Ended)
            {
                secondPressPos = new Vector2(touch.position.x, touch.position.y);
                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {

                    {
                        MovePlayer();
                    }

                }
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    FindObjectOfType<EventManager>().RotateBaseLeft(GameObject.Find("Base"));
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    FindObjectOfType<EventManager>().RotateBaseRight(GameObject.Find("Base"));
                }
            }



        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Base"))
        {
            posRounded = FindObjectOfType<EventManager>().Round(transform.position);
            Debug.Log("entered");
            moveable = false;
            FindObjectOfType<EventManager>().rotateAble = true;
        }

    }

    public void AddValueToArray()
    {
        //add position for array
        for (int i = 0; i < transform.childCount; i++)
        {
            iTween.ColorTo(transform.GetChild(i).gameObject, hashColor);
            // transform.TransformPoint(transform.GetChild(i).position);
            switch (FindObjectOfType<EventManager>().totalRotate)
            {
                case 0:
                    Vector3 pos0 = new Vector3(transform.GetChild(i).position.x, transform.GetChild(i).position.y, transform.GetChild(i).position.z);
                    pos0.x = Mathf.RoundToInt(pos0.x);
                    pos0.y = Mathf.RoundToInt(pos0.y);
                    pos0.z = Mathf.RoundToInt(pos0.z);
                    FindObjectOfType<GridManager>().GridUpdate(pos0, transform.GetChild(i).gameObject);
                    break;
                case 360:
                    Vector3 pos360 = new Vector3(transform.GetChild(i).position.x, transform.GetChild(i).position.y, transform.GetChild(i).position.z);
                    pos360.x = Mathf.RoundToInt(pos360.x);
                    pos360.y = Mathf.RoundToInt(pos360.y);
                    pos360.z = Mathf.RoundToInt(pos360.z);
                    FindObjectOfType<GridManager>().GridUpdate(pos360, transform.GetChild(i).gameObject);
                    break;
                case -360:
                    Vector3 posN360 = new Vector3(transform.GetChild(i).position.x, transform.GetChild(i).position.y, transform.GetChild(i).position.z);
                    posN360.x = Mathf.RoundToInt(posN360.x);
                    posN360.y = Mathf.RoundToInt(posN360.y);
                    posN360.z = Mathf.RoundToInt(posN360.z);
                    FindObjectOfType<GridManager>().GridUpdate(posN360, transform.GetChild(i).gameObject);
                    break;
                case 90:
                    Vector3 pos90 = new Vector3(-transform.GetChild(i).position.z, transform.GetChild(i).position.y, transform.GetChild(i).position.x);
                    pos90.x = Mathf.RoundToInt(pos90.x);
                    pos90.y = Mathf.RoundToInt(pos90.y);
                    pos90.z = Mathf.RoundToInt(pos90.z);
                    FindObjectOfType<GridManager>().GridUpdate(pos90, transform.GetChild(i).gameObject);
                    break;
                case -90:
                    Vector3 posN90 = new Vector3(transform.GetChild(i).position.z, transform.GetChild(i).position.y, -transform.GetChild(i).position.x);
                    posN90.x = Mathf.RoundToInt(posN90.x);
                    posN90.y = Mathf.RoundToInt(posN90.y);
                    posN90.z = Mathf.RoundToInt(posN90.z);
                    FindObjectOfType<GridManager>().GridUpdate(posN90, transform.GetChild(i).gameObject);
                    break;
                case 180:
                    Vector3 pos180 = new Vector3(transform.GetChild(i).position.z, transform.GetChild(i).position.y, transform.GetChild(i).position.x);
                    pos180.x = Mathf.RoundToInt(pos180.x);
                    pos180.y = Mathf.RoundToInt(pos180.y);
                    pos180.z = Mathf.RoundToInt(pos180.z);
                    FindObjectOfType<GridManager>().GridUpdate(pos180, transform.GetChild(i).gameObject);
                    break;
                case -180:
                    Vector3 posN180 = new Vector3(transform.GetChild(i).position.z, transform.GetChild(i).position.y, transform.GetChild(i).position.x);
                    posN180.x = Mathf.RoundToInt(posN180.x);
                    posN180.y = Mathf.RoundToInt(posN180.y);
                    posN180.z = Mathf.RoundToInt(posN180.z);
                    FindObjectOfType<GridManager>().GridUpdate(posN180, transform.GetChild(i).gameObject);
                    break;
            }
        }
    }
}
