using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class LevelSelector : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI levelText;
    private bool init = false;

    private GameBehaviour gameBehaviour;


    private void Start()
    {
        levelText.text = level.ToString();
        gameBehaviour = GameBehaviour.Instance;
    }

    public void OpenScene()
    {
        GameBehaviour.Instance.OpenScene(level);
    }

    public void UpdateStarsDisplay()
    {
        if (!gameBehaviour.IsLevelUnlocked(level))
        {
            Transform locker = transform.GetChild(4);
            locker.gameObject.SetActive(true);
        }
        int starsCount = gameBehaviour.GetStars(level);

        for (int i = 1; i <=3; i++)
        {
            Transform star = transform.GetChild(i);
            star.gameObject.SetActive(false);
        }

        for (int i = 1; i <= starsCount; i++)
        {
            Transform star = transform.GetChild(i);
            star.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (!init)
        {
            UpdateStarsDisplay();
            init= true;
        }
    }

}
