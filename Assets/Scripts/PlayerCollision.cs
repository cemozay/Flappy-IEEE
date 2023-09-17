using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public int score;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "detector")
        {
            score += 1;
        }

        if (other.gameObject.tag == "ground")
        {
            SceneManager.LoadScene(0);
            score = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene(0);
            score = 0;
        }
    }
}
