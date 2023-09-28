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
            Destroy(gameObject); // Baþka bir örnek varsa bu örneði yok et
        }
    }


    // GameManager'ý yok etmek için özel bir fonksiyon
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
        // Can sayýsýný azalttýktan sonra canlarý görsel olarak güncelle
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
