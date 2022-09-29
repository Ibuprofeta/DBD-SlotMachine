using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
            QuitApp();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu_Scene");
    }

    public void EditorButton()
    {
        SceneManager.LoadScene("Editor_Scene");
    }

    public void RollButton()
    {
        SceneManager.LoadScene("SM_Scene");
    }

    private void QuitApp()
    {
        Application.Quit();
    }
}
