using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DollarDisplayer : MonoBehaviour
{
    [SerializeField] int dollars = 100;
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        text.text = dollars.ToString();
    }

   public int GetDollars() { return dollars; }
   public void SetDollars(int dollars) { this.dollars = dollars; }
}
