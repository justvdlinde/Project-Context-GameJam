using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

	void Start () {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        print("Starting conversation with " + dialogue.name);
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        Time.timeScale = 0;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void EndDialogue() {
        print("End Of Conversation");
        animator.SetBool("IsOpen", false);
        Time.timeScale = 1;
    }

    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }
}
