using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int actualLevel;
    private List<Enemy> activeEnemies = new List<Enemy>();
    private List<Collectible> levelCollectibles = new List<Collectible>();

    public void LevelStart()
    {

    }

    public bool EnemiesCleared()
    {
        return false;
    }

    public void NextLevel()
    {
        actualLevel++;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
