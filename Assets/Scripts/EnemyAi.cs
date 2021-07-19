using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public CharactorMovement healthDamage;
    public GameObject healthDmg;
    public Transform player;
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    private float tempMoveSpeed = 0f;
    private Vector2 movement;
    public GameObject ignoreCollider;
    private float enemyAttackTime = 0f;
    private int inteAttack = 0;
    private bool didAttack = true;
    // Start is called before the first frame update

    public int startHealth;

    public Animator anim;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        tempMoveSpeed = moveSpeed;
        healthDamage = healthDmg.GetComponent<CharactorMovement>();
        Debug.Log(healthDamage.currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (inteAttack > 0)
        {
            moveSpeed = 0f;
            enemyAttackTime -= Time.deltaTime;
        }
        inteAttack = (int)enemyAttackTime;
        //Debug.Log(inteAttack);
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharactor(movement);
    }

    void moveCharactor(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

        rb.velocity = new Vector2(player.position.x, player.position.y);

        anim.SetFloat("moveX", rb.velocity.x);
        anim.SetFloat("moveY", rb.velocity.y);

        // transform.LookAt(cm.body.transform, Vector3.up); It has something to do with this


        //Debug.Log("X = " + rb.transform.position.x);
        //Debug.Log("Y = "+ rb.transform.position.y);
        Collider2D hit = Physics2D.Raycast(transform.position, direction, 1f).collider;
        if (hit != null && hit.gameObject.name == "Player")
        {
            Debug.Log(inteAttack);
            if (inteAttack < 1 && !didAttack)
            {
                if (hit != null)
                {
                    //Player take Damage animation 
                    string nam = hit.gameObject.name;
                    healthDamage.TakeDamage(20);

                    if (healthDamage.currentHealth <= 0)
                    {
                        //Player death animation
                        Destroy(hit.gameObject);
                    }
                    moveSpeed = tempMoveSpeed;
                    didAttack = true;
                    anim.SetBool("isAttacking", false);
                    Debug.Log("Im hit");
                }
                else
                {
                    //Not sure what animation here
                    moveSpeed = tempMoveSpeed;
                    didAttack = true;
                    
                }
            }
            else if (inteAttack == 0 && didAttack)
            {
                //Enemy attack animation
                anim.SetBool("isAttacking", true);
                enemyAttackTime = 2f;
                didAttack = false;
            }
        }
        else if (!didAttack)
        {
            if (inteAttack < 1)
            {
                moveSpeed = tempMoveSpeed;
                didAttack = true;
            }
        }
    }
}