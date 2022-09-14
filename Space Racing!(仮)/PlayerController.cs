using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 pos;
    private Transform myTransform;
    private float rotSpeed = 0f;  //�v���C���[�̃X�s���X�s�[�h
    private float period = 0.4f;  //��Q���Փˎ��̉�]����
    private float currentTime = 0f;
    private bool colObstacle = false; //�Փˏ��������Ă����Ԃ��ǂ���(�������̏ꍇtrue)
    private int colObstacleCount = 1; //�Փˏ����̏d����

    void Start()
    {
        //�v���C���[��transform���i�[����
        myTransform = this.transform;
        //�v���C���[�̍��W���i�[����ϐ��Ƃ���pos��p��
        pos = transform.position;
    }

    void Update()
    {
        //�v���C���[�̈ړ���������
        float move = Input.GetAxisRaw("Horizontal");

        //�v���C���[�ړ�
        pos += new Vector2(move, 0) * Time.deltaTime * 8;
        myTransform.position = pos;

        //��Q���Փˎ��̏���
        if (colObstacle) {
            transform.Rotate(0, 0, this.rotSpeed * Time.deltaTime, Space.World);
            currentTime += Time.deltaTime;
            GManager.instance.GetSetStarSpeed = 0.5f;
        }


        //1��]�������]�I��(�Փˏ������d�����Ă���ꍇ�͂��̉񐔕���]���Ă���)
        if (currentTime > period * colObstacleCount)
        {
            this.rotSpeed = 0f;
            currentTime = 0f;
            colObstacle = false;
            myTransform.eulerAngles = Vector3.zero;
            GManager.instance.GetSetStarSpeed = 0.8f;
        }

        if (!colObstacle)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                GManager.instance.GetSetStarSpeed = 1.5f;
            }
            else
            {
                GManager.instance.GetSetStarSpeed = 0.8f;
            }
        }
        Debug.Log(GManager.instance.GetSetStarSpeed);

    }

    //������Q���ɏՓ˂�����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            /*//�Փˏ��������Ă���Œ��ɂ���ɏՓ˂�����d���Ƃ��ăJ�E���g
            if (colObstacle) colObstacleCount++;*/

            colObstacle = true;
            Destroy(collision.gameObject);
            //period�b�ň������
            this.rotSpeed = 360f / period;
        }
    }
}
