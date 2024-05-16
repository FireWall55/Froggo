using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour  
{

    [SerializeField] Text text;

    private bool fullScreen;


    public void StartGame() {
        if (PlayerPrefs.GetInt("plays") == 0) {
            SceneManager.LoadScene(1);
        } else {
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        }

    }
    private void Start() {
        text.enabled = false;
    }

    public void ResetData() {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("melons", 0);
    }

    public void showResetText() {
        text.enabled = true;
        Invoke(nameof(HideResetText), 4f);
    }

    public void HideResetText() {
        text.enabled = false;
    }

    public void FullScreen() {
        fullScreen = !fullScreen;
        if (fullScreen) {
            Screen.fullScreen = true;
        } else {
            Screen.fullScreen = false;
        }
    }

}
