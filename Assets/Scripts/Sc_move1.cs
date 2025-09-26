using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_move1 : MonoBehaviour
{
    private float kecepatan = 5f;
    private float putaran = 5f;
    private float kecepatanLoncat = 10f;
    private Rigidbody rb;

    public bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * kecepatanLoncat, ForceMode.Impulse);
            isGrounded = false;
        }

        transform.Translate(new Vector3(0, 0, v) * kecepatan * Time.deltaTime);
        transform.Rotate(new Vector3(0, h, 0) * putaran);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("land"))
        {
            isGrounded = true;
        }
    }
}
