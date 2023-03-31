using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask mouseLayer;
    public float moveSpeed, rotateSpeed;

    public float forwardBound = 7.9f, backwardBound = -6.8f, leftBound = -16.0f, rightBound = 16.0f;
    
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInput();
        MouseLook();
    }

    void HandleInput()
    {
        Vector3 vel = Vector3.zero;
        if (Input.GetKey(KeyCode.W) && transform.position.z < forwardBound)
        {
            vel += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.z > backwardBound)
        {
            vel -= Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > leftBound)
        {
            vel -= Vector3.right;

        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < rightBound)
        {
            vel += Vector3.right;
        }
        vel = vel.normalized;

        rb.velocity = new Vector3(vel.x * moveSpeed, rb.velocity.y, vel.z * moveSpeed);
    }

    void MouseLook()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500, mouseLayer);

        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
}
