﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private Item[] Items;
    private int inventoryScore;
    [SerializeField] int rows;
    [SerializeField] int columns;
    private int inventorySize;
    private int openSlots;

    public int Rows { get { return rows; } }
    public int Columns { get { return columns; } }

    // Use this for initialization
    void Start()
    {
        inventorySize = rows * columns;
        openSlots = inventorySize;
        Items = new Item[inventorySize];
        inventoryScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addItem(Item newItem, int row, int col)
    {

        int index = row * columns + col;

        if (Items[index] == null)
        {
            Items[index] = newItem;
            openSlots--;
            if (openSlots == 0) {
                ScoreAll();
            }
        }

    }

    public Item getItemAt(int row, int col)
    {
        int index = row * columns + col;

        return Items[index];

    }

    void ScoreAtIndex(int index, Scorepad scorepad)
    {
        Item item = Items[index];
        if (item == null) {
            return;
        }
        if (!item.isInSet())
        {
            inventoryScore += item.getValue();
        }
        else {
            ItemModifier[] modifiers = item.GetComponents<ItemModifier>();
            foreach (ItemModifier modifier in modifiers) {
                inventoryScore += modifier.GetSetValue(scorepad);
            }
        }

        Debug.Log("Total Score: " + inventoryScore);
    }

    public void scoreItem(int row, int col)
    {
        int index = row * columns + col;

        ScoreAtIndex(index, null);
    }

    public void ScoreAll() {
        Scorepad scorepad = new Scorepad();
        for (int i = 0; i < inventorySize; i++)
        {
            ScoreAtIndex(i, scorepad);
        }

    }

    void destroyItem(Item newItem, int row, int col)
    {
        int index = row * columns + col;

        Items[index] = null;

        addItem(newItem, row, col);
    }


    public int getScore()
    {
        return inventoryScore;
    }
}
