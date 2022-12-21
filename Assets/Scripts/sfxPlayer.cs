using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxPlayer : MonoBehaviour
{
    [SerializeField] AudioClip explosionSfx;
    AudioSource _audioSource;

    public static sfxPlayer instance;

    private void Awake() {
        _audioSource = GetComponent<AudioSource>();
        if(instance != null && instance!=this ){
            Destroy(this);
        }else{
            instance=this;
            DontDestroyOnLoad(this);
        }            

    }
    public void playExplosion(){
        _audioSource.PlayOneShot(explosionSfx);
    }
}
