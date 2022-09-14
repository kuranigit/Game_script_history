using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class unitychan : MonoBehaviour
{
    public GameObject _bullet;
    public int _hp = 5;
    int _chargecount = 0;
    public Text ballText;
    public Text hpText;
    public Text overText;
    public Text continu;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound5;
    AudioSource audioSource;
    bool isCalledOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _chargecount >= 1)
        {
            GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<ball>().SetCharacterObject(gameObject);
            _chargecount = _chargecount - 1;
            if (_hp >= 1)
            {
                audioSource.PlayOneShot(sound1);
            }
        }
        ballText.text = $"BALL:{_chargecount}";

        if (transform.position.y < -10.2f)
        {
            Debug.Log("やられた");
            hpText.text = $"HP:0/5";
            overText.text = "GAME OVER...";
            continu.text = "リトライ:Tab   スタート画面：Enter";
            if (!isCalledOnce)
            {
                isCalledOnce = true;
                audioSource.PlayOneShot(sound3);
            }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "charge")
        {
            _chargecount = _chargecount + 1;
            if (_hp >= 1)
            {
                audioSource.PlayOneShot(sound5);
            }
        }
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("当たった");
            _hp = _hp-1;
            if (_hp >= 1)
            {
                audioSource.PlayOneShot(sound2);
            }
            if (_hp <= 0)
            {
                Debug.Log("やられた");
                hpText.text = $"HP:0/5";
                overText.text = "GAME OVER...";
                continu.text = "リトライ:Tab   スタート画面：Enter";
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    audioSource.PlayOneShot(sound3);
                }
                if (Input.GetKey(KeyCode.Return))
                {
                    SceneManager.LoadScene("StartScene");
                }
                if (Input.GetKey(KeyCode.Tab))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            else
            {
                hpText.text = $"HP:{_hp}/5";
            }
        }
    }
}
