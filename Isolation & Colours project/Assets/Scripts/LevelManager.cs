using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float autoLoadNextLevelAfter;
    [SerializeField] private float delay = 1f;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        AudioListener.volume = 1;

        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Load auto load disabled, use a positive number in seconds.");
        }
        else
        {
            Invoke("LoadNextScene", autoLoadNextLevelAfter);
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LevelLoad(name));

        //load level after one second delay
        IEnumerator LevelLoad(string name)
        {
            float elapsedTime = 0;
            float currentVolume = AudioListener.volume;

            while (elapsedTime < delay)
            {
                elapsedTime += Time.deltaTime;
                AudioListener.volume = Mathf.Lerp(currentVolume, 0, elapsedTime / delay);
                yield return null;
            }

            Debug.Log("Level load requested for: " + name);
            SceneManager.LoadScene(sceneName);
        }
    }

    public void QuitRequest()
    {
        Debug.Log("Just Quit!");
        Application.Quit();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
