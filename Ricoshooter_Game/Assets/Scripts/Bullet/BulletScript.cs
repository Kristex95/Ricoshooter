using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 direction;
    float lastMagnitude;

    [SerializeField] float Speed = 10f;
    [SerializeField] float Damage = 25f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        direction = transform.forward;
    }
    private void Start()
    {
        rb.velocity = direction.normalized * Speed * Time.deltaTime;
        lastMagnitude = rb.velocity.magnitude;
        //Debug.Log("Start speed: " + direction * Speed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //pv.RPC("Reflect", RpcTarget.AllBuffered, collision);
        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
            PlayerControllerRB_2 collController = collision.gameObject.GetComponent<PlayerControllerRB_2>();

            //collController.TakeDamage(Damage);
        }
        else
        {
            Reflect(collision);
        }
        


        //Debug.Log("Updated speed: " + direction * Speed * Time.deltaTime);
        //rb.AddForce(direction.normalized * Speed * Time.deltaTime, ForceMode.Impulse);
    }

    void Reflect(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            direction = Vector3.Reflect(direction.normalized, collision.contacts[0].normal);
            rb.velocity = direction * lastMagnitude;
        }
        
    }
}
