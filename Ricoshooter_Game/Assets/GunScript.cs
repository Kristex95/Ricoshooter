using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 25f;
    [SerializeField] Camera PlayerCam;
    private Transform defaultRotation;

    void Awake()
    {
        defaultRotation = this.transform;
    }

    void Start()
    {

        PlayerCam.GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, 100f))
        {
            Transform objectHit = hit.transform;
            transform.rotation 
        }
        else
        {
            transform.rotation = Quaternion.Euler(defaultRotation.rotation.x, defaultRotation.rotation.y, defaultRotation.rotation.z);
        }
    }
}
