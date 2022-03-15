using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager canvasUI = null;

    //public Button startButton;
    //public Button quitButton;
    //public Button returnToGameButton;

    public GameObject mainMenu;
    //public GameObject HUD;
    public GameObject pauseMenu;
    //public GameObject GameOver;
    private void Awake()
    {
        if (canvasUI == null) canvasUI = this;
        else { Destroy(this.gameObject); }
    }
    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void SwitchToGameUI()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void SwitchToTitleUI()
    {
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseMenu.SetActive(!pauseMenu.activeSelf);

                //HUGE HINT FOR THE LAB
                if (pauseMenu.activeSelf)
                {
                    //do something to pause the game
                    Time.timeScale = 0;
                    pauseMenu.SetActive(true);
                }
                else
                {
                    Time.timeScale = 1;
                    pauseMenu.SetActive(false);
                    //unpause the game
                }
            }
        }
    }
    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
        SwitchToTitleUI();
    }

    // Start is called before the first frame update
    public void QuitGame()
    {
        Application.Quit();
    }

}
