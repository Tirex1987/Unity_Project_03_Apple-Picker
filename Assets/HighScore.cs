using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;   // ���������� ��� ������ � ���

public class HighScore : MonoBehaviour
{
    static public int score = 1000;

    void Awake()
    {
        //���� �������� HighScore ��� ���������� � PlayerPrefs, ��������� ���
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        //��������� ������ ���������� HighScore � ���������
        PlayerPrefs.SetInt("HighScore", score);
    }

    // Update is called once per frame
    void Update()
    {
        TMPro.TextMeshProUGUI gt = this.GetComponent<TMPro.TextMeshProUGUI>();
        gt.text = "High Score: " + score;

        //�������� �������� HighScore � PlayerPrefs, ���� ����������
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}