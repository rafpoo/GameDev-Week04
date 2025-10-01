using System;
using UnityEngine;

public class Sc_move3 : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    [SerializeField] float rotationSpeed = 10f;

    void Update()
    {
        float updatedSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            updatedSpeed *= 2;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(h, 0f, v);

        if (input.sqrMagnitude > 0.01f)
        {
            // arah relatif kamera
            Vector3 targetDirection = Camera.main.transform.TransformDirection(input);
            targetDirection.y = 0f;

            // rotasi smooth
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // gerak
            transform.position += targetDirection.normalized * updatedSpeed * Time.deltaTime;
        }
    }
}
