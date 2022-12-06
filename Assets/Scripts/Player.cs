using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CDEV.EnlessGame
{
    public class Player : MonoBehaviour,ICompChk
    {
        public float jumpForce;
        public LayerMask blockLayer;
        public float blockCheckingRadius;
        public float blockCheckingOffset;
        public GameObject landVfx;

        private Rigidbody2D m_rb;
        private Animator m_animator;
        private bool m_isOnBlock;
        private Vector3 m_centerPos;
        private int m_blockId;
        private bool m_isDead;



        private void Awake()
        {
            m_rb = GetComponent<Rigidbody2D>();
            m_animator = GetComponent<Animator>();
        }
        void Start()
        {

        }

        void Update()
        {
            if (m_isDead) return;
            Jump();
            if(m_rb.velocity.y < 0)
            {
                if(m_isOnBlock)
                {
                    m_animator.SetBool(ChacAnim.Jump.ToString(), false);
                    m_animator.SetBool(ChacAnim.Land.ToString(), true);
                }
                else
                {
                    m_animator.SetBool(ChacAnim.Jump.ToString(), false);
                }
            }    
        }    
      void FixedUpdate()
        {
            IsOnBlock();
        }    
       

        private void IsOnBlock()//kt player co dung tren block khong
        {
            m_centerPos = new Vector3(transform.position.x
                , transform.position.y - blockCheckingOffset, transform.position.z
                );
            Collider2D col = Physics2D.OverlapCircle(m_centerPos, blockCheckingRadius,blockLayer);

            //return col != null;
            m_isOnBlock = col != null ? true : false;
        }

        private void OnDrawGizmos()
        {
            m_centerPos = new Vector3(transform.position.x
               , transform.position.y - blockCheckingOffset, transform.position.z
               );
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(m_centerPos, blockCheckingRadius);
        }
        public void Jump()
        {
            if (!GamePadContrller.Ins.CanJump || !m_isOnBlock || IsComponentsNull()) return;
            GamePadContrller.Ins.CanJump = false;
            m_rb.velocity = Vector2.up * jumpForce;
            m_animator.SetBool(ChacAnim.Jump.ToString(), true);
            m_animator.SetBool(ChacAnim.Land.ToString(), false);
        }
        private void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.CompareTag(GameTag.Block.ToString()))
            {
                Debug.Log(" va phai block");
                Block block = col.gameObject.GetComponent<Block>();
                if(block)
                {
                    block.PlayerLand();
                }    
            }    
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(GameTag.DeadZone.ToString()))
            {
                Debug.Log(" va phai Deadzone");
            }
        }
        public void BackToIdle()
        {
            m_animator.SetBool(ChacAnim.Land.ToString(), false);
            m_animator.SetTrigger(ChacAnim.Idle.ToString());
            //attach this event  to the last  frame of Animation State "Land"
        }
        public bool IsComponentsNull()
        {
            bool checking = m_animator == null || m_rb == null;
            if(checking)
            {
                Debug.LogError("Some component  is null .Please check!!!.");
            }
            return checking;
        }
    }
}
