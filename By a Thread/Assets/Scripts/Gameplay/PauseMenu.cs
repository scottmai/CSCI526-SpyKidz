using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Platformer.Core;
using Platformer.Model;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    private LifeManager lifeManager;
    private PlatformerModel model = Simulation.GetModel<PlatformerModel>();

    void Start() {

        pauseMenuUI.SetActive(false);
        lifeManager = FindObjectOfType<LifeManager>();
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
        lifeManager.RemoveLife();
        PlayerForceController player = model.player;
        PlayerForceController player2 = model.player2;

        player.Teleport(player.spawnPoint.transform.position);
        player2.Teleport(player2.spawnPoint.transform.position);

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void Quit() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void TryAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
