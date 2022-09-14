using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public GameObject goalText;
    public GameObject overText;
    public GameObject Text;
    public GameObject GameEndText;
    public GameObject goalMeasure;
    public GameObject player;
    public GameObject goalFlag;
    public GameObject pauseUIPrefab;
    private GameObject pauseUIInstance;
    private Text text;
    private Text overt;
    private Text titlet;
    private Text endText;
    private Text goalMeasureText;
    // Start is called before the first frame update
    void Start()
    {
        text = goalText.GetComponent<Text>();
        overt = overText.GetComponent<Text>();
        titlet = Text.GetComponent<Text>();
        endText = GameEndText.GetComponent<Text>();
        goalMeasureText = goalMeasure.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GoalMeasure();
        PoseGame();
        PoseRetunTitle();
    }

    public void GoalText()
    {
        text.text = "Goal!";
    }

    public void OverText()
    {
        overt.text = "GameOver...";
    }
    public void TitleText()
    {
        titlet.text = "Enter:タイトルにもどる";
    }

    public void EndText()
    {
        endText.text = "Esc:ゲームしゅうりょう";
    }

    public void GoalMeasure()
    {
        float lenth = (goalFlag.transform.position.z - player.transform.position.z) / 95 * 100;
        if(lenth > 0) {
            goalMeasureText.text = "ゴールまでのこり" + lenth.ToString("F0") + "m";
        }
        else
        {
            goalMeasureText.text = "ゴールまでのこり0m";
        }
        
    }

    public void ReturnTitle()
    {
        if (Input.GetKey(KeyCode.Return))
        SceneManager.LoadScene("Title");
    }

    public void EndGame()
    {
        //Escが押された時
        if (Input.GetKey(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
            #else
                Application.Quit();//ゲームプレイ終了
            #endif
        }
    }

    private void PoseGame()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (pauseUIInstance == null)
            {
                pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
                Time.timeScale = 0f;
            }
            else
            {
                Destroy(pauseUIInstance);
                Time.timeScale = 1f;
            }
        }
    }

    private void PoseRetunTitle()
    {
        if (pauseUIInstance != null)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Title");
                Time.timeScale = 1f;
            }
        }
    }
}
