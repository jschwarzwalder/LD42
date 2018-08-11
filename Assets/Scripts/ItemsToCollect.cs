using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsToCollect : MonoBehaviour
{

    [SerializeField] Item[] items;
    private int current_index;

    // Use this for initialization
    void Start()
    {

        Shuffle();
        current_index = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shuffle()
    {
        int len = items.Length;
        for (int i = 0; i < len - 1; i++)
        {
            Item this_item = items[i];
            int swap_with = Random.Range(i, len);
            Item swapped_item = items[swap_with];
            items[i] = swapped_item;
            items[swap_with] = this_item;
        }
    }

    public Item getNextItem()
    {
        if (current_index < items.Length)
        {
            Item current_item = items[current_index];
            current_index += 1;
            return current_item;
        }
        else
        {
            return null;
        }

    }


}
