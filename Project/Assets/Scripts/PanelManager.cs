using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> panels = new List<GameObject>();
    private int currPanelId;

    private void Start(){
        currPanelId = 0;
        openPanel(0);
    }
    public void openPanel(int id){
        panels[currPanelId].SetActive(false);
        panels[id].SetActive(true);
        currPanelId = id;
    }
}
