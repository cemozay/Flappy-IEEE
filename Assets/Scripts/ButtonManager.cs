using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject StartButtonObj;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    public void StartButton()
    {
        gameManager.StartCoroutine(gameManager.StartSequence());
        StartButtonObj.SetActive(false);
        LivesSystem.instance.nameCanvas.SetActive(false);
    }
}
