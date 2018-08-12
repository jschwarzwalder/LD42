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
    
    public bool InInventory { get; set; }

    public int Value {
        get { return value; }
        set { this.value = value; }
    }


    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

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
        if (!InInventory) {
            GameObject cursorObj = GameObject.FindGameObjectWithTag("Cursor");
            cursorObj.GetComponent<Cursor>().SelectedItem = this;
            GetComponent<Collider2D>().enabled = false;
            
        }
    }

}
