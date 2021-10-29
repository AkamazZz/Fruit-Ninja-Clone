using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highScoreText;

    public void IncreaseScore(int addedPoints)
    {
        _score += addedPoints;
        _scoreText.text = _score.ToString();
    }
}
