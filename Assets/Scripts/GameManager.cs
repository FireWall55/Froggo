using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int level = 1;
    public int melons = 0;

    


    public void Save() {
        level = SceneManager.GetActiveScene().buildIndex+1;
        PlayerPrefs.SetInt("level", level);
        //if you are on the end screen, go to lvl 1 when you press start.
        if (PlayerPrefs.GetInt("level").ToString().Equals("4")) {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.SetInt("melons", 0);
        }
        
    }


}
