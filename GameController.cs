using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int score;
    public GameObject judgeCube;
    
    public TextMeshProUGUI scoreText;

    public GameObject gameEndButton;
    public GameObject retryButton;
    public GameObject zantetsuButton;

    public AudioClip soundStady;
    private AudioSource audioSource;
    
    private void Awake()
    {
        scoreText.text = "";
        retryButton.SetActive(false);
        gameEndButton.SetActive(false);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        score = 0;
    }
    
    public void AddScore()
    {
        score += 1;
    }

    public void OnClickedZantetsuButton()
    {
        zantetsuButton.SetActive(false);
        audioSource.PlayOneShot(soundStady);
        judgeCube.SendMessage("ShotCube");
    }

    private void LateUpdate()
    {
        scoreText.text = "Score: " + score;
    }

    public void ViewGameEndScreen()
    {
        retryButton.SetActive(true);
        gameEndButton.SetActive(true);
    }

    public void OnClickedRetryButton()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }

    public void OnClickedGameEndButton()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
