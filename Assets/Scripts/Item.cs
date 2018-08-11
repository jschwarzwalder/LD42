using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    [SerializeField] string name;
    [SerializeField] int value;
    [SerializeField] string description;
    [SerializeField] bool isSet;
    [SerializeField] private ItemSets SetName;
    



	// Use this for initialization
	void Start () {

       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getValue()
    {
        return value;
    }
    
}
