using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Core;
using Platformer.Model;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

public class LifeManager : MonoBehaviour
{

    public int startingLives = 5;
    private int lifeCounter;
    public Text livesText;
    public GameObject gameOverScreen;
    public GameObject pauseMenuUI;
    PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    PlayerForceController player1;
    PlayerForceController player2;

    private bool isDead;
    
    // Start is called before the first frame update
    void Start()
    {
        player1 = model.player;
        player2 = model.player2;
        lifeCounter = startingLives;
    } 

    // Update is called once per frame
    void Update()
    {
        //respawn, -1 life
        if (lifeCounter > 0)
        {
            livesText.text = ": x" + lifeCounter;
        }
        // game over
        else {

            livesText.text = ": x0";

            //Trigger coinpicker to reset coins
            model.TotalCoinsCollected = -1;

            //

            pauseMenuUI.SetActive(true);
            gameOverScreen.SetActive(true);

            Time.timeScale = 0;
        }
    }
    public void AddLife(){
        lifeCounter++;
    }
    public void RemoveLife(){
        lifeCounter--;
    }
    public bool AlreadyDead() {
        return player1.CheckIsDead() || player2.CheckIsDead();

    }
    public bool GameOver() {
        return lifeCounter == 0;
    }
 
}   
