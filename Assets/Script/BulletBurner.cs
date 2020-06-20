using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletBurner : MonoBehaviour
{
    [SerializeField] int penalty = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>()) { FindObjectOfType<DollarDisplayer>().SetDollars(FindObjectOfType<DollarDisplayer>().GetDollars() - PenaltySetter(collision));FindObjectOfType<DollarDisplayer>().UpdateDisplay(); if (FindObjectOfType<DollarDisplayer>().GetDollars() < 0) { Die(); } }
        Destroy(collision.gameObject);
    }

    private void Die()
    {
        Debug.LogWarning("You Died!");
        SceneManager.LoadScene("Lose Screen");
    }


    public int PenaltySetter(Collider2D col) 
    {
        
       if(col != null && col.GetComponent<Attacker>().penaltyDMG != 0) {return col.GetComponent<Attacker>().penaltyDMG;} else {return penalty;}
    }
}
