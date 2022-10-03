using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100;


    private void Awake()
    {
        Destroy(gameObject, 1.0f);
    }

    void Update()
    {
        transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
    }
}
