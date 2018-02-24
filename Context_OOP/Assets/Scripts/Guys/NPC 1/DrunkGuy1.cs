using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkGuy1 : MonoBehaviour {
    private SpriteRenderer SR;
    private Animator anim;
    private Vector3 previous;
    private Vector3 velocity;

    public Renderer TV;
    public Renderer Microwave;
    public Renderer livLight;
    public Renderer kitLight;
    public Renderer bedLight;
    public Renderer bathLight;

    public GameObject Player;

    public int location;

    // Use this for initialization
    void Start () {
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        location = 0;
	}

    private void Update() {
        velocity = (transform.position - previous) / Time.deltaTime;
        previous = transform.position;
            if (velocity.x < 0f) {
                SR.flipX = false;
            }
            if (velocity.x > 0f) {
                SR.flipX = true;
            }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Bathroom") {
            if (!bathLight.enabled) {
                anim.Play("NPC1_Flip");
                bathLight.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(6);
                bathLight.GetComponent<AudioSource>().Play();
            }
            bathLight.enabled = true;
            location = 0;

        }
        if (col.gameObject.name == "Bedroom") {
            if (!bedLight.enabled) {
                bedLight.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(6);
                bedLight.GetComponent<AudioSource>().Play();
                anim.Play("NPC1_Flip");
            }
            bedLight.enabled = true;
            location = 1;
        }
        if (col.gameObject.name == "Kitchen") {
            if (!kitLight.enabled) {
                anim.Play("NPC1_Flip");
                kitLight.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(6);
                kitLight.GetComponent<AudioSource>().Play();
            }
            if (!Microwave.enabled) {
                Microwave.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(8);
                Microwave.GetComponent<AudioSource>().Play();
            }
            Microwave.enabled = true;
            kitLight.enabled = true;
            Player.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(13);
            Player.GetComponent<AudioSource>().Play();
            location = 2;
        }
        if (col.gameObject.name == "Living Room") {
            if (!livLight.enabled) {
                anim.Play("NPC1_Flip");
                livLight.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(6);
                livLight.GetComponent<AudioSource>().Play();
            }
            if (!TV.enabled) {
                TV.GetComponent<AudioSource>().Play();
            }
            TV.enabled = true;
            livLight.enabled = true;
            location = 3;

        }
        GetComponent<NPC_AudioManager>().location = location;
    }

}
