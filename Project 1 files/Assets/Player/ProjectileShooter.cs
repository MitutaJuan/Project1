using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject playerfireballPrefab;

    private GameObject playerfireball;

    private Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
            
                playerfireball = Instantiate(playerfireballPrefab) as GameObject;

                playerfireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                playerfireball.transform.rotation = transform.rotation;
            

        }
    }
}
