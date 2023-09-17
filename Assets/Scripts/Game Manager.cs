using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pipePrefab;
    public List<GameObject> pipeList = new List<GameObject>();
    private Vector2 pipeTransform;
    private float YY;
    public float moveSpeed = 5.0f;
    void Start()
    {
        InvokeRepeating("pipeCreate", 0.1f, 1f);
        Invoke("pipeDestroy", 5f);
    }

    void Update()
    {

        foreach (var pipe in pipeList)
        {
            pipe.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void pipeCreate()
    {
        YY = Random.Range(-3.9f, 2.47f);
        pipeTransform = new Vector2(3.5f, YY);
        pipeList.Add(Instantiate(pipePrefab, pipeTransform,Quaternion.identity));
    }

    private void pipeDestroy()
    {
        StartCoroutine(PipeDestroyWithDelay());
    }
    private IEnumerator PipeDestroyWithDelay()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject firstPipe = pipeList[0];
            pipeList.RemoveAt(0);
            Destroy(firstPipe);

            yield return new WaitForSeconds(1f);
        }
    }
}
