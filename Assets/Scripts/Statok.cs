using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Statok : MonoBehaviour
{
    [SerializeField]
    protected int[] speed;

    [SerializeField]
    protected int[] attack;

    public int GetSpeed(int index)
    {
        if (index >= 0 && index < speed.Length)
        {
            return speed[index];
        }
        return 0;  // Ha érvénytelen index, visszaadjuk a 0-t
    }
    public void SetSpeed(int index, int newCount)
    {
        if (index >= 0 && index < speed.Length)
        {
            speed[index] = newCount;
        }
    }

    public int GetAttack(int index)
    {
        if (index >= 0 && index < attack.Length)
        {
            return attack[index];
        }
        return 0;  // Ha érvénytelen index, visszaadjuk a 0-t
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ellenőrizzük, hogy mindkét objektum rendelkezik-e a 'Fighter' taggel
        if (gameObject.CompareTag("Fighter") && collision.gameObject.CompareTag("Fighter"))
        {
            // Ha mindkét objektum 'Fighter' taggel rendelkezik, letiltjuk az ütközést
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }
}
