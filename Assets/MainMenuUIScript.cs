using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIScript : MonoBehaviour
{
    public GameObject settings;
    [SerializeField]private AudioClip sound;

    //Basic Settings
    public void SettingsTrigger()
    {
        if (settings.activeSelf)
        {
            settings.SetActive(false);
        }
        else
        {
            settings.SetActive(true);
        }
    }

    public void playSound()
    {
        AudioManager.instance.Play(sound,transform,1f);
    }
}
