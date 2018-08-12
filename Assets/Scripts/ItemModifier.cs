using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemModifier : MonoBehaviour {

    public abstract int ValueMultiplier { get; }

    // Use this for initialization
    void Start () {
	    GetComponent<Item>().Value *= ValueMultiplier;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public virtual bool CanReplace (ItemSlot slot) { return false;} 
    public virtual bool CanPlace (ItemSlot slot) { return true; }
    public virtual void PerformAction (ItemSlot slot) { }
    public virtual int  GetSetValue (Scorepad scorepad) { return 0; }

}
