using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float moveSpeed;
    [SerializeField] GameObject[] weapons;
    int weaponIndex = 0;


    [SerializeField] Transform shoot_transform;
    public float shootInterval = 0.5f;
    private float lastShotTime = 0f;

    public int hp;
    //float horizontalInput;
    //float verticalInput;
    public int start_Hp;


    // Start is called before the first frame update
    void Start()
    {
        hp = start_Hp;
        //gameObject.transform.position(0, -4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hp == 0)
        {
            GameManager.instance.SetGameOver();
            Destroy(this.gameObject);
        }


        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float toX = Mathf.Clamp(mousePos.x, -2.5f, 2.5f);

        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        if(GameManager.instance.isGameOver!=true)
        {
            shoot();
        }


    }

    void shoot()
    {
        
        if(Time.time - lastShotTime>shootInterval)
        {
            Instantiate(weapons[weaponIndex], shoot_transform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag=="Boss")
        {
            //Debug.Log("Game Over");
            hp-=1;
            
            //Destroy(gameObject);
            Destroy(collision.gameObject);

        }
        else if(collision.gameObject.tag=="Coin")
        {
            GameManager.instance.IncreaseCoin();
            Destroy(collision.gameObject);
        }


    }


    public void Upgrade()
    {
        weaponIndex += 1;
        if(weaponIndex >= weapons.Length)
        {
            weaponIndex = weapons.Length - 1;
        }
    }
    public void ShopOpen()
    {
        
    }
}
