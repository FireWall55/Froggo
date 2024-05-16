using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraButtonFunctions : MonoBehaviour
{

    [SerializeField] private AudioSource testSound;

    private void Awake() {
        testSound.volume = PlayerPrefs.GetFloat("SFX");
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);

    }

    public void TestSound() {
        testSound.Play();
    }

}
