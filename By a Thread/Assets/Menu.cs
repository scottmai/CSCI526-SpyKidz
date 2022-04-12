using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public Button begin;
    public Button selectLevel;
    public Button instructions;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = begin.GetComponent<Button>();
		btn.onClick.AddListener(onBegin);

        begin.GetComponentInChildren<Text>().text = "Start Level " + MainManager.lastLevelUnlocked;

        btn = selectLevel.GetComponent<Button>();
		btn.onClick.AddListener(loadSelectLevel);
    }

    void onBegin(){
        SceneManager.LoadScene("Level" + MainManager.lastLevelUnlocked);
    }

    void loadSelectLevel(){
        SceneManager.LoadScene("LevelSelect");
    }
}
