using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public void Quit() {
        PlayerPrefs.SetInt("plays", PlayerPrefs.GetInt("plays") + 1);
        Application.Quit();
    }
}
