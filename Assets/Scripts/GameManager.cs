using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player, obstacle;
    public PlayerCollision playerCollision;
    public Transform groundTransform;
    private float _newY, _XX;
    public List<GameObject> obstacleList = new List<GameObject>();
    private Vector3 insPosition;
    public TMP_Text scoreText;

    void Start()
    {
        ObstacleCreate(); ObstacleCreate(); ObstacleCreate(); ObstacleCreate();ObstacleCreate();ObstacleCreate();
        InvokeRepeating("ObstacleCreate", 7f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = groundTransform.position;
        newPosition.x = player.transform.position.x;
        groundTransform.transform.position = newPosition;
        scoreText.text = playerCollision.score.ToString();
    }


    void ObstacleCreate()
    {
        _XX = obstacleList.Count + 1;
        _newY = Random.Range(0.74f, 5.66f);
        insPosition = new Vector3(-7 + _XX * 8f, _newY, 0);
        obstacleList.Add(Instantiate(obstacle, insPosition, Quaternion.identity));
    }
}
