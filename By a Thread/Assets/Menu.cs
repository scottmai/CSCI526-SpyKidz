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
		btn.onClick.AddListener(loadLevel1);

        btn = selectLevel.GetComponent<Button>();
		btn.onClick.AddListener(loadSelectLevel);
    }

    void loadLevel1(){
        SceneManager.LoadScene("Level1");
    }

    void loadSelectLevel(){
        SceneManager.LoadScene("LevelSelect");
    }
}
