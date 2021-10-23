using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour
{
    float mouseX = 0f;
    float mouseY = 0f;

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    private float xRoatation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mouseY = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xRoatation -= mouseY;
        xRoatation = Mathf.Clamp(xRoatation, -90f, 90f);
        Debug.Log(xRoatation);

        transform.localRotation = Quaternion.Euler(xRoatation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
