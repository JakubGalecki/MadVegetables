using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{

    public Slider SliderMusic;
    public Slider SliderSFX;
    public Toggle ToggleHighQuality;

    // Use this for initialization
    void Start()
    {
        SliderMusic.value = PlayerPrefs.GetFloat("OptionsMusic");
        SliderSFX.value = PlayerPrefs.GetFloat("OptionsSFX");
        ToggleHighQuality.isOn = PlayerPrefs.GetInt("OptionsHQ") != 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHQToggle(bool value)
    {
        PlayerPrefs.SetInt("OptionsHQ", value == true ? 1 : 0);
    }

    public void SetMusicValue(float value)
    {
        PlayerPrefs.SetFloat("OptionsMusic", value);
    }

    public void SetSFXValue(float value)
    {
        PlayerPrefs.SetFloat("OptionsSFX", value);
    }
}
