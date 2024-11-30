using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{      
    public Statok statok;
    public ButtonVisibility buttonVisibility;
    public int myAttack;

    [SerializeField]
    protected Slider mySlider;
    public int winSzamlalo = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Itt közvetlenül összehasonlíthatod a másik objektum típusát vagy nevét
        if (collision.gameObject.name == "Square dupla(Clone)")  // Ellenőrzés objektum neve alapján
        {
            Destroy(collision.gameObject);  // Eltünteti ezt az objektumot
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
                    if (buttonVisibility.GetSzamlalo() == 0)
                    {  
                        myAttack = statok.GetAttack(0);
                        if (winSzamlalo <= 50)
                            {
                                winSzamlalo += myAttack;
                                mySlider.value -= myAttack;
                            }
                            Debug.Log(myAttack);
                    }
                    if (buttonVisibility.GetSzamlalo() == 1)
                    {  
                        myAttack = statok.GetAttack(1);
                        if (winSzamlalo <= 50)
                            {
                                winSzamlalo += myAttack;
                                mySlider.value -= myAttack;
                            }
                            Debug.Log(myAttack);
                    }
                
                    if (buttonVisibility.GetSzamlalo() == 2)
                    {  
                        myAttack = statok.GetAttack(2);
                        if (winSzamlalo <= 50)
                            {
                                winSzamlalo += myAttack;
                                mySlider.value -= myAttack;
                            }
                            Debug.Log(myAttack);
                    }
                
                    if (buttonVisibility.GetSzamlalo() == 3)
                    {  
                        myAttack = statok.GetAttack(3);
                        if (winSzamlalo <= 50)
                            {
                                winSzamlalo += myAttack;
                                mySlider.value -= myAttack;
                            }
                            Debug.Log(myAttack);
                    }
                
                    if (buttonVisibility.GetSzamlalo() == 4)
                    {  
                        myAttack = statok.GetAttack(4);
                        if (winSzamlalo <= 50)
                            {
                                winSzamlalo += myAttack;
                                mySlider.value -= myAttack;
                            }
                            Debug.Log(myAttack);
                    }
                
                }
            }
        }
        
    }
}
