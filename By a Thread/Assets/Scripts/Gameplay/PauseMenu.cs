using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;

    void Start() {
      pauseMenuUI.SetActive(false);
    }
    // Update is called once per frame
    // void Update()
    // {
    //     if(gamePaused) {
    //       Resume();
    //     }
    //     else {
    //       Pause();
    //     }
    // }
    public void Resume() {
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      gamePaused = false;
    }
    public void Pause() {
      Debug.Log("PAUSING");
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      gamePaused = true;
    }
    public void Restart() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
    public void Quit() {
      Time.timeScale = 1f;
      SceneManager.LoadScene("Menu");
    }
}
