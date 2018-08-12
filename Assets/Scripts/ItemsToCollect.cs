using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsToCollect : MonoBehaviour
{

    [SerializeField] Item[] itemPrefabs;
    private LinkedList<GameObject> itemsToPickup = new LinkedList<GameObject>();
    private int current_index;
    [SerializeField] float itemSpeed;
    [SerializeField] float delaySpawn;
    [SerializeField] Transform startPosition;
    [SerializeField] Transform endPosition;

    private bool finished;
    private float prevSpawn;
    private Cursor cursor;
    

    // Use this for initialization
    void Start()
    {

        Shuffle();
        current_index = 0;

        GameObject cursorObj = GameObject.FindGameObjectWithTag("Cursor");
        cursor = cursorObj.GetComponent<Cursor>();

    }

    // Update is called once per frame
    void Update()
    {
        AddItem();

        MoveItems();

        if (!finished && current_index >= itemPrefabs.Length && cursor.SelectedItem == null && itemsToPickup.Count == 0) {

            GameObject cursorObj = GameObject.FindGameObjectWithTag("Inventory");
            cursorObj.GetComponent<Inventory>().ScoreAll();
            finished = true;
        }


    }

    void Shuffle()
    {
        int len = itemPrefabs.Length;
        for (int i = 0; i < len - 1; i++)
        {
            Item this_item = itemPrefabs[i];
            int swap_with = Random.Range(i, len);
            Item swapped_item = itemPrefabs[swap_with];
            itemPrefabs[i] = swapped_item;
            itemPrefabs[swap_with] = this_item;
        }
    }

    public Item getNextItem()
    {
        if (current_index < itemPrefabs.Length)
        {
            Item current_item = itemPrefabs[current_index];
            current_index += 1;
            return current_item;
        }
        else
        {
            return null;
        }

    }

    void AddItem()
    {
        if (Time.time - prevSpawn > delaySpawn)
        {
            Item item = getNextItem();
            if (item != null)
            {
                GameObject new_item = GameObject.Instantiate(item.gameObject);
                new_item.transform.position = startPosition.position;
                itemsToPickup.AddLast(new_item);
                prevSpawn = Time.time;
            }

        }

    }

    void MoveItems()
    {
        ArrayList itemsDone = new ArrayList();

        foreach (GameObject item in itemsToPickup)
        {
            //speed * time = distance
            item.transform.position += new Vector3(itemSpeed * Time.deltaTime, 0, 0);

            if (item.transform.position.x > endPosition.transform.position.x)
            {
                GameObject.Destroy(item);
                itemsDone.Add(item);

            }

        }
                   

        foreach (Object item in itemsDone)
        {
            itemsToPickup.Remove((GameObject) item);
        }
        if (cursor.SelectedItem != null)
        {
            itemsToPickup.Remove(cursor.SelectedItem.gameObject);
        }
    }



}
