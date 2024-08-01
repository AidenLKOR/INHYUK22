using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;
    public AudioClip startSceneMusic;
    public AudioClip homeSceneMusic;
    public AudioClip miniGameMusic; // MiniGame 씬에서 재생될 음악
    public AudioClip homeYardMusic; // #2-5.HomeYard 씬에서 재생될 음악
    public AudioClip endingSceneMusic; // EndingScene 씬에서 재생될 음악

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "StartScene" || scene.name == "CreditsScene")
        {
            PlayMusic(startSceneMusic);
        }
        else if (scene.name == "#1.HomeScene")
        {
            PlayMusic(homeSceneMusic);
        }
        else if (scene.name == "#7.MiniGame_RSP")
        {
            PlayMusic(miniGameMusic);
        }
        else if (scene.name == "#2-5.HomeYard")
        {
            PlayMusic(homeYardMusic);
        }
        else if (scene.name == "EndingScene")
        {
            PlayMusic(endingSceneMusic);
        }
        else
        {
            // 기본적으로 다른 씬에서는 homeSceneMusic을 재생합니다.
            PlayMusic(homeSceneMusic);
        }
    }

    void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
