using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeAwayScript : MonoBehaviour
{
    [SerializeField] float fadeTime;
    private TextMeshProUGUI fadeAwayText;

    private void Start() {
        fadeAwayText = GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            float alphaValue = fadeAwayText.color.a;
            while (alphaValue <= 1) {
                fadeAwayText.color = new Color(fadeAwayText.color.r, fadeAwayText.color.g, fadeAwayText.color.b, alphaValue);
                alphaValue += .1f;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            float alphaValue = fadeAwayText.color.a;
            while (alphaValue >= 0) {
                fadeAwayText.color = new Color(fadeAwayText.color.r, fadeAwayText.color.g, fadeAwayText.color.b, alphaValue);
                alphaValue -= .1f;
            }
        }
    }

}
