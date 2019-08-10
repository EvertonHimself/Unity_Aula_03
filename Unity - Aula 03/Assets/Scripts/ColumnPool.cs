using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    // The number of slots to put columns in the columns set.
    public int columnPoolSize = 5;
    // The column prefab.
    public GameObject columnPrefab;
    // The rate at which columns will be spawned.
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;


    // A set of columns.
    private GameObject[] columns;
    // Where the object pool will be positioned in the game.
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    // The amount of time that passed since a column was spawned.
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;


    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Just a timer.
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            // Generates a random position to place the column.
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }

    }
}
