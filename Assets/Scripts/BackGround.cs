using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] Sprite bg1;
    [SerializeField] Sprite bg2;
    public float moveSpeed=3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;



        if (transform.position.y<-10)
            transform.position += new Vector3(0, 20.0f, 0);
        
        
    }
}
