using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    [SerializeField]
    private float speed = 6.0f;

    [SerializeField]
    private float gravity = -9.81f;

    private CharacterController characterController;

    private int x;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        x = 1;
    }

    void Update()
    {

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);
        characterController.Move(movement);

        if(x <= 0)
        {
            characterController.enabled = false;
        }
    }

    public void PlayerDie(int PDie)
    {
        x -= PDie;
    }
}
