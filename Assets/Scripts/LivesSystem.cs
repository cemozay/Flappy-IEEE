using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesSystem : MonoBehaviour
{

    public static LivesSystem instance;
    public List<GameObject> hearts = new List<GameObject>();
    public int can;
    public int score, highscore_;
    public GameObject nameCanvas;
    public TMP_InputField nameInput;
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
        if(can == 0)
        {
            Destroy(gameObject);
            nameCanvas.SetActive(true);
            Highscore.instance.ChechkLeaderboard(highscore_, nameInput.text);
        }
    }

    public void AzaltCan()
    {
        can--;
        // Can say�s�n� azaltt�ktan sonra canlar� g�rsel olarak g�ncelle
    }

    public void HighScoreDetector()
    {
        if (score > highscore_)
        {
            highscore_ = score;
        }
    }

    public void DestroyHeart()
    {
        GameObject heartToRemove = hearts[0];
        Destroy(heartToRemove);
        hearts.RemoveAt(0);
    }

}
