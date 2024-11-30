using UnityEngine;
using UnityEngine.UI;  // A Button komponenst innen importáljuk
using UnityEngine.SceneManagement;  // A SceneManager használatához szükséges

public class SceneSwitcher : MonoBehaviour
{   
    [SerializeField]
    protected GameObject  exitGomb;
    [SerializeField]
    protected GameObject  exitGomb2;

    [SerializeField]
    protected int szam;

    void Start()
    {
        if (exitGomb != null)
        {
            Button exitbutton = exitGomb.GetComponent<Button>();
            exitbutton.onClick.AddListener(ChangeScene); 
        }
        if (exitGomb2 != null)
        {
            Button exitbutton = exitGomb2.GetComponent<Button>();
            exitbutton.onClick.AddListener(ChangeScene); 
        }
    }
    // A LoadScene metódus, amit gombnyomásra hívhatsz
    public void ChangeScene()
    {
        // Betölti a megadott nevű jelenetet
        SceneManager.LoadScene(szam);
    }
}