using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private CharacterController characterController;

    private GameObject Bad1;
    
    private GameObject Bad2;
    
    private GameObject Bad3;

    private float freeze = 3.0f;
    
    private int health;

    private int PDie;

    void Start()
    {
        health = 25;
        PDie = 1;
    }

    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");
        if(health <= 0)
        {
            Debug.Log("Player has died");
            FPSInput MVMTDisable = GetComponent<FPSInput>();
            MVMTDisable.PlayerDie(PDie);
            MouseLook.horizontalSensitivity = 0.0f;
            MouseLook.verticalSensitivity = 0.0f;
            Bad1 = GameObject.Find("Enemy1(Clone)");
            WanderingAI1 Stop1 = Bad1.GetComponent<WanderingAI1>();
            Stop1.Mercy1(freeze);
            Bad2 = GameObject.Find("Enemy2(Clone)");
            WanderingAI2 Stop2 = Bad2.GetComponent<WanderingAI2>();
            Stop2.Mercy2(freeze);
            Bad3 = GameObject.Find("Enemy3(Clone)");
            WanderingAI3 Stop3 = Bad2.GetComponent<WanderingAI3>();
            Stop3.Mercy3(freeze);
        }
            //Must figure out how to kill player
            //Make it so PDie interacts with FPSInput to shut down player inputs
    }

    public void Heal(int healing)
    {
        health += healing;
        Debug.Log($"Health: {health}");
    }
}
