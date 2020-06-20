using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColourManipulator : MonoBehaviour
{
    Slider slider;
    Image Colorer = null;
    const string FILL_NAME = "Fill";

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
       foreach (Image colorBeingInterrogated in gameObject.GetComponentsInChildren<Image>())
        {
            if (colorBeingInterrogated.gameObject.name == FILL_NAME) { Colorer = colorBeingInterrogated; }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < 3 ) { Colorer.color = Color.cyan; }
        else if (4 > slider.value && slider.value > 2) { Colorer.color = new Color (0.9725f,1f,0f,255f); }
        else if (slider.value < 5) { Colorer.color = Color.red; }
        else if (slider.value == 5) { Colorer.color = new Color(0.5f,0f,0f,255f) ; }
    }
}
