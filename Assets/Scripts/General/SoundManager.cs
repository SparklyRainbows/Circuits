using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audio;

    [Header("Audio files")]
    public AudioClip bgm;

    #region unity_functions
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        audio = GetComponent<AudioSource>();

        PlayBGM();
    }
    #endregion
    
    public void PlayBGM() {
        audio.clip = bgm;
        audio.loop = true;
        audio.Play();
    }

    public void PlaySound() {

    }
}
