using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picker : MonoBehaviour
{
    public GameObject MainPalette;
    public GameObject[] palettes;
    float height=0;
    float index;

    public AudioSource paint;
    public AudioSource palette;
    public AudioSource obs;
    public AudioSource breakSound;

    public bool isPickedRed;
    public bool isPickedGreen;
    public bool isPickedBlue;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        MainPalette.transform.position = new Vector3(transform.position.x, 0.125f+ height, transform.position.z);
        transform.localPosition = new Vector3(0, -index, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pickable" && other.gameObject.GetComponent<pickableObject>().isPicked == false)
        {
            height += .2f;
            index += 0.04f;
            other.gameObject.GetComponent<pickableObject>().isPicked = true;
            other.gameObject.GetComponent<pickableObject>().index = index;
            other.gameObject.transform.parent = MainPalette.transform;
            MainPalette.GetComponent<player>().boost = -2;
            palette.Play();
        }
        
        


        
        if (other.gameObject.tag == "red")
        {
            isPickedRed = true;
            palettes = GameObject.FindGameObjectsWithTag("pickable");
            paint.Play();

            for(int i = 0; i < palettes.Length; i++)
            {
                palettes[i].transform.GetChild(0).gameObject.SetActive(true);
            }
            MainPalette.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "green")
        {
            isPickedGreen = true;
            palettes = GameObject.FindGameObjectsWithTag("pickable");
            paint.Play();

            for (int i = 0; i < palettes.Length; i++)
            {
                palettes[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            MainPalette.transform.GetChild(1).gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "blue")
        {
            isPickedBlue = true;
            palettes = GameObject.FindGameObjectsWithTag("pickable");
            paint.Play();

            for (int i = 0; i < palettes.Length; i++)
            {
                palettes[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            MainPalette.transform.GetChild(2).gameObject.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "score")
        {
            MainPalette.GetComponent<player>().scoreTime = true;
        }
        if (other.gameObject.tag == "Finish")
        {
            MainPalette.GetComponent<player>().scoreTime = false;
            MainPalette.GetComponent<player>().isFinished = true;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle" && (MainPalette.transform.childCount <= 6))
        {
            MainPalette.GetComponent<player>().isDead = true;
        }
        if (collision.gameObject.tag == "x's" && MainPalette.transform.childCount <= 6)
        {
            MainPalette.GetComponent<player>().isFinished = true;

        }

    }
    public void heightDecrease()
    {
        height -= 0.2f;
        index -= 0.04f;
        if (MainPalette.GetComponent<player>().scoreTime)
        {
            breakSound.Play();
        }
        else
        {
            obs.Play();

        }
    }
}
