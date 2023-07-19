using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{


     public float moveSpeed;

     public float damage;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
        damage = 1f;
        transform.rotation = Quaternion.Euler(0, 0, 90); 
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * moveSpeed;
        
    }
}
