using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovController : NetworkBehaviour
{
   public CharacterController characterController;
   public float speed = 5f;
    public Animator animator;

    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    public override  void FixedUpdateNetwork()
    {
        if (HasStateAuthority)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direcao = new Vector3(horizontal, 0, vertical);
            if(direcao.magnitude > 0.1f)
            {
                //movimento personagem
                characterController.Move(direcao * speed * Runner.DeltaTime);
                //rotacao do personagem
                transform.rotation = Quaternion.LookRotation(direcao);
                //animacao do personagem
                animator.SetBool("canWalk", true);
            }
            else
            {
                animator.SetBool("canWalk", false);
            }

        }
    }
}

