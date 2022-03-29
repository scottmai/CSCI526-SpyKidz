using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{

    public int startingLives = 5;
    private int lifeCounter;
    public Text livesText;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        lifeCounter = startingLives;
    } 

    // Update is called once per frame
    void Update()
    {
        print(lifeCounter + " lives");
        if (lifeCounter > 0)
        {
            livesText.text = "x " + lifeCounter;
        }
        else {
            livesText.text = "x 0 GAME OVER";
            
            //idk how this works
            gameOverScreen.SetActive(true);

            Time.timeScale = 0;
        }
    }
    public void addLife() {
        lifeCounter++;
    }
    public void removeLife()
    {
        lifeCounter--;
    }
}   
