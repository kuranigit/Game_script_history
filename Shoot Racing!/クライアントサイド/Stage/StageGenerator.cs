using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    //���f���̃v���n�u�ϐ�������
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private GameObject blackAteroidPrefab;
    //�v���n�u�ϐ��̍��W�i�[�ϐ���p��
    private Vector2 asteroidPrefabPos;
    //�v���C���[�̏����擾
    [SerializeField] private GameObject player;
    /*private int[] plusMinus = {1, -1};
    private int plusMinusCount = 0;
    private float[] spanArray = { 0.2f,1.5f};
    private int spanCount = 0;*/
    //�S�[���̃v���n�u�ϐ�������
    [SerializeField] private GameObject goalPrefab;
    //�v���n�u�ϐ��̍��W�i�[�ϐ���p��
    private Vector2 goalPrefabPos;
    private int sumObstacleGenerate;//�����̓G�𐶐�������
    private float span; //�I�u�W�F�N�g���~��X�p����ݒ�
    private float currentTime;//�X�p���ɒB����܂ł̕b���J�E���^��ݒ�

    void Start()
    {
        sumObstacleGenerate = 0;//���������G�̐���������
        currentTime = 0f;//�Q�[�����J�n������J�E���g�J�n
        span = 0.2f;
    }

    void Update()
    {
        StageGenerate();
    }

    void StageGenerate()//�X�e�[�W���̏��f���𐶐��Ǘ�����֐�
    {
        currentTime += GManager.ObjectSpeed * Time.deltaTime;

        //span�b�����ɏ��f�����~�点��
        if (currentTime > span)
        {
            if (sumObstacleGenerate <= 60)
            {
                SetSpan(0.5f);
                GenerateAsteroid();
            }
            else if(sumObstacleGenerate <= 100)
            {
                SetSpan(0.25f);
                GenerateAsteroid();
            }
            else if (sumObstacleGenerate <= 200)
            {
                SetSpan(0.15f);
                if (Random.Range(1, 5) == 1) GenerateBlackAsteroid();
                else GenerateAsteroid();
            }
            else if (sumObstacleGenerate <= 300)
            {
                SetSpan(0.09f);
                if (Random.Range(1, 3) == 1) GenerateBlackAsteroid(); 
                else GenerateAsteroid();
            }
            else if (sumObstacleGenerate < 410)
            {
                SetSpan(0.15f);
                if (Random.Range(1, 4) == 1) GenerateBlackAsteroid();
                else GenerateAsteroid();
            }
            else if(sumObstacleGenerate == 410){
                SetSpan(0.8f);
                GenerateAsteroid();
            }
            else if (sumObstacleGenerate == 411)
            {
                GoalGenerate();
            }
            sumObstacleGenerate++;
            currentTime = 0f;
        }
    }

    void GenerateAsteroid()
    {
        //x���W�������_���ɐݒ�
        asteroidPrefabPos = new Vector2(Random.Range(-8f, 8f), 6f);
        //�v���n�u����
        Instantiate(asteroidPrefab, asteroidPrefabPos, Quaternion.identity);
    }

    void GenerateBlackAsteroid()
    {
        //x���W�������_���ɐݒ�
        asteroidPrefabPos = new Vector2(Random.Range(-8f, 8f), 6f);
        //�v���n�u����
        Instantiate(blackAteroidPrefab, asteroidPrefabPos, Quaternion.identity);
    }

    void GoalGenerate()//�S�[���̐������Ǘ�����֐�
    {
        Debug.Log("�^�C����" + currentTime);

        if (currentTime > span)
        {
            Debug.Log("�S�[���𐶐����܂�");
            for (int asPos = -8; asPos <= 8; asPos++)
            {
                //x���W���v���C���[�̈ړ���ɐݒ�
                goalPrefabPos = new Vector2(asPos, 6f);
                //�v���n�u����
                Instantiate(goalPrefab, goalPrefabPos, Quaternion.identity);
            }
        }

    }

    public float GetSumObstacleGenerate()
    {
        return sumObstacleGenerate;
    }

    void SetSpan(float span)
    {
        this.span = span;
    }

    public float GetSpan()
    {
        return span;
    }
}
