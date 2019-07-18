using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystems : MonoBehaviour {
    public EventSystem ES;
    private GameObject StoredSelected;

    // Use this for initialization
    void Start()
    {
        StoredSelected = ES.firstSelectedGameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ES.currentSelectedGameObject != StoredSelected)
        {
            if (ES.currentSelectedGameObject == null)
            {
                
                ES.SetSelectedGameObject(StoredSelected);
            }

            else
            {
                StoredSelected = ES.currentSelectedGameObject;
            }
        }
    }
}
