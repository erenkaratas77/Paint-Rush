using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickableObject : MonoBehaviour
{
    public bool isPicked;
    public float index;

    GameObject picker;

    void Start()
    {
        picker = GameObject.FindGameObjectWithTag("picker");
        isPicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.tag == "MainPalette" && isPicked)
        {
            transform.localPosition = new Vector3(0, -index, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            picker.GetComponent<picker>().heightDecrease();
            transform.parent = GameObject.FindGameObjectWithTag("stacked").transform;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;


        }
        else if (other.gameObject.tag=="x's")
        {
            if (picker.GetComponent<picker>().MainPalette.transform.childCount <= 6)
            {
                print("girdi");
                picker.GetComponent<picker>().MainPalette.GetComponent<player>().isFinished = true;

            }
                      
            picker.GetComponent<picker>().heightDecrease();
            transform.parent = GameObject.FindGameObjectWithTag("stacked").transform;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;

            foreach (Rigidbody rigidbody in other.transform.parent.GetComponentsInChildren<Rigidbody>())
            {
                rigidbody.constraints = RigidbodyConstraints.None;
                rigidbody.isKinematic = false;

            }
        }
    }

}
