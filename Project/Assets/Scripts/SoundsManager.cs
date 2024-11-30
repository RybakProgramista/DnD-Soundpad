using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class SoundsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject soundPrefab;
    [SerializeField]
    private Transform soundsSearchList;
    private List<Sound> sounds = new List<Sound>();
    private string[] types = { "Effect", "Music" };

    private Dictionary<string, AudioSource> audioSources= new Dictionary<string, AudioSource>();

    private void Start()
    {
        foreach(string type in types)
        {
            Object[] clips = Resources.LoadAll(type);
            foreach (Object clip in clips) { 
                sounds.Add(new Sound(clip as AudioClip, type));
            }
            showSounds("");
        }
    }
    public void showSounds(string name){
        resetScrollView();
        if(name.Equals("")){
            foreach(Sound sound in sounds)
            {
                createSoundView(sound);
            }
        }
        else{
            foreach(Sound sound in sounds){
                if(sound.getName().ToLower().Contains(name.ToLower())){
                    createSoundView(sound);
                }
            }
        }
    }
    private void createSoundView(Sound sound){
        GameObject newSound = Instantiate(soundPrefab);
        newSound.transform.Find("Play").GetComponent<Button>().onClick.AddListener( delegate { playSound(sound.getName()); });
        newSound.transform.Find("Loop").GetComponent<Toggle>().onValueChanged.AddListener( delegate { loopSound(sound.getName()); });
        newSound.transform.Find("Loop").GetComponent<Toggle>().isOn = false;
        newSound.GetComponent<SoundPrefab>().changeSound(sound);
        newSound.transform.SetParent(soundsSearchList.transform);
    }
    private void resetScrollView(){
        foreach(Transform temp in soundsSearchList.transform){
            Destroy(temp.gameObject);
        }
    }
    public void playSound(string name){
        if(audioSources.ContainsKey(name)){
            if(!audioSources[name].isPlaying){
                audioSources[name].Play();
            }
            else{
                Destroy(audioSources[name]);
                audioSources.Remove(name);
                return;
            }
        }
        else{
            AudioSource newSource = this.AddComponent<AudioSource>();
            newSource.clip = getSound(name).getClip();
            audioSources.Add(name, newSource);
            newSource.Play();
        }
        audioSources[name].loop = getSound(name).getIsLooped();
    }
    public void loopSound(string name){
        getSound(name).changeIsLooped(!getSound(name).getIsLooped());
        if(audioSources.ContainsKey(name)) audioSources[name].loop = getSound(name).getIsLooped();
    }
    public Sound getSound(string name){
        foreach(Sound sound in sounds){
            if(sound.getName().Contains(name)){
                return sound;
            }
        }
        return null;
    }
}
