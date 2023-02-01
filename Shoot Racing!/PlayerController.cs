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
    private float minX = -8f;// x�������̈ړ��͈͂̍ŏ��l
    private float maxX = 8f;// x�������̈ړ��͈͂̍ő�l
    [SerializeField] private AudioClip colSound;
    AudioSource audioSource;

    void Start()
    {
        //�v���C���[��transform���i�[����
        myTransform = this.transform;
        //�v���C���[�̍��W���i�[����ϐ��Ƃ���pos��p��
        pos = transform.position;
        //audioComponent���擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        colObstacleProcess();
        PlayerMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //������Q���ɏՓ˂�����
        if (collision.gameObject.tag == "obstacle")
        {
            colObstacle = true;
            Destroy(collision.gameObject);
            //period�b�ň������
            this.rotSpeed = 360f / period;
            audioSource.PlayOneShot(colSound,0.5f);
        }

        //�����S�[���ɏՓ˂�����
        if (collision.gameObject.tag == "goal")
        {
            GManager.GetSetGoalFlag = true;
            Debug.Log("�S�[��");
            Destroy(collision.gameObject);
        }
      
    }

    private void PlayerMove()//�v���C���[�ړ�����������֐�
    {
        //�v���C���[�̈ړ���������
        float move = Input.GetAxisRaw("Horizontal");

        //�v���C���[�ړ�
        pos += new Vector2(move, 0) * Time.deltaTime * 6;
        // x�������̈ړ��͈͐���
        pos.x = Mathf.Clamp(pos.x,minX,maxX);

        myTransform.position = pos;

        //��Q���Փˏ��������Ă��Ȃ��Ԃ̓A�N�Z�����ł���
        if (!colObstacle)
        {
            if (Input.GetKey(KeyCode.X))
            {
                //GManager.instance.GetSetStarSpeed = 1.2f;
                IncreasePlayerSpeed(0.7f,0.3f,1.5f);
            }
            else//����������Ă��Ȃ��ꍇ
            {
                //GManager.instance.GetSetStarSpeed = 0.3f;
                ReducePlayerSpeed(2.0f,0.3f,1.5f);
            }
        }
    }

    private void IncreasePlayerSpeed(float acceleration,float minSpeed,float maxSpeed)
    {
        GManager.GetSetStarSpeed += Time.deltaTime * acceleration;
        GManager.GetSetStarSpeed = Mathf.Clamp(GManager.GetSetStarSpeed,minSpeed,maxSpeed);
    }

    private void ReducePlayerSpeed(float acceleration, float minSpeed, float maxSpeed)
    {
        GManager.GetSetStarSpeed -= Time.deltaTime * acceleration;
        GManager.GetSetStarSpeed = Mathf.Clamp(GManager.GetSetStarSpeed,minSpeed,maxSpeed);
    }

    private void colObstacleProcess()//��Q���Փˏ������Ǘ�����֐� 
    {
        //��Q���Փˎ��̏���
        if (colObstacle)
        {
            transform.Rotate(0, 0, this.rotSpeed * Time.deltaTime, Space.World);
            currentTime += Time.deltaTime;
            ReducePlayerSpeed(2.5f, 0.3f, 1.2f);
        }

        //1��]�������]�I��
        if (currentTime > period * colObstacleCount)
        {
            this.rotSpeed = 0f;
            currentTime = 0f;
            colObstacle = false;
            myTransform.eulerAngles = Vector3.zero;
        }
    }
}
