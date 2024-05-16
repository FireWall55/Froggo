using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] Text text;

    private void Awake() {
        text.text = "Melons:" + PlayerPrefs.GetInt("melons");
    }
}
