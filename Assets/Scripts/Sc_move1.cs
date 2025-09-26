using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_move1 : MonoBehaviour
{
    private float kecepatan = 5f;
    private float putaran = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(0, 0, v) * kecepatan * Time.deltaTime);
        transform.Rotate(new Vector3(0, h, 0) * putaran);
    }
}
