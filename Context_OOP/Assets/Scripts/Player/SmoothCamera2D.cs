using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour
{

    private float minFov = 5f;
    private float maxFov = 7.5f;
    private float sensitive = 10f;

    private Camera camera;
    private Vector3 velocity = Vector3.zero;
    public float dampTime = 0.15f;
    public Transform target;
    

    // Update is called once per frame

    private void Start() {
        camera = GetComponent<Camera>();
    }

    void Update() {
        if (target) {
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

            float fov = Camera.main.orthographicSize;
            fov += Input.GetAxis("Mouse ScrollWheel") * sensitive;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.orthographicSize = fov;
        }
    }
}