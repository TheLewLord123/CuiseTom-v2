using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIScript : MonoBehaviour
{
    public GameObject settings;
    public GameObject credits;

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
}
