using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget3 : MonoBehaviour
{
    [SerializeField]
    private GameObject healthkitprefab;

    private GameObject healthkit;
    
    private GameObject pointspawn;

    private int health;

    private int deathtrigger;

    void Start()
    {
        health = 3;
        deathtrigger = 1;
    }

    public void Hurt(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            WanderingAI3 behavior = GetComponent<WanderingAI3>();
            if(behavior != null)
            {
                behavior.SetAlive(false);
            }
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        healthkit = Instantiate(healthkitprefab) as GameObject;
        healthkit.transform.position = transform.TransformPoint(Vector3.down * 0.5f);
        healthkit.transform.rotation = transform.rotation;

        //So in order to connect two scripts that are on two separate objects, you must use the GameObject.Find command first, and then use GetComponent
        pointspawn = GameObject.Find("SpawnPoint");

        EnemySpawn DEATH = pointspawn.GetComponent<EnemySpawn>();

        DEATH.EnemyWave(deathtrigger);

        Destroy(this.gameObject);
    }
}
