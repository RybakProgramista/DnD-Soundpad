using UnityEngine;

public class Sound
{
    private int numpadID;
    public int getNumpadID() {  return numpadID; }
    public void setNumpadID(int newID) { numpadID = newID; }
    private AudioClip clip;
    public AudioClip getClip() { return clip; }
    private string type;
    private bool isLooped;
    public bool getIsLooped() { return isLooped; }
    public void changeIsLooped(bool newVal) {  isLooped = newVal; }
    public string getName()
    {
        return clip.name;
    }
    public string getType() { return type; }

    public Sound(AudioClip clip, string type) { 
        this.clip = clip; 
        this.type = type;
        isLooped= false;
    }
}
