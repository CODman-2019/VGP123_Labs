using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public int startingLives;
    public int playerLives;
    public AudioClip titleMusic;
    public AudioClip levelMusic;
    public AudioClip gameOverMusic;
    public AudioClip victoryClip;
    AudioSource musicPlayer;
    

    // Start is called before the first frame update
    void Awake()
    {
        if (manager)
        {
            Destroy(gameObject);
        }
        else
        {
            manager = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        if(startingLives < 0)
        {
            startingLives = 3;
        }
        musicPlayer = gameObject.GetComponent<AudioSource>();
        musicPlayer.clip = titleMusic;
        musicPlayer.loop = true;
        musicPlayer.Play();
        playerLives = startingLives;
    }

    public void StartGame()
    {
        playerLives = startingLives;
        SceneManager.LoadScene("Level");
        CanvasManager.canvasUI.SwitchToGameUI();
        CanvasManager.canvasUI.UpdateHUD();
        musicPlayer.clip = levelMusic;
        musicPlayer.loop = true;
        musicPlayer.Play();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("TitleScreen");
        CanvasManager.canvasUI.SwitchToTitleUI();
        musicPlayer.clip = titleMusic;
        musicPlayer.loop = true;
        musicPlayer.Play();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        CanvasManager.canvasUI.SwitchToGameOver();
        musicPlayer.clip = gameOverMusic;
        musicPlayer.loop = false;
        musicPlayer.Play();
    }
    public void Victory()
    {
        SceneManager.LoadScene("WinScreen");
        musicPlayer.clip = victoryClip;
        musicPlayer.loop = false;
        musicPlayer.Play();
        CanvasManager.canvasUI.SwitchToTitleUI();
    }
}
