using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusuhScript : MonoBehaviour
{
    [SerializeField] Transform[] point;
    int idxPoint = 0;
    float kec = 3f;

    private bool isWaiting = false;
    private bool isChasing = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // kalo lagi nunggu, gausa jalan
        if (isWaiting) return;

        Vector3 posTarget = new Vector3(point[idxPoint].position.x, transform.position.y, point[idxPoint].position.z);
        transform.position = Vector3.MoveTowards(transform.position, posTarget, kec * Time.deltaTime);

        Vector3 posPutaranTarget = posTarget - transform.position;
        if (posPutaranTarget != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(posPutaranTarget, Vector3.up);

        Vector3 posMusuh = new Vector3(transform.position.x, point[idxPoint].position.y, transform.position.z);

        if (Vector3.Distance(posMusuh, point[idxPoint].position) < 0.1f)
        {
            idxPoint += 1;
            if (idxPoint >= point.Length)
            {
                idxPoint = 0;
                StartCoroutine(WaitAtLastPoint(2f));
            }
        }
    }

    private IEnumerator WaitAtLastPoint(float waktuTunggu)
    {
        isWaiting = true;
        yield return new WaitForSeconds(waktuTunggu);
        isWaiting = false;
    }
}
