using UnityEngine;
using UnityEngine.Audio;

namespace XR
{
    public class AudioVolume : MonoBehaviour
    {
        public AudioMixer audioMixer;
    
        public void SetMusicVolume(float volume)
        {
            audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        }

        public void SetSFXVolume(float volume)
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        }
    }
}
