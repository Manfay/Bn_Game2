using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    
    // A mozgás sebessége
    public int moveSpeed = 1;
    public int myAttack;

    // A sprite-ok tömbje, amit a szamlalo alapján választhatsz
    public Sprite[] spriteOptions;
    // SpriteRenderer, amely az objektum sprite-ját kezeli
    private SpriteRenderer spriteRenderer;

    // A Statok script referencia, hogy elérhessük a sebességet
    public Statok statok;

        // Referencia a ButtonVisibility scripthez
    public ButtonVisibility buttonVisibility;

    void Start()
    {   
        if (buttonVisibility == null)
        {
            buttonVisibility = FindObjectOfType<ButtonVisibility>();
        }
        if (buttonVisibility != null)
        {   
            if (statok == null)
            {
                statok = FindObjectOfType<Statok>();
            }
            if (statok != null)
            {   
                Debug.Log("Szamlalo: " + buttonVisibility.GetSzamlalo());
                if (buttonVisibility.GetSzamlalo() == 0)
                {  
                    moveSpeed = statok.GetSpeed(0); // Például az első sebesség értéket használjuk
                    myAttack = statok.GetAttack(0);
                }
                if (buttonVisibility.GetSzamlalo() == 1)
                {  
                    moveSpeed = statok.GetSpeed(1); // Például az első sebesség értéket használjuk
                    myAttack = statok.GetAttack(1);
                }
                if (buttonVisibility.GetSzamlalo() == 2)
                {  
                    moveSpeed = statok.GetSpeed(2); // Például az első sebesség értéket használjuk
                    myAttack = statok.GetAttack(2);
                }
                if (buttonVisibility.GetSzamlalo() == 3)
                {  
                    moveSpeed = statok.GetSpeed(3); // Például az első sebesség értéket használjuk
                    myAttack = statok.GetAttack(3);
                }
                if (buttonVisibility.GetSzamlalo() == 4)
                {  
                    moveSpeed = statok.GetSpeed(4); // Például az első sebesség értéket használjuk
                    myAttack = statok.GetAttack(4);
                }
            }
                    // Ellenőrizzük, hogy a ButtonVisibility script nincs-e null
        }
        else
        {
            Debug.LogError("Nem található ButtonVisibility komponens a jelenetben!");
        }
        // Ha van Statok script, beállítjuk a mozgás sebességét a statokból

    }

    void Update()
    {   
        // A mozgás vektorja (jobbra, azaz +x irányban)
        Vector3 moveDirection = Vector3.right;  // Jobbra az x tengely mentén

        // Az objektum pozíciójának frissítése
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
