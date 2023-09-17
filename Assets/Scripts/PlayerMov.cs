using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMov : MonoBehaviour
{
    [SerializeField] private float flySpeed = 2f;
    [SerializeField] private float rotationSpeed = 5f;
    private Rigidbody2D rb;
    GameManager gameManager;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * flySpeed;
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }
}
