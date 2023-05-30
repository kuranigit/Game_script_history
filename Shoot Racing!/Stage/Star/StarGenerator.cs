using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    //�����̃v���n�u�ϐ�������
    [SerializeField] private GameObject starPrefab;
    //�v���n�u�ϐ��̍��W�i�[�ϐ���p��
    private Vector2 starPrefabPos;
    //�������~��X�p����ݒ�
    private float span;
    private float currentTime;

    void Start()
    {

    }

    void Update()
    {
        StarGenerate();
    }

    void StarGenerate()//�X�^�[�𐶐�����֐�
    {
        //�����̃X�s�[�h�Ɣ���Ⴕ�Đ������~��X�p�������肷��
        span = 0.1f;
        currentTime += GManager.StarSpeed / GManager.FrameRate;

        //span�b�����ɐ������~�点��
        if (currentTime > span)
        {
            //x���W�������_���Ȓl�ɐݒ�(��ʓ�)
            float rnd = Random.Range(-8.0f, 8.0f);
            starPrefabPos = new Vector2(rnd, 6f);
            //�v���n�u����
            Instantiate(starPrefab, starPrefabPos, Quaternion.identity);
            currentTime = 0f;
        }
    }
}
