using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    static private float starSpeed;//�����̃X�s�[�h���Ǘ�����ϐ�
    static private int frameRate;//�t���[�����[�g�̒l�����ϐ�
    static private float timeLimit; //�o�ߎ��Ԃ��Ǘ�����ϐ�
    [SerializeField] private Text timeUI; //�o�ߎ��Ԃ�\������e�L�X�g�ϐ�
    static private bool goalFlag;//�S�[�����������`�F�b�N���邽�߂̕ϐ�
    [SerializeField] private Text goalUI; //�S�[�������Ƃ��Ƀ^�C����\������e�L�X�g�ϐ�
    [SerializeField] private Text ranklUI; //�S�[�������Ƃ��Ƀ����N��\������e�L�X�g�ϐ�
    [SerializeField] private Text endUI;
    [SerializeField] private Text goalDistanceUI;
    [SerializeField] private StageGenerator stageGenerator;

    //�����̃X�s�[�h��get set���L�q
    static public float StarSpeed
    {
        get{ return starSpeed; }
        set{ starSpeed = value; }
    }

    //�t���[�����[�g�����擾����get set
    static public int FrameRate
    {
        get { return frameRate; }
        set { frameRate = value; }
    }

    //�S�[�����������`�F�b�N����get set
    static public bool GoalFlag
    {
        get { return goalFlag; }
        set { goalFlag = value; }
    }


    void InitGame()
    {
        frameRate = 50;//�t���[�����[�g��50fps�ɌŒ�
        starSpeed = 0.8f; //�����̃X�s�[�h��0.8�ɏ�����
        timeLimit = 0f;//�X�^�[�g���̎c�莞�Ԃ�30�ɏ�����
        goalFlag = false;//�X�^�[�g����false
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InitGame();
        Debug.Log("�X�^�[�g���\�b�h���Ăяo���ꂽ");
    }

    // Update is called once per frame
    void Update()
    {
        if (!goalFlag)
        {
            IncreaseTimeLimit();
            DisplayTime();
            DisplayDistance();
        }
        if(goalFlag)
        {
            GoalProcess();
        }
    }

    private void IncreaseTimeLimit()//���Ԃ����ɂ�o�ߎ��Ԃ𑝂₷�֐�
    {
        timeLimit += Time.deltaTime;
    }

    private void DisplayTime()//�c�莞�Ԃ�\������֐�
    {
        timeUI.text = "Time:" + timeLimit.ToString("f3");
    }

    private void DisplayDistance()//�S�[���܂ł̋�����\������֐�
    {
        goalDistanceUI.text = "Goal�`" + ((410f - (stageGenerator.GetSumEnemyGenerate())) + 4f).ToString("f0") + "km";
    }

    private void GoalProcess()//�S�[���������Ƃ��̏���
    {
        timeUI.text = "";
        goalDistanceUI.text = "";
        goalUI.text = "Time:" + timeLimit.ToString("f3");
        endUI.text = "Title:Enter Exit:Esc";

        if (timeLimit < 60f)
        {
            ranklUI.text = "You are GOD!!!!!";
        }
        else if(timeLimit < 65f)
        {
            ranklUI.text = "RANK:A";
        }
        else if(timeLimit < 75f)
        {
            ranklUI.text = "RANK:B";
        }
        else if (timeLimit < 85f)
        {
            ranklUI.text = "RANK:C";
        }
        else
        {
            ranklUI.text = "RANK:D";
        }

        if (Input.GetKey(KeyCode.Escape))
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
        }

        if (Input.GetKey(KeyCode.Return))
        {
            InitGame();
            SceneManager.LoadScene("TitleScene");
        }


    }
}
