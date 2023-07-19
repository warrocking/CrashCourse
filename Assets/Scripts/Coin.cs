using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float minY=-7.0f;
    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    void Jump()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        float randomJumpForce = Random.Range(4f, 8f);//���Ʒ� �� ����
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;//���Ʒ� �� �ִ� ����2�ۼ�
        jumpVelocity.x = Random.Range(-2f, 2f);//�¿� ����
        rigidbody2D.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }


}
