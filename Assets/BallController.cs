using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
       
    }

    public Vector3 direction = Vector3.right;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            direction * 20f * Time.deltaTime);
    }
}
