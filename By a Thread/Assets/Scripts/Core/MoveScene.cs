using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
  [SerializeField] private string loadLevel; //visible in inspector
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            AnalyticsResult res = Analytics.CustomEvent("Level 1 Success");
            Debug.Log("Result : " + res);
            SceneManager.LoadScene(loadLevel);

        }
    }
}
