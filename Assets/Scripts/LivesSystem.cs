using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesSystem : MonoBehaviour
{

    public static LivesSystem instance;
    public List<GameObject> hearts = new List<GameObject>();
    public int can;
    public int score;
    public GameObject nameCanvas;
    public TMP_InputField nameInput;
    public TMP_Text scoreText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Ba�ka bir �rnek varsa bu �rne�i yok et
        }
    }


    // GameManager'� yok etmek i�in �zel bir fonksiyon
    public void DestroyGameManager()
    {
        if (can == 1)
        {
        }

        if(can == 0)
        {
            Destroy(gameObject);
        }
    }

    public void AzaltCan()
    {
        can--;
        // Can say�s�n� azaltt�ktan sonra canlar� g�rsel olarak g�ncelle
    }
    public void DestroyHeart()
    {
        GameObject heartToRemove = hearts[0];
        Destroy(heartToRemove);
        hearts.RemoveAt(0);
    }

    public void DestroyGameobject()
    {
        Destroy(gameObject);
    }

    public void LSHighScoreDetector()
    {
        Highscore.instance.ChechkLeaderboard(score, nameInput.text);
    }
}
