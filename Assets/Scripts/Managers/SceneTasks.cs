using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTasks : MonoBehaviour
{
    public SceneType type;
    public enum SceneType
    {
        Title,
        GameOver,
        Victory
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case SceneType.Title:
                if (Input.GetKeyDown(KeyCode.Space))
                    GameManager.manager.StartGame();
                break;
            case SceneType.GameOver:
                if (Input.GetKeyDown(KeyCode.Escape))
                    GameManager.manager.RestartGame();
                break;
            case SceneType.Victory:
                if (Input.GetKeyDown(KeyCode.Escape))
                    GameManager.manager.RestartGame();
                break;
        }
    }
}
