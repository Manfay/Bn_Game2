using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasValto : MonoBehaviour
{
    [SerializeField] private GameObject canvas1;  // Az első Canvas (amit el akarunk rejteni)
    [SerializeField] private GameObject canvas2;
    public Button myButton;

    [SerializeField]
    protected GameObject Hippo;
    [SerializeField]
    protected GameObject Bolyai;

    void Start()
    {   
        int csapat = PlayerPrefs.GetInt("Csapat", 0);
        Debug.Log("Ezt választottad: "+ csapat);
        if (csapat == 4)
        {
            Bolyai.gameObject.SetActive(true);
        }
        else{
            Hippo.gameObject.SetActive(true);
        }
        // Ellenőrizzük, hogy a gomb nem null
        if (myButton != null)
        {
            myButton.onClick.AddListener(OnButtonClick);
        }
    }

        // Gomb kattintás esemény kezelése
    void OnButtonClick()
    {
        SwitchCanvases();
    }

    public void SwitchCanvases()
    {
        if (canvas1 != null && canvas2 != null)
        {
            bool isCanvas1Active = canvas1.activeSelf;  // Megnézzük, hogy az első Canvas látható-e
            canvas1.SetActive(!isCanvas1Active);  // Ha látható, rejtjük el, ha rejtve, láthatóvá tesszük
            canvas2.SetActive(isCanvas1Active);    // A másik Canvas a fordítottját kapja
        }
    }
}
