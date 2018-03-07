using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {

    public void newGame(string Menu) {
        SceneManager.LoadScene(Menu);
    }
    public void quitGame() {
        Application.Quit();
    }
}
