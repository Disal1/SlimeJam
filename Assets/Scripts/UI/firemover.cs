using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firemover : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D body;
    Vector2 mousePos;
    public Camera cam;

    float radius = 1;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 wPos = Input.mousePosition;
        wPos.z = player.position.z - Camera.main.transform.position.z;
        wPos = Camera.main.ScreenToWorldPoint(wPos);
        Vector3 direction = wPos - player.position;
        direction = Vector3.ClampMagnitude(direction,radius);
        transform.position = player.position + direction;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - body.position;
        float angg = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angg;
    }
}
