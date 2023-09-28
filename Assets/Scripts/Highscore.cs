using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    public static Highscore instance;

    public LeaderBoard[] leaderBoard = new LeaderBoard[3];

    private void Awake()
    {
        instance = this;
        for(int i = 0; i < leaderBoard.Length; i++)
        {
            leaderBoard[i].Get();
        }
    }


    public void ChechkLeaderboard(int score, string name)
    {
        for (int j = 0; j < leaderBoard.Length; j++)
        {
            if (score > leaderBoard[j].score)
            {
                for (int i = leaderBoard.Length - 1; i > j; i--)
                {
                    leaderBoard[i].ChangeStruct(leaderBoard[i - 1]);
                }

                leaderBoard[j].ChangeStruct(score, name);
                break;
            }
        }
    }
}

[Serializable]
public struct LeaderBoard
{
    public TMP_Text nameText;
    public string name;
    public int score;
    public int order;
    public void Save()
    {
        PlayerPrefs.SetString(order + "name", name);
        PlayerPrefs.SetInt(order + "score", score);
    }

    public void Get()
    {
        if (PlayerPrefs.HasKey(order + "name"))
        {
            ChangeScore(PlayerPrefs.GetInt(order + "score"));
            ChangeName(PlayerPrefs.GetString(order + "name"));
        }
        else
        {
            ChangeName(name);
        }
    }

    public void ChangeStruct(int m_score, string m_name)
    {
        ChangeScore(m_score);
        ChangeName(m_name);
        Save();
    }

    public void ChangeStruct(LeaderBoard target)
    {
        ChangeScore(target.score);
        ChangeName(target.name);
        Save();
    }

    public void ChangeName(string m_name)
    {
        name = m_name;
        nameText.SetText(name + " : " + score);
    }

    public void ChangeScore(int m_score)
    {
        score = m_score;
    }
}
