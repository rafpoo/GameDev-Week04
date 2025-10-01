using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_move3 : MonoBehaviour
{
    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // perputaran berdasarkan posisi kamera
        if (h != 0 || v != 0)
        {
            Vector3 targetDirection = new Vector3(h, 0f, v);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = targetRotation;
        }

        // pergerakan berdasarkan posisi kamera
        transform.position += Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up) * v * speed * Time.deltaTime;
        transform.position += Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up) * h * speed * Time.deltaTime;
    }
}