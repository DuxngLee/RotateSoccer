using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private LevelController level;
    private int             currentLevel = 1;
    
    private void Awake()
    {
        Instance = this;
    }

    public void CompleteLevel()
    {
        this.currentLevel++;
    }

    public void CreateLevel()
    {
        this.level = Instantiate(Resources.Load("")).GetComponent<LevelController>();
    }
    
    public void DestroyLevel()
    {
        if(!this.level) return;
        Destroy(this.level.gameObject);
    }
}
