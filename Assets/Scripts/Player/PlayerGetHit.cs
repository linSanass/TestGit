using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGetHit : MonoBehaviour
{
    private Movement movement;
    private AttackPlayer attacker;
    private GameInput input;
    private Animator animator;
    public CharacterStats PlayercharacterStats;
    public ParticleSystem attackPlay;
    public PlayerHealthUI playerHealthUI;

    private float playerAttackTime = 0.5f;
    private float playEnterWaterTime = 1f;//����ˮ������

    public float setInvincibleTime = 1f;
    public float getHitTime = 0f;

    private float invincibleTime;//�޵�ʱ��

    private bool playerIsDie = false;

    private bool isBePoisoned = false;
    private float inPoisonTime = 0f;
    private float PoisonTime = 0f;
    
    // Start is called before the first frame update
    void Awake()
    {
        PlayercharacterStats = GetComponent<CharacterStats>();//��������趨������
        PlayercharacterStats.CurrentHealth = PlayercharacterStats.MaxHealth;
        invincibleTime = setInvincibleTime;
        movement = GetComponent<Movement>();
        input = GetComponent<GameInput>();
        attacker = GetComponent<AttackPlayer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (!playerIsDie)
        {
            input.moveAction += movement.Move2;
            input.jumpAction += movement.OnJump;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerIsDie)
        {
            UpdateTime();
            if (getHitTime < 0)
            {
                attackPlay.Stop();
            }
            if (playerAttackTime < 0)
            {
                input.AttackAction += attacker.Attacking;
                playerAttackTime = 0.5f;
            }
            if (isBePoisoned==true)
            {
                if (inPoisonTime <= 0) { isBePoisoned = false; return; }
                if(PoisonTime <= 0)
                {
                    PlayercharacterStats.GetDamage(PlayercharacterStats);//�۳���Ӧ���������Ѫ��
                    PoisonTime = 1.0f;
                }

            }
        }
        PlayerHealthUI.currenthealth = PlayercharacterStats.CurrentHealth;
        PlayerHealthUI.maxhealth = PlayercharacterStats.MaxHealth;
        FallInHell();
    }

    private void UpdateTime()
    {
        invincibleTime -= Time.deltaTime;
        playEnterWaterTime -= Time.deltaTime;
        playerAttackTime -= Time.deltaTime;
        getHitTime -= Time.deltaTime;
        inPoisonTime-= Time.deltaTime;
        PoisonTime-= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!playerIsDie)
        {
            if(invincibleTime<=0)
            {
                if (other.tag == "EnemyAttack")
                {
                    Debug.Log(other.tag);
                    PlayercharacterStats.GetDamage(PlayercharacterStats);//�۳���Ӧ���������Ѫ��
                }
                else if (other.tag == "BossAttack")
                {
                    Debug.Log(other.tag);
                    PlayercharacterStats.GetDoubleDamage(PlayercharacterStats);//�۳���Ӧ���������Ѫ��
                }
                else if (other.tag == "RedBossAttack")
                {
                    Debug.Log(other.tag);
                    PlayercharacterStats.GetFourDamage(PlayercharacterStats);//�۳���Ӧ���������Ѫ��
                }
                else if (other.tag == "GreenBossAttack")
                {
                    Debug.Log(other.tag);
                    isBePoisoned = true;
                    inPoisonTime = 5.0f;
                    PoisonTime = 1.0f;
                    PlayercharacterStats.GetDoubleDamage(PlayercharacterStats);//�۳���Ӧ���������Ѫ��
                }
                else if (other.tag == "GreenAttack")
                {
                    Debug.Log(other.tag);
                    isBePoisoned = true;
                    inPoisonTime = 5.0f;
                    PoisonTime = 1.0f;
                    PlayercharacterStats.GetDamage(PlayercharacterStats);//�۳���Ӧ���������Ѫ��
                }
                else if (other.tag == "SpearD")
                {
                    Debug.Log(other.tag);
                    PlayercharacterStats.GetDoubleDamage(PlayercharacterStats);//�۳���Ӧ���������Ѫ��
                    invincibleTime = setInvincibleTime;
                }
            }
            if (PlayercharacterStats.CurrentHealth == 0)
            {
                playerIsDie = true;
                animator.SetBool("IsDie", playerIsDie);
            }
            attackPlay.Play();
            getHitTime = 0.5f;
        }
    }
    private void OnTriggerStay(Collider other)//����
    {
        if (!playerIsDie) {
            
            if(playEnterWaterTime <= 0)
            {
                if (other.tag == "Water")
                {
                    PlayercharacterStats.GetDamage(PlayercharacterStats);//�۳���Ӧ���������Ѫ��
                    if (PlayercharacterStats.CurrentHealth == 0)
                    {
                        playerIsDie = true;
                        animator.SetBool("IsDie", playerIsDie);
                    }
                }
                playEnterWaterTime = 1;
            }
        }
    }

    public void FallInHell()
    {
        if (!playerIsDie)
        {
            if (this.transform.position.y <= -15)
            {
                PlayercharacterStats.CurrentHealth = 0;
                if (PlayercharacterStats.CurrentHealth == 0)
                {
                    playerIsDie = true;
                    animator.SetBool("IsDie", playerIsDie);
                }
            }
        }
    }
}
