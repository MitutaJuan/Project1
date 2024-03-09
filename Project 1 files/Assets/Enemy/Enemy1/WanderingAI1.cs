using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI1 : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private float obstacleRange = 5.0f;

    [SerializeField]
    private GameObject fireball1Prefab;

    private GameObject fireball1;

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
                        fireball1 = Instantiate(fireball1Prefab) as GameObject;

                        fireball1.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        fireball1.transform.rotation = transform.rotation;
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

    public void Mercy1(float freeze)
    {
        speed -= freeze;
    }
}
