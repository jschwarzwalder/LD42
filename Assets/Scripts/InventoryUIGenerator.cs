using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[ExecuteInEditMode] 
public class InventoryUIGenerator : MonoBehaviour {

    private int currentWidth;
    private int currentHeight;
    private Vector2 currentSpacing;
    private Vector2 currentMargin;
    private Inventory inventory;

    public int Width;
    public int Height;
    public Vector2 Spacing;
    public Vector2 Margin;
    public GameObject ItemSlotPrefab;

	// Use this for initialization
	void Start () {
	    inventory = GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Width != currentWidth || Height != currentHeight) {
	        RegenerateSlots();
	    }
        else if (currentSpacing != Spacing || currentMargin != Margin) {
	        RepositionSlots();
	    }
	}

    private void RegenerateSlots () {
        ItemSlot[] itemSlots = GetComponentsInChildren<ItemSlot>();
        foreach (ItemSlot itemSlot in itemSlots) {
            DestroyImmediate(itemSlot.gameObject);
        }
        for (int row = 0; row < Height; ++row) {
            for (int col = 0; col < Width; ++col) {
                GameObject itemSlotObj = Instantiate(ItemSlotPrefab);
                Transform itemSlotTransform = itemSlotObj.transform;
                itemSlotTransform.SetParent(transform);

                Vector2 position = new Vector2(Margin.x + col * Spacing.x,
                                               Margin.y + row * Spacing.y);
                itemSlotTransform.localPosition = position;

                ItemSlot itemSlot = itemSlotObj.GetComponent<ItemSlot>();
                itemSlot.Row = row;
                itemSlot.Column = col;
                itemSlotObj.name = "Item Slot (" + col + ", " + row + ")";
            }
        }
        currentHeight = Height;
        currentWidth = Width;
        currentMargin = Margin;
        currentSpacing = Spacing;
    }

    private void RepositionSlots () {
        ItemSlot[] itemSlots = GetComponentsInChildren<ItemSlot>();
        for (int i = 0; i < Width * Height; ++i) {
            int row = i / Width;
            int col = i % Width;
            Transform itemSlotTransform = itemSlots[i].transform;

            Vector2 position = new Vector2(Margin.x + col * Spacing.x,
                                           Margin.y + row * Spacing.y);
            itemSlotTransform.localPosition = position;
        }
        currentMargin = Margin;
        currentSpacing = Spacing;
    }
}
