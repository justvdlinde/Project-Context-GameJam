using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AudioManager : MonoBehaviour {

    public AudioClip[] clips;
    private AudioClip currentclip;
    public int location;
    private int speakchance;
    public GameObject player;

    public GameObject[] Siblings = new GameObject[3];

	void Start () {

        for (int i = 0; i< transform.parent.childCount; i++)
        {
            Siblings[i] = transform.parent.GetChild(i).gameObject;
        }

        Invoke("Speak",0);
	}

    void Speak()
    {

        int speakchancetemp = -30;

        foreach (GameObject sibling in Siblings)
        {
            if (sibling.GetComponent<NPC_AudioManager>().location == location) speakchancetemp += 30;
        }
        speakchance = speakchancetemp;
        speakchance += (int)Mathf.Pow(player.GetComponent<CharController>().happiness,2f)/10;

        if (player.GetComponent<CharController>().location == location)
            speakchance *= player.GetComponent<CharController>().happiness / 5;

        if (speakchance > 100) speakchance = 100;

        speakchancetemp = 0;

        if (Random.Range(0,101f) > 100- speakchance){

            if (transform.name != "Drunk Guy 3") currentclip = clips[Random.Range(0, 5)];
            else currentclip = clips[Random.Range(5, 9)];
            
            GetComponent<AudioSource>().clip = currentclip;
            GetComponent<AudioSource>().Play();
        }

        Invoke("Speak", Random.Range(6, 12));

    }
}
