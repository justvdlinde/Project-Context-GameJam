using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkGuy2 : NPCs {

    private bool canDialogue = true;
    public Renderer speechBubble;

    new void Start() {
        base.Start();
        speechBubble = GameObject.Find("Drunk Guy 2 Bubble").GetComponent<Renderer>();
    }

    new void Update() {
        base.Update();
    }

    protected override void OnTriggerEnter(Collider col) {
        base.OnTriggerEnter(col);
    }
 private void OnTriggerStay(Collider col) {
        if (col.gameObject.name == "Player") {
            if(canDialogue) {
                print("TEEEETST");
                speechBubble.enabled = true;
                if (Input.GetKey(KeyCode.Space)) {
                    GetComponent<DialogueTrigger>().TriggerDialogue();
                    canDialogue = false;
                }
            }   
        }
    }
    private void OnTriggerExit(Collider other) {
        speechBubble.enabled = false;
    }
}
