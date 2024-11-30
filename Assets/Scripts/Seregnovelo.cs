using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seregnovelo : MonoBehaviour
{
    public Button myButton;

    [SerializeField]
    protected int myKepID;
    public ButtonVisibility buttonVisibility;


    void Start()
    {
        // Ellenőrizzük, hogy a gomb nem null
        if (myButton != null)
        {
            myButton.onClick.AddListener(OnButtonClick);
        }
    }

        // Gomb kattintás esemény kezelése
    void OnButtonClick()
    {
        if (buttonVisibility.VisibleButtonCount <5)
        {
            buttonVisibility.SetVisibleButtonCount(1);
            buttonVisibility.AddkepID(myKepID);
        }
    }
}
