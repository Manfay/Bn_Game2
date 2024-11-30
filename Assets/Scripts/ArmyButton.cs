using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // szükséges a UI elemhez, mint például a Button

public class ArmyButton : MonoBehaviour
{
    // Gomb változó, amelyet az Unity editorban hozzárendelhetsz
    public Button myButton;

    // Indításkor beállítjuk a gomb eseményét
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
        // Kiírjuk, hogy "ready"
        Debug.Log("ready");
    }
}
