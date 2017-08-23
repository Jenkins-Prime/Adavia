using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Camera cam;

    [SerializeField]
    private float cameraSpeed;
	void Awake ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cam = GetComponent<Camera>();
	}

    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate ()
    {
        cam.orthographicSize = (Screen.height / 100.0f) / 2.0f; // Maintain scale for resolution;

        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -10), cameraSpeed);
        }
	}
}
