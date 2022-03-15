using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty
{
    public int gameDifficulty;
    public float stoneSpawnCoefficient;
    public float acidSpanCoefficient;

    Difficulty(int gameDifficulty)
    {
        if(gameDifficulty == 0)
        {
            acidSpanCoefficient = 1.5f;
            stoneSpawnCoefficient = 0.5f;
        }
        if (gameDifficulty == 1)
        {
            acidSpanCoefficient = 1f;
            stoneSpawnCoefficient = 1f;
        }
        if (gameDifficulty == 2)
        {
            acidSpanCoefficient = 0.5f;
            stoneSpawnCoefficient = 1.5f;
        }
    }
}

public enum GameDifficulty
{
    Easy = 0,
    Medium = 1,
    Hard = 2
}
