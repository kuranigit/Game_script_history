using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    //���f���̃v���n�u�ϐ�������
    [SerializeField] private GameObject asteroidPrefab;
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
    private int sumEnemyGenerate;//�����̓G�𐶐�������
    private float span; //�I�u�W�F�N�g���~��X�p����ݒ�
    private float currentTime;//�X�p���ɒB����܂ł̕b���J�E���^��ݒ�

    void Start()
    {
        sumEnemyGenerate = 0;//���������G�̐���������
        currentTime = 0f;//�Q�[�����J�n������J�E���g�J�n
        span = 0.2f;
    }

    void Update()
    {
        StageGenerate();
    }

    void StageGenerate()//�X�e�[�W���̃I�u�W�F�N�g�̐������Ǘ�����֐�
    {
        currentTime += GManager.GetSetStarSpeed * Time.deltaTime;

        //span�b�����ɏ��f�����~�点��
        if (currentTime > span)
        {
            if (sumEnemyGenerate <= 60)
            {
                SetSpan(0.5f);
                Asteroid1_400();
            }
            else if(sumEnemyGenerate <= 100)
            {
                SetSpan(0.25f);
                Asteroid1_400();
            }
            else if (sumEnemyGenerate <= 200)
            {
                SetSpan(0.15f);
                Asteroid1_400();
            }
            else if (sumEnemyGenerate <= 300)
            {
                SetSpan(0.09f);
                Asteroid1_400();
            }
            else if (sumEnemyGenerate < 410)
            {
                SetSpan(0.15f);
                Asteroid1_400();
            }
            else if(sumEnemyGenerate == 410){
                SetSpan(0.8f);
                Asteroid1_400();
            }
            else if (sumEnemyGenerate == 411)
            {
                GoalGenerate();
            }
            sumEnemyGenerate++;
            currentTime = 0f;
            Debug.Log(sumEnemyGenerate);
        }
    }

    void Asteroid1_400()
    {
        //x���W�������_���ɐݒ�
        asteroidPrefabPos = new Vector2(Random.Range(-8f,8f), 6f);
        //�v���n�u����
        Instantiate(asteroidPrefab, asteroidPrefabPos, Quaternion.identity);
    }

    /*void Asteroid5_8()
    {
        if (spanCount == 0) spanCount++;
        for (int asPos = 1; asPos <= 8; asPos++)
        {
            //x���W��ݒ�
            asteroidPrefabPos = new Vector2(asPos * plusMinus[plusMinusCount], 6f);
            //�v���n�u����
            Instantiate(asteroidPrefab, asteroidPrefabPos, Quaternion.identity);
        }
        if (plusMinusCount == 0) plusMinusCount++;
        else plusMinusCount--;
    }*/

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

    public float GetSumEnemyGenerate()
    {
        return sumEnemyGenerate;
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
