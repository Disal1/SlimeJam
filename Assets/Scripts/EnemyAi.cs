using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Vector2 movement;
    public GameObject ignoreCollider;
    // Start is called before the first frame update

    public Animator anim;
    public CharactorMovement cm;

    private void OnTrigerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Ouch");
        }
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Physics.IgnoreCollision(ignoreCollider.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
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

        rb.velocity = new Vector2(transform.position.x, transform.position.y);

        anim.SetFloat("moveX", rb.velocity.x);
        anim.SetFloat("moveY", rb.velocity.y);

        // transform.LookAt(cm.body.transform, Vector3.up); It has something to do with this


        //Debug.Log("X = " + rb.transform.position.x);
        //Debug.Log("Y = "+ rb.transform.position.y);
    }
}