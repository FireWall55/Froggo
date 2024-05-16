using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int melons;

    [SerializeField] private Text score;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Awake() {
        melons = PlayerPrefs.GetInt("melons");
        collectionSoundEffect.volume = PlayerPrefs.GetFloat("SFX");
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Melon")) {

            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            melons++;
            score.text = "Melons: " + melons;
        }
    }
}
