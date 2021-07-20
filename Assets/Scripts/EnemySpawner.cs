using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    private GameObject enemy;
    public GameObject player;
    float randX;
    Vector2 whereToSpawn;
    public float spawmRate = 2f;
    float nextSpanwn = 0.0f;
    private float spawnTimer = 0;
    float normalEnemy = 0;
    float shooterEnemy = 100f;
    float juggernautEnemy = 100f;
    int killCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        killCount = player.GetComponent<CharactorMovement>().enemyKills;
        if (killCount % 10 == 0) {
            changeChances();
        }

        if (Time.time > nextSpanwn)
        {
            float randnumber = Random.Range(0, 101);
            if (randnumber > juggernautEnemy + 1)
            {
                enemy = enemies[2];
            }
            else if (randnumber > shooterEnemy + 1)
            {
                enemy = enemies[1];
            }
            else 
            {
                enemy = enemies[0];
            
            }
            nextSpanwn = Time.time + spawmRate;
            randX = Random.Range(-10.5f, 10.5f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }

    void changeChances() {
        if (shooterEnemy >= 70)
        {
            shooterEnemy -= 10;
        }
        else if(juggernautEnemy >= 70)
        {
            shooterEnemy -= 10;
            juggernautEnemy -= 10;
        }
    }
}