using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TagScript : MonoBehaviour
{

    public AudioClip sound4;
    AudioSource audioSource;
    bool isCalledOnce = false;
    GameObject[] tagObjects;
    public Text EnemyText;
    public Text clearText;
    public Text continu;

    float timer = 0.0f;
    public float interval = 0.05f;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Check("Enemy");
            timer = 0;
        }
    }

    //シーン上のBlockタグが付いたオブジェクトを数える
    void Check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        Debug.Log(tagObjects.Length); //tagObjects.Lengthはオブジェクトの数
        EnemyText.text = $"SLIME:{tagObjects.Length}/5";
        if (tagObjects.Length == 0)
        {

            if (!isCalledOnce)
            {
                isCalledOnce = true;
                audioSource.PlayOneShot(sound4);
            }   
            clearText.text = "CLEAR!!";
            continu.text = "リトライ:Tab   スタート画面：Enter";
            if (Input.GetKey(KeyCode.Return))
                {
                    SceneManager.LoadScene("StartScene");
                }
            if (Input.GetKey(KeyCode.Tab))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
        }
    }
}