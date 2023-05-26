using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;

    private Rigidbody2D rg;
    
    // Start is called before the first frame update
    void Start() // phuong thuc khoi tao - chay vao 1 lan khi gameObject dc khoi tao
    {
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public float speed = 10f;
    public GameObject ball;

    // Update is called once per frame
    private bool isLand = false;
    void Update()//
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isLand)
            {
                rg.AddForce(transform.up * 400f);
                isLand = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetInteger("status",0);
            ball.GetComponent<BallController>().direction = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetInteger("status",3);
            ball.GetComponent<BallController>().direction = Vector3.left;
            ball.GetComponent<SpriteRenderer>().flipX = true;

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("status",2);
            ball.GetComponent<SpriteRenderer>().flipX = false;
            ball.GetComponent<BallController>().direction = Vector3.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ball, transform.position,
                Quaternion.identity);
            // ball : làm xuất hiện 1 gameObject ball trên màn hình
            // transform.position : có vị trí trùng với nhân vật 
            //Quaternion.identity : và rotation mặc định 
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            //move(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move(Vector3.down);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            move(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move(Vector3.right);
        }
        
    }

    void move(Vector3 direction)
    {
        transform.Translate(direction 
                            * speed * Time.deltaTime);
    }
    
    // va cham thong thuong : collision 
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("STAY");
        if (other.collider.CompareTag("land"))
        {
            isLand = true;
        }
        else
        {
            isLand = false;
        }
        if (other.gameObject.name == "items_7")
        {
            Destroy(other.gameObject);
            // speed = speed * 2;
            // cho nhân vật to gấp đôi 
            // cho nhân vật nhảy cao gấp đôi 
            // cho nhân vật biến hình thành nhân vật khác
            // cho nhân vật thu nhỏ 2 lần 
            // mỗi lần ăn nấm thì tăng mạng cho nhân vật 
        }
    }
    private void OnCollisionStay(Collision other)
    {
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        
    }
    // va cham di xuyen qua : trigger 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "items_7")
        {
            Destroy(other.gameObject);
            // speed = speed * 2;
            // cho nhân vật to gấp đôi 
            // cho nhân vật nhảy cao gấp đôi 
            // cho nhân vật biến hình thành nhân vật khác
            // cho nhân vật thu nhỏ 2 lần 
            // mỗi lần ăn nấm thì tăng mạng cho nhân vật 
        }
    }
}
