using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Play(AudioClip audio, Transform Object, float volume)
    {
        AudioSource source = Instantiate(audioSource,Object.position,Quaternion.identity);
        source.clip = audio;
        source.volume = volume;
        source.Play();
        float length = source.clip.length;
        Destroy(source.gameObject,length);
    }
    public void PlayRandom(AudioClip[] audio, Transform Object, float volume)
    {
        int rand = Random.Range(0, audio.Length);
        Play(audio[rand], Object, volume);
    }
}
