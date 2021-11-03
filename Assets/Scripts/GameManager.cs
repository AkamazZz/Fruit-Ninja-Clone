using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score elements")]
    [SerializeField] private int _score;
    private int _highestScore;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highestScoreText;
    [Header("Game over elements")]
    [SerializeField] private GameObject _gameOverPanel;
    [Header("Sounds")]
    [SerializeField] private AudioClip[] _sliceSounds;
    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        GetHighestScore();
    }
    private void GetHighestScore()
    {
        if (PlayerPrefs.HasKey("Highscore")) { 
            _highestScore = PlayerPrefs.GetInt("Highscore");

            _highestScoreText.text = "Best: " + _highestScore.ToString();
        }
    }
    public void IncreaseScore(int addedPoints)
    {
        _score += addedPoints;
        _scoreText.text = "Best: " + _score.ToString();
        if(_score > _highestScore)
        {
            PlayerPrefs.SetInt("Highscore", _score);
            _highestScoreText.text =  _score.ToString();
        }
    }
    public void OnBombHit()
    {
        Debug.Log("Bomb hit");
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
            

    }
    public void RespawnScene()
    {
        Debug.Log($"{SceneManager.GetActiveScene().name} is respawned");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PlayRandomSliceSound()
    {
        _audioSource.PlayOneShot(_sliceSounds[0]);
    }
}
