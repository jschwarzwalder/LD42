using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour {

    private Inventory inventory;
    public int Row;
    public int Column;

    public Item SlotItem {
        get
        {
            return inventory.getItemAt(Row, Column);
        }
        private set {
            inventory.addItem(value, Row, Column);
        }
    }

	// Use this for initialization
	void Start () {
	    inventory = GetComponentInParent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown () {
        Debug.Log(SlotItem);
        if (SlotItem == null) {
            GameObject cursorObj = GameObject.FindGameObjectWithTag("Cursor");
            Cursor cursor = cursorObj.GetComponent<Cursor>();
            Item item = cursor.SelectedItem;
            cursor.SelectedItem = null;
            item.InInventory = true;
            item.transform.SetParent(transform);
            item.transform.localPosition = new Vector3(0, 0, item.transform.localPosition.z);
            SlotItem = item;

        }
    }
}
