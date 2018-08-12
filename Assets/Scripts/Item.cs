using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public enum ItemSet { None, Wizard, Ranged, Warrior, Trilogy, Wands} 

    [SerializeField] string itemName;
    [SerializeField] int value;
    [SerializeField] string description;
    [SerializeField] ItemSet SetName;

    public bool InInventory {
        get { return Slot != null; }
    }

    public int Value {
        get { return value; }
        set { this.value = value; }
    }

    public ItemSlot Slot { get; set; }
    public bool Destroyed { get; private set; }

    private Cursor cursor;

    private AudioSource sound;


    // Use this for initialization
    void Start()
    {

        GameObject cursorObj = GameObject.FindGameObjectWithTag("Cursor");
        cursor = cursorObj.GetComponent<Cursor>();
        sound = cursor.GetComponent<AudioSource>();
        Destroyed = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Destroy() {
        if (InInventory) {
            Slot.SlotItem = null;
        }
        Destroyed = true;
        GameObject.Destroy(gameObject);
    }

    public int getValue()
    {
        return value;
    }

    public bool isInSet()
    {
        return SetName != ItemSet.None;
    }

    public ItemSet? getSet()
    {
        if (isInSet()){
            return SetName;
        }
        else
        {
            return null;
        }
    }

    private void OnMouseDown () {
        if (InInventory) {
            Slot.OnMouseDown();
        }
        else {
            if (cursor.SelectedItem != null) return;

            cursor.SelectedItem = this;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnMouseEnter () {
        cursor.HoverItem = this;
    }

    public string getName()
    {
        return itemName;
    
    }

    public string getDesc()
    {
        return description;
    }

    public void playSound()
    {
        sound.Play();
    }
    
}
