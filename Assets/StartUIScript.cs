using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartUIScript : MonoBehaviour
{
    public GameObject settings;
    public GameObject credits;
    [SerializeField] private AudioClip sound;

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

    public void CreditsTrigger()
    {
        if (credits.activeSelf)
        {
            credits.SetActive(false);
        }
        else
        {
            credits.SetActive(true);
        }
    }
    public void playSound()
    {
        AudioManager.instance.Play(sound, transform, 1f);
    }
}
