using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using TMPro;
using Unity.Services.Analytics;
using Unity.Services.Core;


public class CoinPicker : MonoBehaviour
{
    private float coin = 0;
    public TextMeshProUGUI textCoins;

    PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    private GameObject[] coins;


    void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
    }

    void Update()
    {
        if (model.TotalCoinsCollected == -1) {
            model.TotalCoinsCollected = 0;
            coin = 0;
            textCoins.text = "X0";
            foreach (GameObject c in coins)
            {
                // print("comeback " + c.tag);
                c.SetActive(true);
            }
        }
        
        
    }
        private void OnTriggerEnter2D(Collider2D other){
        
        
        
        if(other.transform.tag == "Coin")
        {
            model.TotalCoinsCollected += 1;
            coin ++;
            //textCoins.text = "X" + coin.ToString();
            textCoins.text = "X" + model.TotalCoinsCollected.ToString();
            other.gameObject.SetActive(false);
        }
    }
}
