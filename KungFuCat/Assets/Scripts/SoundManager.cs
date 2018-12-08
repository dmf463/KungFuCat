using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls all the sounds
public class SoundManager : MonoBehaviour
{
    [Header("SFX")]
    public AudioClip alarmClock;
    public AudioClip spinKick;
    public AudioClip faceSmack;
    public AudioClip landing;
    public AudioClip phone;
    public AudioClip phonePickup;

    public void GenerateSourceAndPlay(AudioClip clip, float volume, float pitch = 1)
    {
        GenerateSourceAndPlay(clip, volume, pitch, transform.position);
    }

    //so basically when we want to play a sound we generate a prefab object with an audiosource
    //play the clip
    //then destroy the object after the clip is over
    //this works for sound effects and random things
    //but will not be ideal for the final version
    public void GenerateSourceAndPlay(AudioClip clip, float volume, float pitch, Vector3 position)
    {
        GameObject specialAudioSource = Instantiate(Services.PrefabDB.GenericAudioSource);
        AudioSource source = specialAudioSource.GetComponent<AudioSource>();
        specialAudioSource.transform.position = position;
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
        Destroy(specialAudioSource, clip.length);
        //Debug.Log("Clip played: " + clip.name);
    }


    public void GetSourceAndPlay(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void GetSourceAndStop(AudioSource source)
    {
        source.Stop();
    }
}
    