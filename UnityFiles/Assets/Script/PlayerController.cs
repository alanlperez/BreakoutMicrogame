using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    float input;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Horizontal");
        //(1,0) * input * speed = (1 * input * speed, (0 * input * speed) = 0)
        playerRigidbody.AddForce(Vector2.right * input * speed * Time.deltaTime);
    }
}
