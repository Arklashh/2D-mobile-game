using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isWinning;
    public GameObject gameOverScreen;
    public GameObject winningScreen;
    public GameObject pauseMenuScreen;

    public CinemachineVirtualCamera VCam;
    public GameObject playerPrefab;


    private void Awake()
    {
        GameObject player = Instantiate(playerPrefab);
        VCam.m_Follow = player.transform;
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }

        if (isWinning)
        {
            winningScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen?.SetActive(false);
    }
}
