using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

// ユニティちゃんの動作テスト
public class UnityChanMotion : MonoBehaviour
{
    Animator animator;
    public Collider weaponCllider;
    Rigidbody rb;
    float maxspeed = 300f;
    Vector3 jump = new Vector3(0, 1500f, 0);
    Vector3 force = new Vector3(0.0f, 0.0f, 250.0f);
    private float motion;
    private bool move = true;
    private bool jumpFlag = false;
    public PlayerHPBar hpBar;
    private float hp;
    public GameDirector gameDirector;
    private bool goolFlag = false;


    // スタート時に呼ばれる
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        weaponCllider.enabled = false;
        move = true;
        Debug.Log(move);
    }

    // フレーム毎に呼ばれる
    void Update()
    {
        hp = hpBar.CurrentHp();
        if (move)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
            {
                Debug.Log("攻撃");
                animator.SetBool("is_attacking", true);
                weaponCllider.enabled = true;
                animator.Play("Attack", 0, 0.19f);
                Invoke("ColliderReset", 0.4f);

            }
            else
            {
                animator.SetBool("is_attacking", false);
            }

            if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 1")) && jumpFlag == false)
            {
                jumpFlag = true;
                animator.SetBool("is_jumping", true);
                animator.Play("Jump");
                Invoke("Jump", 0.2f);
            }
            else
            {
                animator.SetBool("is_jumping", false);
            }
        }

        if (hp <= 0 && (!goolFlag))
        {
            move = false;
            animator.SetBool("is_running", false);
            gameDirector.OverText();
            Invoke("GameOver", 0.2f);
        }

        if (!move)
        {
            gameDirector.TitleText();
            gameDirector.ReturnTitle();
            gameDirector.EndGame();
            gameDirector.EndText();
        }
    }

    private void FixedUpdate()
    {
        motion = Input.GetAxisRaw("Horizontal");
        float speed = Mathf.Abs(rb.velocity.z);
        
        if (move)
        {
            // 前進
            if (motion == 1.0f)
            {
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                animator.SetBool("is_running", true);
                if (maxspeed > speed)
                {
                    //rb.AddForce(force);
                    transform.position += new Vector3(0, 0, 0.08f);
                }
            }
            else if (motion == -1.0f)
            {
                this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                animator.SetBool("is_running", true);
                if (maxspeed > speed)
                {
                    //rb.AddForce(-force);
                    transform.position += new Vector3(0, 0, -0.08f);
                }
            }
            else
            {
                animator.SetBool("is_running", false);
            }
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0, 2.0f), Mathf.Clamp(transform.position.z + motion * 0.1f, -10f, 120f));
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            JumpReset();
        }else if (collision.gameObject.tag == "goal" && (hpBar.CurrentHp() > 0.0f))
        {
            goolFlag = true;
            move = false;
            animator.SetBool("is_running",false);
            Invoke("GoalReact",0.2f);
            gameDirector.GoalText();
        }
    }

    private void ColliderReset()
    {
        weaponCllider.enabled = false;
    }
    private void Jump()
    {
        transform.position += new Vector3(0, 1.0f, 0);
    }
    private void JumpReset()
    {
        jumpFlag = false;
    }
    private void GoalReact()
    {
        transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
        animator.SetBool("goal", true);
    }
    private void GameOver()
    {
        animator.SetBool("over", true);
    }
}