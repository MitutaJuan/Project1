using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.0f;

    [SerializeField]
    private int healing = 2;

    private int bleh = 0;

    void Update()
    {
        transform.Translate(0, 0, speed *Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();

        if(player != null)
        {
            player.Heal(healing);
        }

        Destroy(this.gameObject);
    }

    private void Awake()
    {
        StartCoroutine(Despawn());
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSecondsRealtime(5);
        Destroy(this.gameObject);
    }

}
