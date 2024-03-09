using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireball : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private int damage = 1;

    void Update()
    {
        transform.Translate(0, 0, speed *Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        ReactiveTarget1 target1 = other.GetComponent<ReactiveTarget1>();

        if(target1 != null)
        {
            target1.Hurt(damage);
        }

        ReactiveTarget2 target2 = other.GetComponent<ReactiveTarget2>();

        if(target2 != null)
        {
            target2.Hurt(damage);
        }

        ReactiveTarget3 target3 = other.GetComponent<ReactiveTarget3>();

        if(target3 != null)
        {
            target3.Hurt(damage);
        }

        Destroy(this.gameObject);
    }
}
