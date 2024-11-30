using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmbienceManager : MonoBehaviour
{
    //UI
    [SerializeField]
    private TMP_InputField currAmbientNameInput;
    [SerializeField]
    private TMP_Dropdown currAmbienceMusicDropdown;

    //prefabs
    [SerializeField]
    private GameObject ambienceButtonPrefab;

    //already in program gameobjects
    [SerializeField]
    private GameObject addAmbienceButton;
    [SerializeField]
    private GameObject ambienceList;

    //script vars
    private List<Ambience> ambiences = new List<Ambience>();
    private int currAmbience;
    private bool isAmbiencePlaying;

    //UI elements in app at start
    [SerializeField]
    private GameObject currAmbiencePanel;


    private void Start(){
        currAmbience = 0;
    }
    private void Update(){
        if(isAmbiencePlaying){
            foreach(Sound sound in ambiences[currAmbience].getSounds()){
                GetComponent<SoundsManager>().playSound(sound.getName());
            }
        }
    }

    public void addAmbience(){
        ambiences.Add(new Ambience("New Ambience"));
        GameObject newAmbienceButton = Instantiate(ambienceButtonPrefab);
        newAmbienceButton.transform.SetParent(ambienceList.transform);
        newAmbienceButton.GetComponent<Button>().onClick.AddListener( delegate { changeAmbience(ambiences.Count - 1); });
        addAmbienceButton.transform.SetAsLastSibling();
        changeAmbience(ambiences.Count - 1);
    }

    public void changeAmbience(int id){
        currAmbiencePanel.SetActive(true);
        currAmbience = id;
    }

    public void changeCurrAmbienceName(string newName){
        ambiences[currAmbience].setName(newName);
        ambienceList.transform.GetChild(currAmbience).GetComponentInChildren<TMP_Text>().text = newName;
    }
    public void onMusicChanged(int musicID){
        //tu skończyłeś
    }

    public void onPlayButtonClick(){
        stopPlayingAmbience();
        isAmbiencePlaying = !isAmbiencePlaying;
    }

    public void stopPlayingAmbience(){
        isAmbiencePlaying = false;
        foreach(AudioSource source in GetComponents<AudioSource>()){
            Destroy(source);
        }
    }
}
