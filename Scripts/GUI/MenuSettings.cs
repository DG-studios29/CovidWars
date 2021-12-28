using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update

    //public void SetVolume(float volume)
    //{
    //    audioMixer.SetFloat("volume", volume);
    //}

    //public void setQuality(int qualityIndex)
    //{
    //    QualitySettings.SetQualityLevel(qualityIndex);
    //}

    //public void setFullScreen(bool isfullscreen)
    //{
    //    Screen.fullScreen = isfullscreen;

    //}
    public void returnMenu( )
    {
        SceneManager.LoadScene(0);
    }
}
