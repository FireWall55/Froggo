using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenMusic : MonoBehaviour
{

    [SerializeField] private AudioSource music;
    
    private void Awake() {
        music.volume = PlayerPrefs.GetFloat("Volume");
    }
}
