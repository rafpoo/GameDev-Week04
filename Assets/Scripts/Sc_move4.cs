using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_move4 : MonoBehaviour
{
    float minimumY = -60f;
    float maximumY = 60f;
    float speedPutar = 5f;
    float rotationY = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // putar hero horizontal
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * speedPutar;
        transform.localEulerAngles = new Vector3(0, rotationX, 0);

        // putar camera vertical
        rotationY = Input.GetAxis("Mouse Y") * speedPutar;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        Camera.main.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);

        // senjata perlu diputar ?
        transform.Find("nose").transform.localEulerAngles = new Vector3(-rotationY, 0, 0);

        // gerakan maju mundur karakter
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 5f);
    }
}
