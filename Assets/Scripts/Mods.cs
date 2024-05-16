using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mods : MonoBehaviour
{

    public bool bigTounge = false;
    public bool highSpeed = false;
    [SerializeField] Toggle toggle;


    private void Start() {
        PlayerPrefs.SetInt("speed", 0);
        PlayerPrefs.SetInt("tounge", 0);
    }

    public void BigTounge() {
        bigTounge = !bigTounge;
    }

    public void HighSpeed() {
        highSpeed = !highSpeed;
        

        if (highSpeed) {
            PlayerPrefs.SetInt("speed", 1);
        } else {
            PlayerPrefs.SetInt("speed", 0);
        }
    }

    public void Update() {
        if (bigTounge) {
            PlayerPrefs.SetInt("tounge", 1);
        } else {
            PlayerPrefs.SetInt("tounge", 0);
        }

    }



}
