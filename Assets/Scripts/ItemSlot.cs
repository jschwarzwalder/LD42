using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour {

    private Inventory inventory;
    public int Row;
    public int Column;

	// Use this for initialization
	void Start () {
	    inventory = GetComponentInParent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
