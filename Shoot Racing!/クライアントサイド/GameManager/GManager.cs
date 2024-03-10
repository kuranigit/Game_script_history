using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    static private float objectSpeed;//�����̃X�s�[�h���Ǘ�����ϐ�
    static private int frameRate;//�t���[�����[�g�̒l�����ϐ�
    static private float userTime; //�o�ߎ��Ԃ��Ǘ�����ϐ�
    [SerializeField] private Text timeUI; //�o�ߎ��Ԃ�\������e�L�X�g�ϐ�
    static private bool goalFlag;//�S�[�����������`�F�b�N���邽�߂̕ϐ�
    private bool rankFlag;//�����L���O��\�����Ă��邩���`�F�b�N���邽�߂̕ϐ�
    private bool pauseFlag;
    private float currentTime;
    private bool startFlag;
    [SerializeField] static private List<RankingData> ranking;//�����L���O�ϐ�
    [SerializeField] private Text goalUI; //�S�[�������Ƃ��Ƀ^�C����\������e�L�X�g�ϐ�
    [SerializeField] private Text ranklUI; //�S�[�������Ƃ��Ƀ����N��\������e�L�X�g�ϐ�
    [SerializeField] private Text endUI;
    [SerializeField] private Text goalDistanceUI;
    [SerializeField] private Text rankingUI;
    [SerializeField] private Text userTimeUI;
    [SerializeField] private GameObject rankingPanel;
    [SerializeField] private StageGenerator stageGenerator;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private StarGenerator StarGenerator;
    [SerializeField] private BulletGenerator bulletGenerator;
    [SerializeField] private DBGetRanking dBGetRanking;
    [SerializeField] private DBUpdate dBUpdate;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private InputField nameField;
    [SerializeField] float startTime;
    [SerializeField] Text countText;
    [SerializeField] private AudioClip countSE;
    [SerializeField] private AudioSource seAudio;


    //�����̃X�s�[�h��get set���L�q
    static public float ObjectSpeed
    {
        get{ return objectSpeed; }
        set{ objectSpeed = value; }
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

    //�����L���O��get set
    static public List<RankingData> Ranking
    {
        get { return ranking; }
        set { ranking = value; }
    }


    void InitGame()
    {
        frameRate = 50;//�t���[�����[�g��50fps�ɌŒ�
        objectSpeed = 0.3f; 
        userTime = 0f;//�X�^�[�g���̎c�莞�Ԃ�30�ɏ�����
        currentTime = 0;
        goalFlag = false;//�X�^�[�g����false
        rankFlag = false;
        pauseFlag = false;
        startFlag = false;
        ranking = new List<RankingData>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InitGame();
        Debug.Log("�X�^�[�g���\�b�h���Ăяo���ꂽ");
        StartCoroutine("StartCount");
    }

    // Update is called once per frame
    void Update()
    {
        if (startFlag)
        {
            ActiveObject();
            if (!goalFlag)
            {
                IncreaseUserTime();
                DisplayTime();
                DisplayDistance();
                PauseProcess();
            }
            if (goalFlag)
            {
                GoalProcess();
            }
        }
    }

    void ActiveObject()
    {
        playerController.enabled = true;
        StarGenerator.enabled = true;
        stageGenerator.enabled = true;
        bulletGenerator.enabled = true;
        canvas.SetActive(true);
        audioSource.enabled = true;
    }

    IEnumerator StartCount()
    {
        countText.text = "Zkey:Shot  Xkey:Accel\nLeft and Right keys:Move\nAre you ready?(Enter)";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        seAudio.PlayOneShot(countSE);
        while (true)
        {
            currentTime += Time.deltaTime;
            countText.text = $"{(int)(startTime - currentTime + 1.0f)}";
            yield return null;

            if (currentTime > startTime) break;
        }

        Debug.Log("�t���b�O����");
        countText.text = "Go!";
        startFlag = true;

        yield return new WaitForSeconds(1);
        countText.text = "";
    }

   
    private void IncreaseUserTime()//���Ԃ����ɂ�o�ߎ��Ԃ𑝂₷�֐�
    {
        userTime += Time.deltaTime;
    }

    private void DisplayTime()//�c�莞�Ԃ�\������֐�
    {
        timeUI.text = "Time:" + userTime.ToString("f3");
    }

    private void DisplayDistance()//�S�[���܂ł̋�����\������֐�
    {
        goalDistanceUI.text = "Goal--" + ((410f - (stageGenerator.GetSumObstacleGenerate()) + 4f)).ToString("f0") + "km";
    }

    private void PauseProcess()
    {
        if (pauseFlag)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseFlag = false;
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                InitGame();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1;
                InitGame();
                SceneManager.LoadScene("TitleScene");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseFlag = true;
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }
        }
    }

    IEnumerator DisplayRanking()//�����L���O��\������֐�
    {
        rankFlag = true;
        userTimeUI.text = "Your Time:" + userTime.ToString("f3");
        rankingPanel.SetActive(true);
        yield return dBGetRanking.StartCoroutine(dBGetRanking.GetRankingData());
        MakeRankingUI();
        
    }

    private void CloseRanking()//�����L���O�����֐�
    {
        rankFlag = false ;
        rankingUI.text = "";
        userTimeUI.text = "";
        ranking.Clear();
        rankingPanel.SetActive(false);
    }

    IEnumerator SubmitUserTime()//���[�U�[�̃^�C�����T�[�o�[�ɑ��M����֐�
    {
        if (nameField.interactable && nameField.text.Length > 0)
        {
            ranking.Clear();
            rankingUI.text = "";
            nameField.interactable = false;
            yield return dBUpdate.StartCoroutine(dBUpdate.SendTime(nameField.text, userTime));
            yield return dBGetRanking.StartCoroutine(dBGetRanking.GetRankingData());
            MakeRankingUI();
            
        }
    }

    private void MakeRankingUI()//�����L���O�ꗗ�̃e�L�X�g���쐬����֐�
    {
        rankingUI.text += "\n";
        if (ranking[0].Score > 0)
        {
            for (int i = 0; i < ranking.Count; i++)
            {
                rankingUI.text += (i + 1).ToString().PadRight(5) + ranking[i].UserName + ":" + ranking[i].Score + "\n";
            }
        }
        else
        {
            rankingUI.text += "Network error".PadLeft(8) + "\nPlease check network.";
        }
    }

    public void UpdateRanking()//�����L���O���X�V����֐�
    {
        StartCoroutine(SubmitUserTime());
    }

    private void GoalProcess()//�S�[���������Ƃ��̏���
    {
        timeUI.text = "";
        goalDistanceUI.text = "";
        goalUI.text = "Time:" + userTime.ToString("f3");
        endUI.text = "Title:Enter Retry:Rkey\nWorld Ranking:Space";

        if (userTime < 60f)
        {
            ranklUI.text = "You are GOD!!!!!";
        }
        else if(userTime < 65f)
        {
            ranklUI.text = "RANK:A";
        }
        else if(userTime < 75f)
        {
            ranklUI.text = "RANK:B";
        }
        else if (userTime < 85f)
        {
            ranklUI.text = "RANK:C";
        }
        else
        {
            ranklUI.text = "RANK:D";
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (rankFlag) CloseRanking();
            else StartCoroutine("DisplayRanking");
        }

        if (Input.GetKey(KeyCode.R) && (!rankFlag))
        {
            InitGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Return) && (!rankFlag))
        {
            InitGame();
            SceneManager.LoadScene("TitleScene");
        }


    }
}
