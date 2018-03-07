using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
    public Image fill;
    public Text txt;
    private float time;
	// Use this for initialization
	void Start () {
        time = 60;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        txt.text = (((int)time).ToString());
        fill.fillAmount = time / 60;
	}
}
