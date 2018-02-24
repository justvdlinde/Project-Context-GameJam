using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkGuy3 : MonoBehaviour {
    private SpriteRenderer SR;
    private Animator anim;
    private Vector3 previous;
    private Vector3 velocity;

    public Renderer Computer;
    public Renderer Discoball;
    public Renderer livLight;
    public Renderer kitLight;
    public Renderer bedLight;
    public Renderer bathLight;

    public GameObject Player;

    public int location;
    // Use this for initialization
    void Start() {
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

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.name == "Bathroom") {
            if (!bathLight.enabled) {
                anim.Play("NPC3_Flip");
                bathLight.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(6);
                bathLight.GetComponent<AudioSource>().Play();
            }
            bathLight.enabled = true;
            location = 0;
        }
        if (col.gameObject.name == "Bedroom") {
            if (!bedLight.enabled) {
                anim.Play("NPC3_Flip");
                bedLight.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(6);
                bedLight.GetComponent<AudioSource>().Play();
            }
            if (!Computer.enabled) {
                Computer.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(15);
                Computer.GetComponent<AudioSource>().Play();
            }
            Computer.enabled = true;
            bedLight.enabled = true;
            location = 1;

        }
        if (col.gameObject.name == "Kitchen") {
            if (!kitLight.enabled) {
                anim.Play("NPC3_Flip");
                kitLight.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(6);
                kitLight.GetComponent<AudioSource>().Play();
            }
            kitLight.enabled = true;
            location = 2;
        }
        if (col.gameObject.name == "Living Room") {
            if (!livLight.enabled) {
                anim.Play("NPC3_Flip");
                livLight.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(6);
                livLight.GetComponent<AudioSource>().Play();
            }
            if(!Discoball.enabled) {
                Discoball.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(3);
                Discoball.GetComponent<AudioSource>().Play();
            }
            Discoball.enabled = true;
            livLight.enabled = true;
            location = 3;
        }
        GetComponent<NPC_AudioManager>().location = location;
    }


}
