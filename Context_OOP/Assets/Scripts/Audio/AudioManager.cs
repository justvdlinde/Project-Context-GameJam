using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//            col.GetComponent<AudioSource>().clip = Player.GetComponent<AudioManager>().GetClip(col.GetComponent<AudioSource>(),1);
//            col.GetComponent<AudioSource>().Play();

public class AudioManager: MonoBehaviour{

    public AudioClip[] allclips;

    private void Awake()
    {
        allclips = new AudioClip[Resources.LoadAll("Audio/").Length];
        for (int i = 0; i < Resources.LoadAll("Audio/").Length; i++)
        {
            allclips[i] = (AudioClip)Resources.LoadAll("Audio/")[i];
        }
    }

    public AudioClip GetClip(int ID)
    {
        AudioClip clip = allclips[ID];
        return clip;
    }

}
