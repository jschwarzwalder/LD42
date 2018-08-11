using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour {

    private Item[] Items;
    private int inventoryScore;
    [SerializeField] int InventorySize;

	// Use this for initialization
	void Start () {
        Items = new Item[InventorySize]; 
        inventoryScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void addItem (Item newItem, int index) {

        if (Items[index] = null) {
            Items[index] = newItem;
        }     

    }

    void Score() {
        
        for(int i = 0 ; i <= InventorySize; i++) {
            inventoryScore += Items[i].getValue();
        }
    }

    void destroyItem(Item newItem, int index)
    {
        Items[index] = null;

        addItem(newItem, index);
    }
}
