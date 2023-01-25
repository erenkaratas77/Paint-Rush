using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class player : MonoBehaviour
{
    public float speed;
    public float boost;

    public bool isFinished;
    public bool scoreTime;
    public bool isDead;

    public LevelManager levelManager;
    public ParticleSystem wind;
    public GameObject cam;

    public AudioSource dead;
    Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        wind.Play();
        GetComponentInChildren<Animator>().SetBool("isStarted", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFinished && !scoreTime && !isDead)
        {
            float horizontal = 0;
            if (Input.GetMouseButtonDown(0))
            {
                mousePosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                horizontal = (Input.mousePosition.x - mousePosition.x) / Screen.width * 1.5f;
                mousePosition = Input.mousePosition;
            }
            boost = Mathf.Clamp(boost + Time.deltaTime * 1f, -2, -1);

            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed * -boost + new Vector3(1, 0, 0) * horizontal * 5;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4f, 4f), transform.position.y, transform.position.z);
        }
        else if(scoreTime)
        {
            transform.DOMoveX(0, 1f);
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;

        }
        else if (isFinished)
        {
            wind.Stop();
            cam.transform.DORotate(new Vector3(7, -6, 0), 2);
            GetComponentInChildren<Animator>().SetBool("isFinished", true);
            levelManager.win();
        }

        else if (isDead)
        {
            GetComponentInChildren<Animator>().SetBool("isDead", true);
            dead.Play();
            wind.Stop();
            levelManager.fail();
            this.enabled = false;
        }
    }
}
