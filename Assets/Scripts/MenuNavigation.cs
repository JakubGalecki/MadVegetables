using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuNavigation : MonoBehaviour {

    public List<GameObject> PanelsList;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ActivatePanel(GameObject PanelToActivate)
    {
        if (PanelsList.Contains(PanelToActivate))
        {
            for (int i = 0; i < PanelsList.Count; i++)
            {
                PanelsList[i].SetActive(false);
            }

            PanelToActivate.SetActive(true);
        }
    }
}
