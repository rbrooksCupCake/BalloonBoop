using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBehavior : MonoBehaviour
{
    public uint Score = 0;
    public TextMeshProUGUI ScoreText;

    public const string FiveDigitFormat = "D5";
    private void Awake()
    {
        Score = 0;
    }

    public void Reset()
    {
        Score = 0;
    }

    public void AddPoint()
    {
        ++Score;
        ScoreText.text = Score.ToString(FiveDigitFormat);
    }
}
