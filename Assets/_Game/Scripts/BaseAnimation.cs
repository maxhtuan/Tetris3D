using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimation : MonoBehaviour
{
    public string nameGiven;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveFrom(gameObject, iTween.Hash(
            //"position", new Vector3(transform.position.x, 2, transform.position.z),
            "y", 2,
            "time", 1f,
            "easeType", iTween.EaseType.linear

            ));
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
    private void OnTriggerEnter(Collider other)
    {


        iTween.MoveFrom(other.gameObject, iTween.Hash(
            "position", new Vector3(other.transform.position.x, 1, other.transform.position.z),
            "time", 1f,
            "delay", 1f
            ));

        //i++;
        //other.gameObject.name = nameGiven + " " + i;
        //other.gameObject.GetComponent<BaseAnimation>().i += 1;
    }
}
