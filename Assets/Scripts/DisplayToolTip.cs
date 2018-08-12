using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayToolTip : MonoBehaviour
{

    private Cursor cursor;
    private Item displayItem;
    private string itemName;
    private string itemDesc;
    private string itemValue;
    private Item currentItem;

    [SerializeField] SpriteRenderer iconPosition;
    [SerializeField] Text toolTip;
    //[SerializeField] Transform NameText;
    //[SerializeField] Transform ValueText;
    //[SerializeField] Transform DescText;

    // Use this for initialization
    void Start()
    {

        GameObject cursorObj = GameObject.FindGameObjectWithTag("Cursor");
        cursor = cursorObj.GetComponent<Cursor>();


    }

    // Update is called once per frame
    void Update()
    {
        if (cursor.SelectedItem != null)
        {
            displayItem = cursor.SelectedItem;
            if (currentItem != displayItem)
            {
                RetrieveItemInfo(displayItem);
                currentItem = displayItem;
            }

        }
        else
        {
            //TODO display onHover
        }

        iconPosition.sprite = displayItem.GetComponent<SpriteRenderer>().sprite;

        string textToDisplay = "Name: " + itemName + "\n\n";
        textToDisplay += "Value: " + itemValue + "\n\n";
        textToDisplay += "Description: \n\n   " + itemDesc;

        toolTip.text = textToDisplay;



    }

    void RetrieveItemInfo(Item itemToDisplay)
    {
        itemName = itemToDisplay.getName();
        itemDesc = itemToDisplay.getDesc();
        itemValue = itemToDisplay.getValue().ToString();
    }
}
