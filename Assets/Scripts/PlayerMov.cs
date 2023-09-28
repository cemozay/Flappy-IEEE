using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMov : MonoBehaviour
{
    [SerializeField] private float flySpeed = 2f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private TMP_Text scoreText;
    public static int OutputScore;
    [SerializeField] private string name;

    private Rigidbody2D rb;
    GameManager gameManager;
    [SerializeField] bool isAdmin;

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

        scoreText.text = LivesSystem.instance.score.ToString();
        name = LivesSystem.instance.nameInput.text;
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAdmin)
        {
            OutputScore++;
            return;
        }

        LivesSystem.instance.DestroyHeart();

        LivesSystem.instance.can -= 1;

        gameManager.GameOver();

        LivesSystem.instance.DestroyGameManager();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LivesSystem.instance.score += 1;
        LivesSystem.instance.scoreText.text = LivesSystem.instance.score.ToString();

    }
}
