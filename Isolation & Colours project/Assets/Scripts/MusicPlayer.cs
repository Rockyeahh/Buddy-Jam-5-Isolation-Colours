using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] levelMusicArray;

    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += Onlevelwasloaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= Onlevelwasloaded;
    }

    void Onlevelwasloaded (Scene scene, LoadSceneMode mode) // LoadSceneMode mode is needed for the OnLevelwasloaded overload to work. mode is just a name.
    {
        // The build index code aligns the audio clips with the scene numbers with exception of element 0/scene 0.
        AudioClip thisLevelMusic = levelMusicArray[scene.buildIndex];
        //Debug.Log("Playing clip" + levelMusicArray[scene.buildIndex]);
        if (thisLevelMusic)
        { // If there's some music attached
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true; // May need changing once I have more than one track to test. Could just record me saying track 1, track 2 and a track 3.
            audioSource.Play();
        }
    }
}
