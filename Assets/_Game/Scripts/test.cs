using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Base"))
        {
            iTween.MoveFrom(other.gameObject, new Vector3(other.transform.position.x, 2, other.transform.position.z), speed);
            Debug.Log("It Work");
        }
    }

    public void WhenFinish()
    {
        Debug.Log("finish");
        Destroy(gameObject  );
    }
}
