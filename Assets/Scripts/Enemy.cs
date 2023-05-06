using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody enemyRb;
    private GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        Vector3 lookDirection = (playerObj.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection*speed);
    }
}
