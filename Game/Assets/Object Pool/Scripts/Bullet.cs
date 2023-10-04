using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }


    private void OnBecameInvisible()
    {
        ObjectPoolManager.instance.InsertQueue(gameObject);
        Destroy(gameObject);
    }

}
