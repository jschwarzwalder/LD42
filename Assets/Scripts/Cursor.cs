using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    private Vector3 gripPosition;
    private Item selectedItem;

    public Item SelectedItem {
        get { return selectedItem;}
        set {
            selectedItem = value;
            if (selectedItem != null) {
                gripPosition = selectedItem.transform.position - MousePosition;
            }
        }
    }

    public Vector3 MousePosition {
        get { return Camera.main.ScreenToWorldPoint(Input.mousePosition); }
    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (selectedItem != null) {
	        selectedItem.transform.position = MousePosition + gripPosition;

	    }
	}

    
}
