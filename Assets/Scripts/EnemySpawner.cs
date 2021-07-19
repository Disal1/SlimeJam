using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    private GameObject enemy;
    float randX;
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
            randX = Random.Range(-9.5f, 9.5f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
}