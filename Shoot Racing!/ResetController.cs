using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Reset();
    }

    private void Reset()//ゲームのリセットを処理する関数(Rキーでリセット可能)
    {
        //シーン再読み込み(リセット)
        if (Input.GetKeyDown("r"))
        {
            GManager.GetSetStarSpeed = 0.8f;
            SceneManager.LoadScene(0);
        }
    }
}
