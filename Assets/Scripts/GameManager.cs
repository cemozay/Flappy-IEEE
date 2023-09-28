using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform pipeSpawnPos;
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float destroyDelay = 2f;
    [SerializeField] private float heightRange = 1f;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject GetReadyObj;
    private float timeSinceLastSpawn = 0f;

    void Start()
    {
        Time.timeScale = 0f;
        SpawnPipe();
    }

    public IEnumerator StartSequence()
    {
        GetReadyObj.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        GetReadyObj.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnPipe();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnPipe()
    {
        float yOffset = Random.Range(-heightRange, heightRange);

        Vector3 spawnPosition = pipeSpawnPos.position + new Vector3(0f, yOffset, 0f);
        GameObject newPipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);

        Destroy(newPipe, destroyDelay);
    }

    public void GameOver()
    {
        //PlayerMov.OutputScore = LivesSystem.instance.highscore_;
        gameOverCanvas.SetActive(true);

        if (LivesSystem.instance.can == 1)
        {
            LivesSystem.instance.nameCanvas.SetActive(true);
        }

        Time.timeScale = 0;
    }

    public void Restart()
    {

        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;

        if (LivesSystem.instance.can ==1)
        {
            LivesSystem.instance.DestroyGameobject();
            LivesSystem.instance.LSHighScoreDetector();

        }

        SceneManager.LoadScene("SampleScene");
    }
}
