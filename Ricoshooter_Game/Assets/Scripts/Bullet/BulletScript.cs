using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 direction;
    Vector3 lastVelocity;

    [SerializeField] float Speed = 10f;
    [SerializeField] float Damage = 25f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        direction = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Start()
    {
        rb.AddForce(direction * Speed * Time.deltaTime, ForceMode.Impulse);
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var currentSpeed = lastVelocity.magnitude;
        direction = Vector3.Reflect(direction, collision.contacts[0].normal);
        rb.velocity = Vector3.zero;
        rb.AddForce(direction * Speed * Time.deltaTime, ForceMode.Impulse);
    }
}
