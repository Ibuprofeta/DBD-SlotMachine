using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkData : MonoBehaviour
{
    public string id;
    public bool active;

    private void Start()
    {
    }

    public void Setup()
    {
        if (!active)
        {
            ColorBlock cb = gameObject.GetComponent<Button>().colors;
            cb.normalColor = Color.black;
            cb.highlightedColor = Color.black;
            cb.pressedColor = Color.white;
            gameObject.GetComponent<Button>().colors = cb;

            active = false;
        }


        else if (active)
        {
            ColorBlock cb = gameObject.GetComponent<Button>().colors;
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
            cb.pressedColor = Color.black;
            gameObject.GetComponent<Button>().colors = cb;

            active = true;
        }
    }
    public void Activate()
    {
        if (active)
        {
            ColorBlock cb = gameObject.GetComponent<Button>().colors;
            cb.normalColor = Color.black;
            cb.highlightedColor = Color.black;
            cb.pressedColor = Color.white;
            gameObject.GetComponent<Button>().colors = cb;

            active = false;
        }
            

        else if (!active)
        {
            ColorBlock cb = gameObject.GetComponent<Button>().colors;
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
            cb.pressedColor = Color.black;
            gameObject.GetComponent<Button>().colors = cb;

            active = true;
        }

        if (GameObject.Find("GameManager").gameObject.GetComponent<EditorScript>().savedPerks)
            GameObject.Find("GameManager").gameObject.GetComponent<EditorScript>().savedPerks = false;
    }
}
