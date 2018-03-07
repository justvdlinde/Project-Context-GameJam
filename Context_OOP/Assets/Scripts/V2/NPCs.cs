using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCs : MonoBehaviour {

    protected Animator anim;
    protected Vector3 previous;
    protected Vector3 velocity;

    protected Renderer TV;
    protected Renderer Microwave;
    protected Renderer Charger;
    protected Renderer Computer;
    protected Renderer Discoball;
    protected Renderer Radio;

    protected Renderer livLight;
    protected Renderer kitLight;
    protected Renderer bedLight;
    protected Renderer bathLight;

    protected GameObject player;

    public int location;

    public enum Device1 {
        TV,
        Microwave,
        Discoball,
        Radio,
        Computer,
        Charger
    };

    public enum Device2 {
        Charger,
        Computer,
        Radio,
        Discoball,
        Microwave,
        TV
    };

    public Device1 activeDevice1;
    public Device2 activeDevice2;

    // Use this for initialization
    protected void Start () {
        TV = GameObject.Find("TV").GetComponent<Renderer>();
        Microwave = GameObject.Find("Microwave").GetComponent<Renderer>();
        Charger = GameObject.Find("Charger").GetComponent<Renderer>();
        Computer = GameObject.Find("Screen 1").GetComponent<Renderer>();
        Radio = GameObject.Find("Radio").GetComponent<Renderer>();
        livLight = GameObject.Find("LivingroomLight").GetComponent<Renderer>();
        kitLight = GameObject.Find("KitchenLight").GetComponent<Renderer>();
        bedLight = GameObject.Find("BedroomLight").GetComponent<Renderer>();
        bathLight = GameObject.Find("BathroomLight").GetComponent<Renderer>();
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	protected void Update () {
        velocity = (transform.position - previous) / Time.deltaTime;
        previous = transform.position;
        if (velocity.x < 0f) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (velocity.x > 0f) {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    protected virtual void OnTriggerEnter(Collider col) {
        if (col.gameObject.name == "Bathroom") {
            if (!bathLight.enabled) {
                anim.Play("Flip");
                bathLight.GetComponent<AudioSource>().clip = player.GetComponent<AudioManager>().GetClip(6);
                bathLight.GetComponent<AudioSource>().Play();
            }
            bathLight.enabled = true;
            location = 0;
        }

        if (col.gameObject.name == "Bedroom") {
            if (!bedLight.enabled) {
                anim.Play("Flip");
                bedLight.GetComponent<AudioSource>().clip = player.GetComponent<AudioManager>().GetClip(6);
                bedLight.GetComponent<AudioSource>().Play();

            }
            bedLight.enabled = true;
            location = 1;
        }

        if (col.gameObject.name == "Kitchen") {
            if (!kitLight.enabled) {
                anim.Play("Flip");
                kitLight.GetComponent<AudioSource>().clip = player.GetComponent<AudioManager>().GetClip(6);
                kitLight.GetComponent<AudioSource>().Play();
            }
            kitLight.enabled = true;
            player.GetComponent<AudioSource>().clip = player.GetComponent<AudioManager>().GetClip(13);
            player.GetComponent<AudioSource>().Play();
            location = 2;
        }

        if (col.gameObject.name == "Living Room") {
            if (!livLight.enabled) {
                anim.Play("Flip");
                livLight.GetComponent<AudioSource>().clip = player.GetComponent<AudioManager>().GetClip(6);
                livLight.GetComponent<AudioSource>().Play();
            }
            livLight.enabled = true;
            location = 3;
        }

        if (col.gameObject.name == "TV") {
            if (!TV.enabled) {
                if (activeDevice1 == Device1.TV || activeDevice2 == Device2.TV) {
                    TV.GetComponent<AudioSource>().Play();
                    TV.enabled = true;
                }
            }
            GetComponent<NPC_AudioManager>().location = location;
        }

        if (col.gameObject.name == "Discoball") {
            if (!Discoball.enabled) {
                if (activeDevice1 == Device1.Discoball || activeDevice2 == Device2.Discoball) {
                    Discoball.GetComponent<AudioSource>().Play();
                    Discoball.enabled = true;
                }
            }
            GetComponent<NPC_AudioManager>().location = location;
        }

        if (col.gameObject.name == "Microwave") {
            if (!Microwave.enabled) {
                if (activeDevice1 == Device1.Microwave || activeDevice2 == Device2.Microwave) {
                    Microwave.GetComponent<AudioSource>().clip = player.GetComponent<AudioManager>().GetClip(8);
                    Microwave.GetComponent<AudioSource>().Play();
                    Microwave.enabled = true;
                }
            }
            GetComponent<NPC_AudioManager>().location = location;
        }

        if (col.gameObject.name == "Computer") {
            if (!Computer.enabled) {
                if (activeDevice1 == Device1.Computer || activeDevice2 == Device2.Computer) {
                    Computer.GetComponent<AudioSource>().Play();
                    Computer.enabled = true;
                }
            }
            GetComponent<NPC_AudioManager>().location = location;
        }

        if (col.gameObject.name == "Charger") {
            if (!Charger.enabled) {
                if (activeDevice1 == Device1.Charger || activeDevice2 == Device2.Charger) {
                    Charger.GetComponent<AudioSource>().Play();
                    Charger.enabled = true;
                }
            }
            GetComponent<NPC_AudioManager>().location = location;
        }
    }
}
