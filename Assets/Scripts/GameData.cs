using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]
public class GameData : MonoBehaviour
{
    public static GameData Instance;
    public int currentLevel;
    

    [SerializeField]  private  LevelData[] levels = new LevelData[5];

    private void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {

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

    public string GetSceneByLevel(int level)
    {
        if (level > 0 && level <= levels.Length)
        {
            return levels[level - 1].sceneName;
        }
        else
        {
            Debug.LogError("Invalid level number");
            return null;
        }
    }

    public void SaveScoreByLevel(int score)
    {
        int savedScore = PlayerPrefs.GetInt("Score_Level_" + currentLevel, 0);
        if(score> savedScore)
        {
            PlayerPrefs.SetInt("Score_Level_" + currentLevel, score);
            PlayerPrefs.Save();
            Debug.LogFormat("Score saved for level {0}: {1}", currentLevel, score);
        }
    }

    public int GetScoreForCurrentLevel()
    {
        int savedScore = PlayerPrefs.GetInt("Score_Level_" + currentLevel, 0);
        Debug.LogFormat("Score for level {0}: {1}", currentLevel, savedScore);
        return savedScore;
    }

    public int GetStarCountByLevel(int level)
    {
        LevelData levelData = levels[level -1];
        int savedScore = PlayerPrefs.GetInt("Score_Level_" + level, 0);
        if (savedScore >= levelData.star1Value && savedScore < levelData.star2Value)
        {
            Debug.LogFormat("Уровень {0}: 1 звезда", level);
            return 1;
        }
        else if (savedScore >= levelData.star2Value && savedScore < levelData.star3Value)
        {
            Debug.LogFormat("Уровень {0}: 2 звезды", level);
            return 2;
        }
        else if (savedScore >= levelData.star3Value)
        {
            Debug.LogFormat("Уровень {0}: 3 звезды", level);
            return 3;
        }
        else
        {
            Debug.LogFormat("Уровень {0}: 0 звезд", level);
            return 0;
        }
    }

    public bool IsLevelUnlocked(int level)
    {
        if (level <= 1)
        {
            Debug.LogFormat("Уровень {0} разблокирован", level);
            return true;
        }

        int previousLevel = level - 1;
        int starsPreviousLevel = GetStarCountByLevel(previousLevel);
        if (starsPreviousLevel > 0)
        {
            Debug.LogFormat("Уровень {0} разблокирован", level);
            return true;
        }
        Debug.LogFormat("Уровень {0} заблокирован", level);
        return false;
    }
} 