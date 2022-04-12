using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = level1.GetComponent<Button>();
		btn.onClick.AddListener(loadLevel1);

        btn = level2.GetComponent<Button>();
		btn.onClick.AddListener(loadLevel2);

        btn = level3.GetComponent<Button>();
		btn.onClick.AddListener(loadLevel3);
    }

    void loadLevel1(){
        SceneManager.LoadScene("Level1");
    }

    void loadLevel2(){
        SceneManager.LoadScene("Level2");
    }

    void loadLevel3(){
        SceneManager.LoadScene("Level3");
    }
}
