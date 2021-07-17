using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    string buttonPressed;

    Vector3 lastMoveDir = new Vector3();

    float staminaDash = 20f;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (staminaDash < 20f)
        {
            staminaDash += Time.deltaTime;
        }
        handleMovement();
        if (staminaDash >= 4f)
        {
            HandleDash();
        }
        else
        {
            Debug.Log("Dash Available");
        }
        Debug.Log(staminaDash);
    }

    private void FixedUpdate()
    {

    }

    private void handleMovement()
    {
        float speed = 250.0f;
        float moveX = 0.0f;
        float moveY = 0.0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }
        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        Vector3 targetMovePos = transform.position + moveDir * speed * Time.deltaTime;
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, moveDir, speed * Time.deltaTime);
        if (raycast.collider == null)
        {
            lastMoveDir = moveDir;
            transform.position = targetMovePos;
        }
        /*else { 
            
        }*/
    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dashDistance = 75f;
            Vector3 beforeDashPosition = transform.position;
            TryMove(lastMoveDir, dashDistance);
            staminaDash -= 4f;
        }
    }

    private bool CanMove(Vector3 dir, float distance)
    {
        return Physics2D.Raycast(transform.position, dir, distance).collider == null;
    }

    private bool TryMove(Vector3 baseMoveDir, float distance)
    {
        Vector3 moveDir = baseMoveDir;
        bool canMove = CanMove(moveDir, distance);
        if (!canMove)
        {
            // Cannot move diagonally
            moveDir = new Vector3(baseMoveDir.x, 0f).normalized;
            canMove = moveDir.x != 0f && CanMove(moveDir, distance);
            if (!canMove)
            {
                // Cannot move horizontally
                moveDir = new Vector3(0f, baseMoveDir.y).normalized;
                canMove = moveDir.y != 0f && CanMove(moveDir, distance);
            }
        }

        if (canMove)
        {
            lastMoveDir = moveDir;
            transform.position += moveDir * distance;
            return true;
        }
        else
        {
            return false;
        }
    }
}
