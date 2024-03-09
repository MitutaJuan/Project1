using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy1Prefab;

    [SerializeField]
    private GameObject enemy2Prefab;

    [SerializeField]
    private GameObject enemy3Prefab;

    private GameObject enemy1;

    private GameObject enemy2;

    private GameObject enemy3;

    private GameObject NewEnemy;

    private int spawn;

    private int wave;

    void Start()
    {
        enemy1 = Instantiate(enemy1Prefab) as GameObject;
        wave = 1;
        spawn = 1;

    }

    public void EnemyWave(int deathtrigger)
    {
        {
            //Connect these next few lines to ReactiveTarget so that when the enem(y/ies) die(s), the next wave spawns. See how health and damage interact and do the same with spawn and another variable
            spawn -= deathtrigger;
            if(spawn == 0)
            {
                if(wave == 1)
                {
                    wave = 2;
                    spawn = 2;
                    StartCoroutine(Wave2());
                }

                else if(wave == 2)
                {
                    wave = 3;
                    spawn = 3;
                    StartCoroutine(Wave3());
                }

                else
                {
                    Debug.Log("Player has won!");
                }
            }

        }
    }

    private IEnumerator Wave2()
    {
        yield return new WaitForSecondsRealtime(3);
        enemy1 = Instantiate(enemy2Prefab) as GameObject;
        yield return new WaitForSecondsRealtime(1);
        enemy1 = Instantiate(enemy2Prefab) as GameObject;
                
    }
    
    private IEnumerator Wave3()
    {
        yield return new WaitForSecondsRealtime(3);
        enemy1 = Instantiate(enemy3Prefab) as GameObject;
        yield return new WaitForSecondsRealtime(1);
        enemy1 = Instantiate(enemy3Prefab) as GameObject;
        yield return new WaitForSecondsRealtime(1);
        enemy1 = Instantiate(enemy3Prefab) as GameObject;
        
    }
}
