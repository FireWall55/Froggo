using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusic : MonoBehaviour
{
    private void Start() {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Awake() {

        BGMusic[] objects = FindObjectsOfType<BGMusic>();

        

        if (SceneManager.GetActiveScene().buildIndex == 4) {
            Destroy(objects[0].gameObject);
            Destroy(objects[1].gameObject);
            return;
        }


        if (objects.Length > 1) {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        /*if (SceneManager.GetActiveScene().buildIndex == 2 && objects.Length == 2) {
            Destroy(this.gameObject);
            return;
        }*/
    }

    private void Update() {
        BGMusic[] objects = FindObjectsOfType<BGMusic>();


        if (SceneManager.GetActiveScene().buildIndex == 0) {
            objects[0].GetComponent<AudioSource>().volume = 0;
        } else {
            objects[0].GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");            
        }
    }
}
