using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static AudioSlider;
using static UnityEngine.UI.ContentSizeFitter;

public class SfxSlider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ValueText;
    [SerializeField] private Slider slider;


    //when slider is sliden
    public void OnChangeSlider(float Value) {
        ValueText.SetText($"{Value.ToString("N4")}");


        //set player preferences
        PlayerPrefs.SetFloat("SFX", Value);
        PlayerPrefs.Save();
    }

    //when started, set slider
    private void Awake() {
        slider.value = PlayerPrefs.GetFloat("SFX");
    }

}
