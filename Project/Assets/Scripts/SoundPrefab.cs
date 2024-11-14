using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoundPrefab : MonoBehaviour
{
    [SerializeField]
    private Sound sound;

    [SerializeField]
    private TMP_Text nameText;
    [SerializeField]
    private TMP_Text lenghtText;
    [SerializeField]
    private TMP_Text typeText;
    [SerializeField]
    private Toggle isLooped;
    [SerializeField]
    private TMP_Dropdown pin;

    public void changeSound(Sound newSound)
    {
        sound = newSound;
        reinitialize();
    }
    private void reinitialize()
    {
        nameText.text = sound.getName();
        lenghtText.text = "" + sound.getClip().length;
        typeText.text = sound.getType();
        isLooped.isOn = sound.getIsLooped();
        pin.value = sound.getNumpadID();
        GetComponent<AudioSource>().clip = sound.getClip();
    }
    public void playSound()
    {
        AudioSource source = GetComponent<AudioSource>();
        if (source.isPlaying) source.Stop();
        else source.Play();
    }
}
