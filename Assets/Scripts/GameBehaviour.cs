using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public static GameBehaviour Instance;
    private int _itemsCollected = 0;
    private GameData gameData;
    private bool init = false;

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            Debug.LogFormat("You have {0} points", _itemsCollected);
        }
    }
    private void Awake()
    {
        MakeSingleton();

    }
    private void Start()
    {
        gameData = GameData.Instance;
    }

    private void MakeSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OpenScene(int level)
    {
        string sceneName = gameData.GetSceneByLevel(level);
        if (sceneName != null)
        {
            if(gameData.IsLevelUnlocked(level))
            {
                gameData.currentLevel = level;
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            Debug.LogError("Scene name is null. Failed to load scene.");
        }
    }

    private void Update()
    {
        if (_itemsCollected >= 3)
        {
            gameData.SaveScoreByLevel(_itemsCollected);
        }
    }

    public int GetStars(int level)
    {
        return gameData.GetStarCountByLevel(level);
    }

    public bool IsLevelUnlocked(int level)
    {
        if (gameData.IsLevelUnlocked(level))
        {
            return true;
        }
        return  false;
    }
}

