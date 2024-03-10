using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector2 bulletPos;
    private Transform bulletTransform;
    [SerializeField] private GameObject explosionPrefab;//�����G�t�F�N�g�̃v���n�u�ϐ�������
    private Vector2 explosionPrefabPos;//�����G�t�F�N�g�ϐ��̍��W�i�[�ϐ���p��

    void Start()
    {
        //�e��transform���i�[����
        bulletTransform = this.transform;
        //�e�̍��W���i�[����ϐ��Ƃ���bulletPos��p��
        bulletPos = transform.position;
    }

    void Update()
    {
        BulletMove();
        BulletDestroy();
    }

    void BulletMove()//�e�̓������Ǘ�����֐�
    {
        //�e���ړ�������
        bulletPos += new Vector2(0,Time.deltaTime * 15);
        bulletTransform.position = bulletPos;
    }

    void BulletDestroy()//�e����ʊO�ɏo����폜����֐�
    {
        //��ʊO�ɂł���폜
        if (bulletPos.y > 6f)
            Destroy(this.gameObject);
    }

    private void ExplosionGenerate()
    {
        //�e�̂�����W�ɐݒ�
        explosionPrefabPos = bulletPos;
        //�����G�t�F�N�g����
        Instantiate(explosionPrefab, explosionPrefabPos, Quaternion.identity);
    }


    //������Q���ɏՓ˂�����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            ExplosionGenerate();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "blackObstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
