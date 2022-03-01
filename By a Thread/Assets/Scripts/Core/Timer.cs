using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float timeStart = 0.0f;
    public bool timerActive = true;

    // Use this for initialization
    void Start () {

    }
	
    // Update is called once per frame
    void Update () {
        if(timerActive){
            timeStart += Time.deltaTime;
        }
    }
}