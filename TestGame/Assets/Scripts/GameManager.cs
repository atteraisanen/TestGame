using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Text timerText;
    [SerializeField] private Text bestTimeText;
    private float timer;
    public float bestTime;

    private void Awake()
    {
        LoadGame();
        bestTimeText.text = bestTime.ToString("F2");
        timer = 0;
    }

    public void UpdateBestTime()
    {
        if(timer > bestTime)
        {
            bestTime = timer;
        }
    }

    private void Update()
    {
        if(PlayerController.isDead == false)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F2");
        }
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();
        if(data != null)
        {
            bestTime = data.bestTime;
        } else
        {
            bestTime = 0f;
        }
    }
}
