using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cube : MonoBehaviour
{

    [Range(0, 50)]
    [SerializeField] protected float speed = 1.0f;
    protected Vector3 direction;
    BoxCollider boxCollider;

    
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();

        boxCollider.isTrigger = true;  
    }

    void Update()
    {
        transform.Rotate(direction * speed * Time.deltaTime);
    }




}
