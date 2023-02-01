using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    //�e�̃v���n�u�ϐ�������
    [SerializeField] private GameObject bulletPrefab;
    //�e�ϐ��̍��W�i�[�ϐ���p��
    private Vector2 bulletPrefabPos;
    //�v���C���[�̏����擾
    [SerializeField] private GameObject player;
    private float interval = 0.4f; // �e�𐶐�����Ԋu
    private float timer = 0.0f; //�e�𐶐�����Ԋu�̎��ԃJ�E���g�p�̃^�C�}�[
    [SerializeField]private AudioClip shotSound;
    AudioSource audioSource;

    void Start()
    {
        //audioComponent���擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //X�{�^����������A�^�C�}�[�ϐ���0�ȉ��̎��e�𔭎�
        if (Input.GetKey(KeyCode.Z) && timer <= 0.0f)
        {
            BulletGenerate();
        }

        // �^�C�}�[�̒l�����炷
        if (timer > 0.0f)
        {
            ReduceTimer();
        }
    }

    private void BulletGenerate()
    {
        //x���W���v���C���[�̂�����W�ɐݒ�
        bulletPrefabPos = player.transform.position;
        //�v���n�u����
        Instantiate(bulletPrefab, bulletPrefabPos, Quaternion.identity);
        //�^�C�}�[��������
        timer = interval;
        //�e���˂̉���炷
        audioSource.PlayOneShot(shotSound,0.08f);
    }

    private void ReduceTimer()
    {
        timer -= Time.deltaTime;
    }

    
}
