using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_move2 : MonoBehaviour
{
    private float facingRotationSpeed = 3f;

    public Vector3 maju = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(h, 0, v)), Time.deltaTime * facingRotationSpeed);

        maju = new Vector3(-h, 0, v);
        maju = transform.TransformDirection(maju);
        transform.Translate(maju * Time.deltaTime);
    }
}
