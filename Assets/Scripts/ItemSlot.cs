using System;
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

    public Inventory SlotInventory {
        get { return inventory; }
    }

    // Use this for initialization
	void Start () {
	    inventory = GetComponentInParent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool CanReplace (ItemModifier modifier) {
        return modifier.CanReplace(this);
    }

    private bool CanPlace (ItemModifier modifier) {
        return modifier.CanPlace(this);
    }

    private void PerformAction (ItemModifier modifier) {
        modifier.PerformAction(this);
    }

    private void OnMouseDown () {
        GameObject cursorObj = GameObject.FindGameObjectWithTag("Cursor");
        Cursor cursor = cursorObj.GetComponent<Cursor>();
        Item item = cursor.SelectedItem;
        if (item != null) {
            ItemModifier[] modifiers = item.GetComponents<ItemModifier>();
            if (SlotItem != null && !Array.Exists(modifiers, CanReplace)) {
                Debug.Log("Cannot Replace Current Item");
                return;
            }
            if (!Array.TrueForAll(modifiers, CanPlace))
            {
                Debug.Log("Cannot place in this slot");
                return;
            }
            Array.ForEach(modifiers, PerformAction);

            cursor.SelectedItem = null;
            item.InInventory = true;
            item.transform.SetParent(transform);
            item.transform.localPosition = new Vector3(0, 0, item.transform.localPosition.z);
            item.GetComponent<Collider2D>().enabled = true;
            SlotItem = item;
        }

    }

    public void ScoreItemEarly () {
        inventory.scoreItem(Row, Column);
    }
}
