using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI2 : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private float obstacleRange = 5.0f;

    [SerializeField]
    private GameObject fireball2Prefab;

    private GameObject fireball2;

    private float LastShot;

    private float TimeBetweenShots = 1.0f;

    private bool isAlive;

    private void Start()
    {
        isAlive = true;
    }

    public void SetAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }

    void Update()
    {
        if(isAlive)
        {
           transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if(Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                if(hitObject.GetComponent<PlayerCharacter>())
                {
                    if(Time.time > LastShot + TimeBetweenShots)
                    {
                        LastShot = Time.time;
                        fireball2 = Instantiate(fireball2Prefab) as GameObject;

                        fireball2.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        fireball2.transform.rotation = transform.rotation;
                    }
                }

                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }
    
    public void Mercy2(float freeze)
    {
        speed -= freeze;
    }
}
