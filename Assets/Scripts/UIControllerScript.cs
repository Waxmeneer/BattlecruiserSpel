using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIControllerScript : MonoBehaviour {

    public Button pauseButton;

    void Start()
    {

    }

    // Calls the pausebutton onclick on spacebar press
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pauseButton.onClick.Invoke();
        }
    }
}
