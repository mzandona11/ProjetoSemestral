using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame() {
        SceneManager.LoadScene("Fase1");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void goToBackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
