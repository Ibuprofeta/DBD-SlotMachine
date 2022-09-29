using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour
{
    public string id;
    public string role;
    public bool active;

    public void Setup()
    {
        if (!active)
        {
            ColorBlock cb = gameObject.GetComponent<Button>().colors;
            cb.normalColor = new Color32(255, 255, 255, 125);
            cb.highlightedColor = new Color32(255, 255, 255, 125);
            cb.pressedColor = new Color32(200, 200, 200, 255);
            gameObject.GetComponent<Button>().colors = cb;

            active = false;
        }


        else if (active)
        {
            ColorBlock cb = gameObject.GetComponent<Button>().colors;
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
            cb.pressedColor = new Color32 (200, 200, 200, 255);
            gameObject.GetComponent<Button>().colors = cb;

            active = true;
        }
    }
    public void Activate()
    {
        if (active)
        {
            ColorBlock cb = gameObject.GetComponent<Button>().colors;
            cb.normalColor = new Color32(255, 255, 255, 125);
            cb.highlightedColor = new Color32(255, 255, 255, 125);
            cb.pressedColor = new Color32(200, 200, 200, 255);
            gameObject.GetComponent<Button>().colors = cb;

            active = false;
        }


        else if (!active)
        {
            ColorBlock cb = gameObject.GetComponent<Button>().colors;
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
            cb.pressedColor = new Color32(200, 200, 200, 255);
            gameObject.GetComponent<Button>().colors = cb;

            active = true;
        }
    }
}
