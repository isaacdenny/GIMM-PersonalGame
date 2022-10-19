using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    Dictionary<string, AudioClip> audioClipsDict = new();

    [SerializeField] List<AudioClip> audioClipList = new();
    [SerializeField] List<string> audioClipNames = new();

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PopulateDictionary();
    }

    private void PopulateDictionary()
    {
        for (int i = 0; i < audioClipList.Count; i++)
        {
            audioClipsDict.Add(audioClipNames[i], audioClipList[i]);
        }
    }

    internal void PlayShootSound(string soundName)
    {
        if (audioClipsDict.ContainsKey(soundName) && audioClipsDict[soundName] != null)
        {
            audioSource.clip = audioClipsDict[soundName];
            audioSource.Play();
        }
    }
}
