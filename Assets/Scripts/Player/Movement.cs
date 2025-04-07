using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(CharacterController))]

public class Movement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float speedChangeRate = 7f;

    private float Gravity = -10f;
    
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
        float targetSpeed = ForwardValue * moveSpeed;
        // 指定速率改变速度
        ForwardSpeed = Mathf.MoveTowards(ForwardSpeed, targetSpeed, speedChangeRate * Time.deltaTime);
        controller.Move(ForwardSpeed * Vector3.forward * Time.deltaTime);
        animator.SetFloat(forwardMoveAniID, ForwardSpeed);
    }
    void MoveRight()
    {
        float targetSpeed = RightValue * moveSpeed;
        // 指定速率改变速度
        RightSpeed = Mathf.MoveTowards(RightSpeed, targetSpeed, speedChangeRate * Time.deltaTime);
        controller.Move(RightSpeed * Vector3.right * Time.deltaTime);
        animator.SetFloat(rightMoveAniID, RightSpeed);
    }

    public void Move2(Vector2 moveInput)
    {
        RightValue = moveInput.x;
        ForwardValue = moveInput.y;
    }
    public void OnJump(bool IsPressSpace)
    {

        JumpSpeed = 6f;
        ToJump();
    }

    void ToJump()
    {
        controller.Move(JumpSpeed * Vector3.up * Time.deltaTime);
        JumpSpeed += Gravity * Time.deltaTime;
    }

}
