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

    private void Reset()//�Q�[���̃��Z�b�g����������֐�(R�L�[�Ń��Z�b�g�\)
    {
        //�V�[���ēǂݍ���(���Z�b�g)
        if (Input.GetKeyDown("r"))
        {
            GManager.GetSetStarSpeed = 0.8f;
            SceneManager.LoadScene(0);
        }
    }
}
