using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonVisibility : MonoBehaviour
{
    public Statok statok;
    public int seged = 0;
    public int seged2 = 0;
    // A gombok GameObject-jei
    public GameObject[] buttons;
    public GameObject[] Arrows;

    public Destroyer destroyer;

    [SerializeField]
    // jobbklikk gomb
    protected GameObject jobbGomb;

    [SerializeField]
    // balklikk gomb
    protected GameObject  balGomb;

    // jobbklikk gomb
    [SerializeField]
    protected GameObject UPGomb;

    // balklikk gomb
    [SerializeField]
    protected GameObject  DOWNGomb;

        // toborzás gomb
    [SerializeField]
    protected GameObject  recruiterGomb;

    [SerializeField]
    protected GameObject objectToCreatePrefab;

    [SerializeField]
    protected Vector3[] position;
    private Vector3 position0 = new Vector3(-9.5f, 2.5f, 0f);
    private Vector3 position1 = new Vector3(-9.5f, 1f, 0f);
    private Vector3 position2 = new Vector3(-9.5f, -0.5f, 0f);
    private Vector3 position3 = new Vector3(-9.5f, -2f, 0f);

    // A sprite-ok tömbjei (kétszer annyi, mint a gombok)
    public Sprite[] buttonSprites; // Az első sprite sorozat
    public Sprite[] alternateSprites; // A második sprite sorozat (dupla mennyiség)
    public Sprite nyilSprites; 
    public Sprite nyil2Sprites;

    // A sprite-ok tömbje, amit a szamlalo alapján választhatsz
    public Sprite[] spriteOptions;

    [SerializeField]
    // Az aktív gombok száma
    protected int visibleButtonCount = 3;

    public int helper = 3;

    public int szamlalo = 0;
    public List<int> kepIDs = new List<int> ();

    [SerializeField]
    protected int fuggolegesszamlalo = 0;


    private bool recruiterbool = true;

    void Start()
    {   
        int csapat = PlayerPrefs.GetInt("Csapat", 0);
        Debug.Log("Ezt a csapatot választottad: "+ csapat);
        // A gombok láthatóságának beállítása a kívánt szám alapján
        UpdateButtonVisibility();

        if (balGomb != null)
        {
            Button balButton = balGomb.GetComponent<Button>();
            balButton.onClick.AddListener(OnBalGombClick); // Hozzáadjuk az eseményt
        }
        // A jobb gomb eseményét ugyanígy hozzáadhatjuk
        if (jobbGomb != null)
        {
            Button jobbButton = jobbGomb.GetComponent<Button>();
            jobbButton.onClick.AddListener(OnJobbGombClick); // Jobb gombhoz esemény
        }

        if (UPGomb != null)
        {
            Button UPbutton = UPGomb.GetComponent<Button>();
            UPbutton.onClick.AddListener(OnUpClick); // Up gombhoz esemény
        }

        if (DOWNGomb != null)
        {
            Button Downbutton = DOWNGomb.GetComponent<Button>();
            Downbutton.onClick.AddListener(OnDownClick); // Up gombhoz esemény
        }

        if (recruiterGomb != null)
        {
            Button recruitGomb = recruiterGomb.GetComponent<Button>();
            recruitGomb.onClick.AddListener(recruiter); // Up gombhoz esemény
        }
    }

    // A gombok láthatóságának frissítése és sprite cseréje
    void UpdateButtonVisibility()
    {
        for (int i = 0; i < 3; i++)
        {
            bool isVisible = i < visibleButtonCount;
            buttons[i].GetComponent<RectTransform>().localPosition = position[i];
            buttons[i].SetActive(isVisible);  // Ha a gomb látható, akkor aktiváljuk

            // Ha látható a gomb, akkor sprite-ot rendelünk hozzá
            if (isVisible)
            {
                Button buttonComponent = buttons[i].GetComponent<Button>();
                if (buttonComponent != null)
                {
                    Image buttonImage = buttonComponent.GetComponent<Image>();
                    if (buttonImage != null)
                    {       
                            if (i == 0)
                            {
                                buttonImage.sprite = alternateSprites[0];
                            }
                        // Kiválasztjuk, hogy melyik sprite-ot alkalmazzuk a gombra
                            else if (i < buttonSprites.Length)
                            {
                                buttonImage.sprite = buttonSprites[i]; // Alap sprite
                            }
                        
                    }
                }
            }
        }
    }

    // A bal gomb kattintásának kezelése
    void OnBalGombClick()
    {
        if (szamlalo >= 1)
        {
            szamlalo -= 1;
            buttons[szamlalo].GetComponent<Button>().GetComponent<Image>().sprite = alternateSprites[szamlalo];
            buttons[szamlalo+1].GetComponent<Button>().GetComponent<Image>().sprite = buttonSprites[szamlalo+1];
        }
        else{
            szamlalo = visibleButtonCount-1;
            buttons[szamlalo].GetComponent<Button>().GetComponent<Image>().sprite = alternateSprites[szamlalo];
            buttons[0].GetComponent<Button>().GetComponent<Image>().sprite = buttonSprites[0];
        }
    }

    // A jobb gomb kattintásának kezelése
    void OnJobbGombClick()
    {
        if (szamlalo < visibleButtonCount-1)
        {
            szamlalo += 1;
            buttons[szamlalo].GetComponent<Button>().GetComponent<Image>().sprite = alternateSprites[szamlalo];
            buttons[szamlalo-1].GetComponent<Button>().GetComponent<Image>().sprite = buttonSprites[szamlalo-1];
        }
        else{
            szamlalo = 0;
            buttons[szamlalo].GetComponent<Button>().GetComponent<Image>().sprite = alternateSprites[szamlalo];
            buttons[visibleButtonCount-1].GetComponent<Button>().GetComponent<Image>().sprite = buttonSprites[visibleButtonCount-1];
        }
    }

    void OnUpClick()
    {
        if (fuggolegesszamlalo > 0)
        {
            fuggolegesszamlalo -= 1;
            Arrows[fuggolegesszamlalo].GetComponent<Image>().GetComponent<Image>().sprite = nyil2Sprites;
            Arrows[fuggolegesszamlalo+1].GetComponent<Image>().GetComponent<Image>().sprite = nyilSprites;
        }
        else{
            fuggolegesszamlalo = 3;
            Arrows[fuggolegesszamlalo].GetComponent<Image>().GetComponent<Image>().sprite = nyil2Sprites;
            Arrows[0].GetComponent<Image>().GetComponent<Image>().sprite = nyilSprites;
        }
    }
    void OnDownClick()
    {
        if (fuggolegesszamlalo < 3)
        {
            fuggolegesszamlalo += 1;
            Arrows[fuggolegesszamlalo].GetComponent<Image>().GetComponent<Image>().sprite = nyil2Sprites;
            Arrows[fuggolegesszamlalo-1].GetComponent<Image>().GetComponent<Image>().sprite = nyilSprites;
        }
        else{
            fuggolegesszamlalo = 0;
            Arrows[fuggolegesszamlalo].GetComponent<Image>().GetComponent<Image>().sprite = nyil2Sprites;
            Arrows[3].GetComponent<Image>().GetComponent<Image>().sprite = nyilSprites;
        }
    }
    void recruiter()
    {
        if (fuggolegesszamlalo == 0)
        {
            GameObject newObject = Instantiate(objectToCreatePrefab, position0, Quaternion.identity);
            newObject.AddComponent<MoveObject>();
            SpriteRenderer spriteRenderer = newObject.GetComponent<SpriteRenderer>();
            if (szamlalo == 0)
            {
                spriteRenderer.sprite = spriteOptions[0];
            }
            if (szamlalo == 1)
            {
                spriteRenderer.sprite = spriteOptions[1];
            }
            if (szamlalo == 2)
            {
                spriteRenderer.sprite = spriteOptions[2];
            }
            if (szamlalo == 3)
            {
                spriteRenderer.sprite = spriteOptions[3];
            }
            if (szamlalo == 4)
            {
                spriteRenderer.sprite = spriteOptions[4];
            }
        }
        if (fuggolegesszamlalo == 1)
        {
            GameObject newObject = Instantiate(objectToCreatePrefab, position1, Quaternion.identity);
            newObject.AddComponent<MoveObject>();
            SpriteRenderer spriteRenderer = newObject.GetComponent<SpriteRenderer>();
            if (szamlalo == 0)
            {
                spriteRenderer.sprite = spriteOptions[0];
            }
            if (szamlalo == 1)
            {
                spriteRenderer.sprite = spriteOptions[1];
            }
            if (szamlalo == 2)
            {
                spriteRenderer.sprite = spriteOptions[2];
            }
            if (szamlalo == 3)
            {
                spriteRenderer.sprite = spriteOptions[3];
            }
            if (szamlalo == 4)
            {
                spriteRenderer.sprite = spriteOptions[4];
            }
        }
        if (fuggolegesszamlalo == 2)
        {
            GameObject newObject = Instantiate(objectToCreatePrefab, position2, Quaternion.identity);
            newObject.AddComponent<MoveObject>();
            SpriteRenderer spriteRenderer = newObject.GetComponent<SpriteRenderer>();
            if (szamlalo == 0)
            {
                spriteRenderer.sprite = spriteOptions[0];
            }
            if (szamlalo == 1)
            {
                spriteRenderer.sprite = spriteOptions[1];
            }
            if (szamlalo == 2)
            {
                spriteRenderer.sprite = spriteOptions[2];
            }
            if (szamlalo == 3)
            {
                spriteRenderer.sprite = spriteOptions[3];
            }
            if (szamlalo == 4)
                        {
                spriteRenderer.sprite = spriteOptions[4];
            }
        }
        if (fuggolegesszamlalo == 3)
        {   
            GameObject newObject = Instantiate(objectToCreatePrefab, position3, Quaternion.identity);
            newObject.AddComponent<MoveObject>();
            SpriteRenderer spriteRenderer = newObject.GetComponent<SpriteRenderer>();
            if (szamlalo == 0)
            {
                spriteRenderer.sprite = spriteOptions[0];
            }
            if (szamlalo == 1)
            {
                spriteRenderer.sprite = spriteOptions[1];
            }
            if (szamlalo == 2)
            {
                spriteRenderer.sprite = spriteOptions[2];
            }
            if (szamlalo == 3)
            {
                spriteRenderer.sprite = spriteOptions[3];
            }
            if (szamlalo == 4)
            {
                spriteRenderer.sprite = spriteOptions[4];
            }
        }
    }

    public int GetSzamlalo()
    {
        return szamlalo;
    }

    // Getter: Visszaadja a visibleButtonCount értékét
    public int VisibleButtonCount
    {
        get { return visibleButtonCount; }
    }

    // Setter: Beállítja a visibleButtonCount új értékét
    public void SetVisibleButtonCount(int newCount)
    {
        visibleButtonCount += newCount;
    }
    public void AddkepID(int newElement)
    {
        kepIDs.Add(newElement);
        Debug.Log("Új elem hozzáadva: " + newElement);
    }

    private void Update() 
    {
        if (visibleButtonCount > 0)
        {
            if (VisibleButtonCount != helper)
            {
                UpdateButtonVisibility2();
            }
        }
        if (destroyer.winSzamlalo >= 50)
        {
            Debug.Log("Win");
        }
    }

    private void UpdateButtonVisibility2()
    {   
        if (recruiterbool == true)
        {   
            helper = VisibleButtonCount;
            // Ellenőrizzük, hogy az indexek nem haladják meg a lista hosszát
            if (helper-1 < buttons.Length && helper-1 < buttonSprites.Length && helper-1 < alternateSprites.Length)
                {
                Button buttonComponent = buttons[5].GetComponent<Button>();
                if (buttonComponent != null)
                {
                    Image buttonImage = buttonComponent.GetComponent<Image>();
                    if (buttonImage != null)
                    {       
                        seged = statok.GetSpeed(helper-1);
                        buttonImage.sprite = buttonSprites[helper-1]; // Alap sprite
                        alternateSprites[5] = alternateSprites[helper-1];
                        buttonSprites[5] = buttonSprites[helper-1];
                        spriteOptions[5] = spriteOptions[helper-1];
                        statok.SetSpeed(5,seged);
                    }
                }
                buttonComponent = buttons[helper-1].GetComponent<Button>();
                if (buttonComponent != null)
                {
                    Image buttonImage = buttonComponent.GetComponent<Image>();
                    if (buttonImage != null)
                    {       
                        seged = helper-1;
                        seged2 = statok.GetSpeed(kepIDs[0]);
                        buttonImage.sprite = buttonSprites[kepIDs[0]]; // Alap sprite
                        alternateSprites[helper-1] = alternateSprites[kepIDs[0]];
                        buttonSprites[helper-1] = buttonSprites[kepIDs[0]];
                        spriteOptions[helper-1] = spriteOptions[kepIDs[0]];
                        statok.SetSpeed(seged,seged2);
                    }
                }       
                buttons[helper-1].SetActive(true); 
                recruiterbool = false; 
                }
            else
            {
                Debug.LogWarning("Az indexek érvénytelenek. Ellenőrizd a lista méretét.");
            }
        }
        else
        {
            helper = VisibleButtonCount;
            if (helper-1 < buttons.Length && helper-1 < buttonSprites.Length && helper-1 < alternateSprites.Length)
                {
                Button buttonComponent = buttons[helper-1].GetComponent<Button>();
                if (buttonComponent != null)
                    {
                        Image buttonImage = buttonComponent.GetComponent<Image>();
                        if (buttonImage != null)
                        {       
                            if ( buttonSprites[5] !=  buttonSprites[helper-2])
                            {   
                                seged = helper-1;
                                seged2 = statok.GetSpeed(5);
                                Debug.Log(helper);
                                Debug.Log(seged + "   " + seged2);
                                buttonImage.sprite = buttonSprites[5]; // Alap sprite
                                alternateSprites[helper-1] = alternateSprites[5];
                                buttonSprites[helper-1] = buttonSprites[5];
                                spriteOptions[helper-1] = spriteOptions[5];
                                statok.SetSpeed(seged,seged2);
                            }
                            else
                            {
                                seged = statok.GetSpeed(helper-1);
                                seged2 = statok.GetSpeed(kepIDs[1]);
                                Debug.Log(seged + seged2);
                                buttonImage.sprite = buttonSprites[kepIDs[1]]; // Alap sprite
                                alternateSprites[helper-1] = alternateSprites[kepIDs[1]];
                                buttonSprites[helper-1] = buttonSprites[kepIDs[1]];
                                spriteOptions[helper-1] = spriteOptions[kepIDs[1]];
                                statok.SetSpeed(seged,seged2);
                            }
                        }
                    }
                buttons[helper-1].SetActive(true);
                }
            else
                {
                    Debug.LogWarning("Az indexek érvénytelenek. Ellenőrizd a lista méretét.");
                }
        }
    }
}
