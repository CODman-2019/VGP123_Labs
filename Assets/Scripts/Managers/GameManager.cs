using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public int startingLives;
    public int playerLives;

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


        playerLives = startingLives;
    }

    public void StartGame()
    {
        playerLives = startingLives;
        SceneManager.LoadScene("Level");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
