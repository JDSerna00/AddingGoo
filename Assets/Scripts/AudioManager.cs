using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Track[] tracks;
    public AudioSource audioSource;
    public AudioClip Music1;
    public AudioClip Music2;
    public AudioClip Music3;

    private void Start()
    {
        ChangeSong(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }


    private void Enabled()
    {
        SceneManager.sceneLoaded += ChangeSong;
    }

    private void Disabled()
    {

        SceneManager.sceneLoaded -= ChangeSong;

    }

    
    private void ChangeSong(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {

            case "Level1":
                audioSource.clip = Music1;
                break;

            case "Level2":
                audioSource.clip = Music2;
                break;

            case "Level3":
                audioSource.clip = Music3;
                break;

        }

        if (audioSource.clip != null)
        {

            audioSource.Play();

        }



    }


    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
