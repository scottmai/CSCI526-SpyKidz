using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
      if(collider.gameObject.name.Contains("Coin")) {
        collider.gameObject.SetActive(false);
        IncreaseScore();
      }

    }

    void IncreaseScore() {
      score++;
      scoreText.text = score.ToString();
    }
}
