using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Csapatvalaszto : MonoBehaviour
{   
    [SerializeField]
    protected GameObject[] buttons;
 
    [SerializeField]
    protected Button felugroablak;

    [SerializeField]
    protected Button nemGomb;

    [SerializeField]
    protected Button igenGomb;

    private int csapat = 0;

    void Start()
    {
        for (int i = 0; i < 6; i++)
        {   
            int index = i;
            Button buttonComponent = buttons[i].GetComponent<Button>();
            if (buttonComponent != null) // Ellenőrzés, hogy van-e Button komponens
            {
                buttonComponent.onClick.AddListener(() => OnClick(index));
            }
            else
            {
                Debug.LogWarning($"GameObject nem tartalmaz Button komponenst!");
            }
        }
        Button nemButton = nemGomb.GetComponent<Button>();
        if (nemButton != null) // Ellenőrzés, hogy van-e Button komponens
            {
                nemButton.onClick.AddListener(Nemklikk);
            }
        else
            {
                Debug.LogWarning("A GameObject nem tartalmaz Button komponenst!");
            }
        Button igenButton = igenGomb.GetComponent<Button>();
        if (igenButton != null) // Ellenőrzés, hogy van-e Button komponens
            {
                igenButton.onClick.AddListener(Igenklikk);
            }
        else
            {
                Debug.LogWarning("A GameObject nem tartalmaz Button komponenst!");
            }
    }

    void OnClick(int help)
    {      
        // Lekérjük a gomb gyermekében lévő Text komponenst
        Text buttonText = felugroablak.GetComponentInChildren<Text>();
        felugroablak.gameObject.SetActive(true);
        if (help == 0)
        {
            if (buttonText != null)
            {
                buttonText.text = "Biztosan az Anonim Klubbot választod?";
            }
            csapat = help;
        }
        if (help == 1)
        {
            if (buttonText != null)
            {
                buttonText.text = "Biztosan az Dokk Klubbot választod?";
            }
            csapat = help;
        }
        if (help == 2)
        {
            if (buttonText != null)
            {
                buttonText.text = "Biztosan az My Klubbot választod?";
            }
            csapat = help;
        }
        if (help == 3)
        {
            if (buttonText != null)
            {
                buttonText.text = "Biztosan az 89 Klubbot választod?";
            }
            csapat = help;
        }
        if (help == 4)
        {
            if (buttonText != null)
            {
                buttonText.text = "Biztosan az Bolyai Klubbot választod?";
            }
            csapat = help;
        }
        if (help == 5)
        {
            if (buttonText != null)
            {
                buttonText.text = "Biztosan az Hippo Klubbot választod?";
            }
            csapat = help;
        }
    }

    void Nemklikk()
    {
        Debug.Log("Nem");
        felugroablak.gameObject.SetActive(false);
    }

    void Igenklikk()
    {
        PlayerPrefs.SetInt("Csapat", csapat);
        Debug.Log("Igen");
    }
}
