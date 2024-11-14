using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject soundPrefab;
    [SerializeField]
    private Transform soundsSearchList;

    private List<Sound> sounds = new List<Sound>();
    private string[] types = { "Ambience", "Effect", "Music" };

    private void Start()
    {
        foreach(string type in types)
        {
            Object[] clips = Resources.LoadAll(type);
            foreach (Object clip in clips) { 
                sounds.Add(new Sound(clip as AudioClip, type));
            }
        }

        foreach(Sound sound in sounds)
        {
            GameObject newSound = Instantiate(soundPrefab);
            newSound.GetComponent<SoundPrefab>().changeSound(sound);
            newSound.transform.SetParent(soundsSearchList.transform);
        }
    }
}
