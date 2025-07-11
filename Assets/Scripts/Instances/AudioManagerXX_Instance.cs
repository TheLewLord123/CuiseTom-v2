using System;
using System.Collections;
using NUnit.Framework.Constraints;

using UnityEngine;
using UnityEngine.SceneManagement;

public enum SoundSources{
        BGM,
        SFX,
        PITCH,
    }
public class AudioManagerXX_Instance : MonoBehaviour
{
    // [Serializable]
    // private struct SFX{
    //     public string name;
    //     public AudioClip clip;
    //     [Range(0f,1f)]
    //     public float volume;
    //     [Range(.1f,3f)]
    //     public float pitch;
    //     public bool loop;
    //     [HideInInspector]
    //     public AudioSource source;

    // }
    
    [Serializable]
    private struct Clips{
        public string name;
        public AudioClip clip;
        public SoundSources sources;
        [Range(.1f,3f)]public float pitch;
    }
    [Serializable]
    public struct AudioSources{
        public string name;
        public AudioSource sources;
    }
    public static AudioManagerXX_Instance instance;
    public AudioSources[] audioSources;
    [SerializeField]Clips[] clips;
    
    void Awake()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        audioSources[(int)SoundSources.BGM].sources.volume = PublicInventory.Master*PublicInventory.SFX/10000f;
        audioSources[(int)SoundSources.BGM].sources.volume = PublicInventory.Master*PublicInventory.Music/10000f;
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneChanged;
    }
    public void Mute(SoundSources SD)
    {
        audioSources[(int)SD].sources.mute = true;
    }
    // ==========================Change BG Music===================
    void OnSceneChanged(Scene l, LoadSceneMode k){ 
        audioSources[(int)SoundSources.BGM].sources.mute = false;
        audioSources[(int)SoundSources.SFX].sources.mute = false;
        if(l.name == "TitleScreen")
        PlaySound("MainMenu");
        else if(l.name == "MainGame"||l.name == "MainGame 1")
        PlaySound("GameMusic");
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneChanged;
    }
    public void PlaySound(string soundName){
        Clips s = Array.Find(clips, sound => sound.name == soundName); //sound == temporary name for a single array
        if(s.sources == SoundSources.BGM){
            audioSources[(int)s.sources].sources.clip = s.clip;
        audioSources[(int)s.sources].sources.Play();   
        }
        else if(s.sources == SoundSources.SFX){
        audioSources[(int)s.sources].sources.PlayOneShot(s.clip);   
        }
        else{
            AudioSource a = gameObject.AddComponent<AudioSource>();
            a.clip = s.clip;
            a.pitch = s.pitch;
            a.volume = PublicInventory.Master*PublicInventory.SFX/10000f;
            a.Play();
            StartCoroutine(audioClipEnd(a));
        }
    }
    IEnumerator audioClipEnd(AudioSource a){
        while(true){
        yield return null;
        if(a.isPlaying == false){
            Destroy(a);
            break;
        }
        }
    }

}
