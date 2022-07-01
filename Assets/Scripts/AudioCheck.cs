using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCheck : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioOneTime()
    {
        if (_audioSource.isPlaying)
        {
            return;
        }
        else
        {
            _audioSource.Play();
        }
    }
}
