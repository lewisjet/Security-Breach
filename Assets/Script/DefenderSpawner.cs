using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefenderSpawner : MonoBehaviour
{
   Defender defender = null;
   GameObject shadow = null;
    DollarDisplayer dollarDisplayer;
    GameObject defenderParent = null;
    const string DEFENDER_PARENT_NAME = "Defenders";
 

    private void OnMouseOver()
    {
       
       SpawnShadow(GetSquareClicked());
    }

    private void OnMouseDown()
    {
     //   Debug.Log("Mouse pressed down!");
        SpawnDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
     return new Vector2  ( Mathf.RoundToInt(rawWorldPos.x),Mathf.RoundToInt(rawWorldPos.y));
    }


    private void SpawnDefender(Vector2 worldPos)
    {
        if (defender)
        {
            Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
            if (newDefender.GiveCost() > dollarDisplayer.GetDollars()) { Destroy(newDefender.gameObject); }
           else { dollarDisplayer.SetDollars(dollarDisplayer.GetDollars() - newDefender.GiveCost()); }
            dollarDisplayer.UpdateDisplay();

            newDefender.transform.parent = defenderParent.transform;
        }
    }

    private void SpawnShadow(Vector2 worldPos)
    { if (shadow)
        {
            GameObject newShadow = Instantiate(shadow, worldPos, Quaternion.identity) as GameObject;
            StartCoroutine(KillShadow(newShadow));
        }
    }

    IEnumerator KillShadow(GameObject shadow)
    {
        yield return new WaitForEndOfFrame();
        Destroy(shadow);
    }

  public  void Setup(Defender defender, GameObject shadow)
    {
        this.defender = defender;
        this.shadow = shadow;

    }

    private void Start()
    {
        dollarDisplayer = FindObjectOfType<DollarDisplayer>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        if (GameObject.Find(DEFENDER_PARENT_NAME)) { defenderParent = GameObject.Find(DEFENDER_PARENT_NAME); }
        else { Debug.LogError("Null reference exeption: DEFENDER_PARENT_NAME != Existing GameObject!"); }
    }
}
