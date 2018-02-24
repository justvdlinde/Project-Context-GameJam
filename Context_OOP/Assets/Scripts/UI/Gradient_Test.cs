using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gradient_Test : MonoBehaviour {

    public Gradient gradient;

    [Range(0, 1)]
    public float t;

    private Image img;

	// Use this for initialization
	void Start () {
        img = transform.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        img.color = gradient.Evaluate(t);
	}
}
