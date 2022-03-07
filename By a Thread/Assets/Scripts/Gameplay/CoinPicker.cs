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

    private void OnTriggerEnter2D(Collider2D other){
        
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        
        if(other.transform.tag == "Coin")
        {
            model.TotalCoinsCollected += 1;
            coin ++;
            //textCoins.text = "X" + coin.ToString();
            textCoins.text = "X" + model.TotalCoinsCollected.ToString();
            Destroy(other.gameObject);
        }
    }
}
