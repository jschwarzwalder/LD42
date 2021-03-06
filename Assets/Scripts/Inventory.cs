﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{

    private Item[] Items;
    private int inventoryScore;
    [SerializeField] int rows;
    [SerializeField] int columns;
    private int inventorySize;
    private int openSlots;
    private bool scored;

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
            Debug.Log("Add " + newItem);
            if (openSlots == 0) {
                ScoreAll();
            }
        }
        else if (newItem == null) {
            //Debug.Log("Remove " + Items[index]);
            Items[index] = null;
            openSlots++;
        }

        //Debug.Log("open slots: " + openSlots);
    }

    public Item getItemAt(int row, int col)
    {
        int index = row * columns + col;

        return Items[index];

    }

    void ScoreAtIndex(int index, Scorepad scorepad)
    {
        Item item = Items[index];
        if (item == null || item.Destroyed) {
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
        if (scored) return;
        Debug.Log("Score All");
        Scorepad scorepad = new Scorepad();
        for (int i = 0; i < inventorySize; i++)
        {
            ScoreAtIndex(i, scorepad);
        }
        scored = true;

        GameObject gameManagerObj = GameObject.FindGameObjectWithTag("Game Manager");
        gameManagerObj.GetComponent<LevelManager>().EndGame(inventoryScore);

        //Save Score to Pref
        int level = SceneManager.GetActiveScene().buildIndex;
        int currentHighScore = PlayerPrefs.GetInt("Level" + level);
        if (currentHighScore < inventoryScore)
        {
            PlayerPrefs.SetInt("Level" + level, inventoryScore);
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
