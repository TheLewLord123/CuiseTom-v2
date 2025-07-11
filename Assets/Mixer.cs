using UnityEngine;
using UnityEngine.Audio;
public class Mixer : MonoBehaviour
{
    [SerializeField]private AudioMixer mixer;

    public void setMasterVolume(float level)
    {
        mixer.SetFloat("Master", Mathf.Log10(level)*20f);
    }
    public void setSFXVolume(float level)
    {
        mixer.SetFloat("SFX", Mathf.Log10(level) * 20f);
    }
    public void setBGMVolume(float level)
    {
        mixer.SetFloat("BGM", Mathf.Log10(level) * 20f);
    }
}
