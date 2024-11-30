using System.Collections.Generic;

public class Ambience
{
    private string name;
    public string getName(){ return name; }
    public void setName(string name){ this.name = name;}
    private List<Sound> sounds;
    public List<Sound> getSounds(){ return sounds;}
    public void addSound(Sound sound){ sounds.Add(sound); }
    public void removSound(Sound sound){ sounds.Remove(sound); }

    public Ambience(string name){
        this.name = name;
        sounds = new List<Sound>();
    }
}
