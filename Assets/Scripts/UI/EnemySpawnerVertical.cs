using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerVertical : MonoBehaviour
{
    public GameObject enemy;
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
            nextSpanwn = Time.time + spawmRate;
            randY = Random.Range(-3.5f, 3.5f);
            whereToSpawn = new Vector2(transform.position.x,randY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
}
