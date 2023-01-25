using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas : MonoBehaviour
{
    picker picker;
    player mainPalette;
    void Start()
    {
        picker = GameObject.FindGameObjectWithTag("picker").GetComponent<picker>();
        mainPalette = GameObject.FindGameObjectWithTag("MainPalette").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainPalette.isFinished)
        {
             if (!picker.isPickedBlue && !picker.isPickedGreen && !picker.isPickedRed)
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (picker.isPickedGreen && picker.isPickedBlue)
            {
                transform.GetChild(2).gameObject.SetActive(true);
            }
           
            else if (picker.isPickedBlue && picker.isPickedGreen && picker.isPickedRed)
            {
                transform.GetChild(0).gameObject.SetActive(true);

            }
        }
    }
}
