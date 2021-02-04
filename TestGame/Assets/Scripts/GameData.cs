using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float bestTime;

    public GameData(GameManager gameManager)
    {
        bestTime = gameManager.bestTime;
    }
}
