using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(CharacterController))]

public class Movement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 0.15f;
    [SerializeField] private float speedOffset = 0.1f;
    [SerializeField] private float speedChangeRate = 10f;

    private float Gravity = -10f;
    
    [SerializeField] private float GroundedOffset = 0.1f;
    [SerializeField] private float GroundedRadius = 0.2f;
    [SerializeField] private LayerMask GroundLayers;

    public bool IsGrounded { get; private set; }//判断是否在地面

    private float ForwardSpeed;
    private float JumpSpeed;

    private float RightSpeed;

    private float ForwardValue = 0f;
    private float RightValue = 0f;

    private Animator animator;
    
    private int forwardMoveAniID;
    private int rightMoveAniID;//横向移动

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        SetupAnimationIDs();
    }

    
    // Update is called once per frame
    void Update()
    {

        GroundedCheck();
        MoveForward();
        MoveRight();
        ToJump();
    }
  

    void SetupAnimationIDs()
    {
        forwardMoveAniID = Animator.StringToHash("forwardSpeed");
        rightMoveAniID = Animator.StringToHash("rightSpeed");
    }


    void MoveForward()
    {
        if (IsGrounded)
        {
            ForwardSpeed = ForwardValue * moveSpeed;
            controller.Move(ForwardSpeed * Vector3.forward * Time.deltaTime);
            animator.SetFloat(forwardMoveAniID, ForwardSpeed);
        }
    }
    void MoveRight()
    {
        if (IsGrounded)
        {
            RightSpeed = RightValue * moveSpeed;
            controller.Move(RightSpeed * Vector3.right * Time.deltaTime);
            animator.SetFloat(rightMoveAniID, RightSpeed);
        }
    }

    public void Move2(Vector2 moveInput)
    {
        RightValue = moveInput.x;
        ForwardValue = moveInput.y;
    }
    public void OnJump(bool IsPressSpace)
    {
        if (IsPressSpace)
        {
            JumpSpeed = 6f;
            ToJump();
        }
    }

    void ToJump()
    {
        if (IsGrounded)
        {
            controller.Move(JumpSpeed * Vector3.up * Time.deltaTime);
            JumpSpeed += Gravity * Time.deltaTime;
        }
    }

    /// <summary>
    /// GroundedCheck 通过脚底下的球形碰撞是否与地面发生碰撞，返回值表示是否站在地面上
    /// </summary>
    void GroundedCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
        
        if(Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore))
        {
            IsGrounded = true;
        }
    }
}
