using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource finishSound;

    private bool levelCompleted = false;
    [SerializeField] GameManager gameManager;
    [SerializeField] ItemCollector itemCollector;
    

    private void Awake() {
        finishSound.volume = PlayerPrefs.GetFloat("SFX");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player" && !levelCompleted) {
            finishSound.Play();
            levelCompleted = true;
            PlayerPrefs.SetInt("melons", itemCollector.melons);
            PlayerPrefs.SetInt("plays", PlayerPrefs.GetInt("plays")+1);
            Invoke("CompleteLevel", 1.5f);
        }
    }

    private void CompleteLevel() {
        levelCompleted = false;
        Debug.Log("Level completed");
        PlayerPrefs.SetInt("plays", PlayerPrefs.GetInt("plays")+1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameManager.Save();
    }
}
