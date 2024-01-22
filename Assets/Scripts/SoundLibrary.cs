using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Dictionary<string, AudioClip> _audioLibrary = new Dictionary<string, AudioClip>();
    private void OnEnable()
    {
        FallingPrefab._onPlaySound += PlaySound;
        MathProblem._onPlaySound += PlaySound;
        MatchingGame._onPlaySound += PlaySound;
    }
    private void Start()
    {
        LoadSoundResources();
    }
    /// <summary>
    /// Loads all sound effects into a dictionary.
    /// </summary>
    private void LoadSoundResources()
    {
        AudioClip[] lSoundEffects = Resources.LoadAll<AudioClip>("Audio Sources/Sound Effects");
        foreach (var lSoundEffect in lSoundEffects)
        {
            _audioLibrary.Add(lSoundEffect.name, lSoundEffect);
        }
    }
    /// <summary>
    /// Checks the sound library for the name passed and if found plays it.
    /// </summary>
    /// <param name="aSoundName"></param>
    private void PlaySound(string aSoundName)
    {
        AudioClip lSound;
        if(_audioLibrary.TryGetValue(aSoundName, out lSound)){
            _audioSource.clip = lSound;
            _audioSource.Play();
        }        
    }
    private void OnDisable()
    {
        FallingPrefab._onPlaySound -= PlaySound;
        MathProblem._onPlaySound -= PlaySound;
        MatchingGame._onPlaySound -= PlaySound;
    }
}
