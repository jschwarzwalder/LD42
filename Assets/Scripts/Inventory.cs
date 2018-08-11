using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour
{

    private Item[] Items;
    private int inventoryScore;
    [SerializeField] int rows;
    [SerializeField] int columns;
    private int inventorySize;

    // Use this for initialization
    void Start()
    {
        inventorySize = rows * columns;
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
        }

    }

    public Item getItemAt(int row, int col)
    {
        int index = row * columns + col;

        return Items[index];

    }

    void ScoreAtIndex(int index)
    {
        Item item = Items[index];
        if (!item.isInSet())
        {
            inventoryScore += item.getValue();
        }
        else
        {
            //TODO: handle set value
            // inventoryScore += item.modScore();
        }
    }

    public void scoreItem(int row, int col)
    {
        int index = row * columns + col;

        ScoreAtIndex(index);
    }

    public void ScoreAll()
    {

        for (int i = 0; i <= inventorySize; i++)
        {
            ScoreAtIndex(i);
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
