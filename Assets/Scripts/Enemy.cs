using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    float minY = -7f;

    [SerializeField] float hp = 1f;
    [SerializeField] GameObject Coin;

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

   
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if(transform.position.y< minY)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;

            if(hp<=0)
            {
                if(gameObject.tag == "Boss")
                {
                    GameManager.instance.SetGameClear();
                }
                Destroy(gameObject);
                Instantiate(Coin, transform.position, Quaternion.identity);
            }

            Destroy(other.gameObject);

        }
    }

 
    
}
