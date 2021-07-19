using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerVertical : MonoBehaviour
{
    public GameObject[] enemies;
    private GameObject enemy;
    float randY;
    Vector2 whereToSpawn;
    public float spawmRate = 2f;
    float nextSpanwn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpanwn)
        {
            float randnumber = Random.Range(0, 2);
            Debug.Log(randnumber);
            if (randnumber < 0.8f)
            {
                enemy = enemies[0];
            }
            else
            {
                enemy = enemies[1];
            }
            nextSpanwn = Time.time + spawmRate;
            randY = Random.Range(-4.5f, 4.5f); //Enter range of arena
            whereToSpawn = new Vector2(transform.position.x, randY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
}