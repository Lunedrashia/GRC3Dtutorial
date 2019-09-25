using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Transform explosionPoint;
    [SerializeField] float propulsionForce = 5f;
    [SerializeField] float moveSpeed = 1f;

    bool launch = false;
    Rigidbody rb;
    Vector3 t;

    void Start()
    {
        t = transform.position;
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddExplosionForce(propulsionForce, explosionPoint.position, 0.2f, 0);
            launch = true;
        }
    }

    private void Move()
    {
        if(launch)
        {
            return;
        }
        float moveX = Input.GetAxis("Horizontal");
        Vector3 newPos = new Vector3(transform.position.x + moveX * Time.deltaTime * moveSpeed,
            transform.position.y,
            transform.position.z);
        transform.position = newPos;
    }

    public void ResetState()
    {
        rb.freezeRotation = true;
        rb.velocity = Vector3.zero;
        transform.position = t;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        launch = false;
        rb.freezeRotation = false;
    }
}
