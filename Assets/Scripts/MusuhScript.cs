using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusuhScript : MonoBehaviour
{
    [Header("Patrol Settings")]
    [SerializeField] Transform[] point;   // daftar point patrol
    int idxPoint = 0;
    [SerializeField] float speedPatrol = 3f;
    [SerializeField] float speedChase = 3f;

    [Header("Chase Settings")]
    [SerializeField] Transform hero;      // drag hero ke sini
    bool isChasing = false;               // status musuh
    bool heroInRange = false;             // status trigger

    bool isWaiting = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing && heroInRange)
        {
            ChaseHero();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (isWaiting) return;

        Vector3 posTarget = new Vector3(point[idxPoint].position.x, transform.position.y, point[idxPoint].position.z);
        transform.position = Vector3.MoveTowards(transform.position, posTarget, speedPatrol * Time.deltaTime);

        Vector3 arah = posTarget - transform.position;
        if (arah != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(arah);

        if (Vector3.Distance(transform.position, posTarget) < 0.1f)
        {
            idxPoint++;
            if (idxPoint >= point.Length)
            {
                idxPoint = 0;
                StartCoroutine(WaitAtLastPoint(2f));
            }
        }
    }

    void ChaseHero()
    {
        Vector3 posHero = new Vector3(hero.position.x, transform.position.y, hero.position.z);
        transform.position = Vector3.MoveTowards(transform.position, posHero, speedChase * Time.deltaTime);

        Vector3 arah = posHero - transform.position;
        if (arah != Vector3.zero) transform.rotation = Quaternion.LookRotation(arah);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hero"))
        {
            heroInRange = true;
            isChasing = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("hero"))
        {
            heroInRange = true;
            isChasing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("hero"))
        {
            heroInRange = false;
            isChasing = false;
        }
    }

    private IEnumerator WaitAtLastPoint(float waktuTunggu)
    {
        isWaiting = true;
        yield return new WaitForSeconds(waktuTunggu);
        isWaiting = false;
    }
}
