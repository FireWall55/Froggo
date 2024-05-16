using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    private void Update() {
        sound.volume = PlayerPrefs.GetFloat("SFX");
    }
}
