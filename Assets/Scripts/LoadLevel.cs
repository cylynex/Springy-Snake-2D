using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public void LoadLvl(string lvl) {
        SceneManager.LoadScene(lvl);
    }

    public void QuitGame() {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
