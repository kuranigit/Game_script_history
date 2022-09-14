using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    //���f���̃v���n�u�ϐ�������
    [SerializeField] private GameObject asteroidPrefab;
    //�v���n�u�ϐ��̍��W�i�[�ϐ���p��
    private Vector2 asteroidPrefabPos;
    //�������~��X�p����ݒ�
    private float span;
    private float currentTime = 0f;
    //�v���C���[�̏����擾
    [SerializeField] private GameObject player;
    private int[] plusMinus = {1, -1};
    private int plusMinusCount = 0;
    private float[] spanArray = { 1f,1.5f};
    private int spanCount = 0;


    void Start()
    {
        
    }

    void Update()
    {
        //���f���̐����X�p��������
        span = spanArray[spanCount];
        currentTime += GManager.instance.GetSetStarSpeed / 60;

        //span�b�����ɐ������~�点��
        if (currentTime > span)
        {
            if (GManager.instance.GetSetSumEnemyGenerate < 5)
            {
                //x���W���v���C���[�̈ړ���ɐݒ�
                asteroidPrefabPos = new Vector2(player.transform.position.x + Input.GetAxis("Horizontal"), 6f);
                //�v���n�u����
                Instantiate(asteroidPrefab, asteroidPrefabPos, Quaternion.identity);
                GManager.instance.GetSetSumEnemyGenerate++;
            }
            else if (GManager.instance.GetSetSumEnemyGenerate < 8)
            {
                if (spanCount == 0) spanCount++;
                for (int asPos = 1; asPos < 9; asPos++)
                {
                    //x���W��ݒ�
                    asteroidPrefabPos = new Vector2(asPos * plusMinus[plusMinusCount], 6f);
                    //�v���n�u����
                    Instantiate(asteroidPrefab, asteroidPrefabPos, Quaternion.identity);
                }
                GManager.instance.GetSetSumEnemyGenerate++;
                if (plusMinusCount == 0) plusMinusCount++;
                else plusMinusCount--;
            }
            currentTime = 0f;
        }
    }
}
