﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public GameObject[] levels;

    private int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject level in levels)
        {
            // Making level 1 active when the game starts
            if (level.name.Contains("1"))
            {
                currentLevel = 1;
                level.SetActive(true);
            }
        }
    }

    /// <summary>
    ///  This method can be called to advance to the next level
    /// </summary>

    bool nextLevel()
    {
        // Checking if the current level is below 3
        if (currentLevel < 3)
        {
            // Setting the next level to be active
            currentLevel++;
            foreach (GameObject level in levels)
            {
                
                if (level.name.Contains(currentLevel.ToString()))
                {
                    level.SetActive(true);
                }
                else
                {
                    level.SetActive(false);
                }
            }
        }
    }
}
