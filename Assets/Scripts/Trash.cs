using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnMouseDown()
    {
        GameObject cursorObj = GameObject.FindGameObjectWithTag("Cursor");
        Cursor cursor = cursorObj.GetComponent<Cursor>();
        Item item = cursor.SelectedItem;
        if (item != null)
        {
            cursor.SelectedItem = null;
            GameObject.Destroy(item.gameObject);
            
        }

    }

}
