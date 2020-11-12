using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject game;
    public GameObject optionMenu;

    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 0f;

    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
    public void quitButton()
    {
        Application.Quit();

    }
    public void optionButton(){
        this.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
