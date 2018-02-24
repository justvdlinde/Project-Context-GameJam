using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera2D : MonoBehaviour {

    float sensitivity = 0.01f;
    private Camera mycam;
 
    void Start() {
        mycam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 vp = mycam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane));
        vp.x -= 0.5f;
        vp.y -= 0.5f;
        vp.x *= sensitivity;
        vp.y *= sensitivity;
        vp.x += 0.5f;
        vp.y += 0.5f;
        Vector3 sp = mycam.ViewportToScreenPoint(vp);

        Vector3 v = mycam.ScreenToWorldPoint(sp);
        transform.LookAt(v, Vector3.up);
    }
}
