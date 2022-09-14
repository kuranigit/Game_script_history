using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    private float starSpeed;
    private int sumEnemyGenerate;//�����̓G�𐶐�������

    private void Awake()
    {
        if (instance == null)
        {
            Application.targetFrameRate = 60;
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //�����̃X�s�[�h��get set���L�q
    public float GetSetStarSpeed
    {
        get{ return starSpeed; }
        set{ starSpeed = value; }
    }

    //���������G�̐��̂�get set���L�q
    public int GetSetSumEnemyGenerate
    {
        get { return sumEnemyGenerate; }
        set { sumEnemyGenerate = value; }
    }

    void InitGame()
    {
        this.starSpeed = 0.8f; //�����̃X�s�[�h��0.8�ɏ�����
        this.sumEnemyGenerate = 0;//���������G�̐���������
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
