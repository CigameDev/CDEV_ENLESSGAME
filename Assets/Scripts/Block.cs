using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CDEV.EnlessGame
{
    

    public class Block : MonoBehaviour, ICompChk
    {
        public float moveSpeed;
        public MoveDirection moveDirection;
        public Sprite[] sprites;
        public bool canMove;
        public float blockGrap;//khoang cach giua hai block 
        public int minScore;
        public int maxScore;

        private Rigidbody2D m_rb;
        private SpriteRenderer m_sp;

        private int m_id;
        private int m_curScore;

        public SpriteRenderer Sp { get => m_sp; }
        public int Id { get => m_id;  }
        public int CurScore { get => m_curScore;  }

        

        private void Awake()
        {
            m_rb = GetComponent<Rigidbody2D>();
            m_sp = GetComponent<SpriteRenderer>();
        }
        void Start()
        {
            m_id =GetInstanceID();
            m_curScore = Random.Range(minScore, maxScore);
        }

        
        void Update()
        {
            BlockMoving();
        }
        public void ChangeSprite(ref int idx)
        {
            //thay doi hinh anh hien thi
            if (sprites == null || sprites.Length <= 0 || IsComponentsNull()) return;
            m_sp.sprite = sprites[idx];
        }    
        private void BlockMoving()
        {
            if (IsComponentsNull() || !canMove) return;
            if(moveDirection ==MoveDirection.Left)
            {
                m_rb.velocity = Vector2.left * moveSpeed;
            }  
            else if(moveDirection == MoveDirection.Right)
            {
                m_rb.velocity = Vector2.right * moveSpeed;
            }
            //cho di chuyen den giua man hinh roi dung lai
            Vector3 centerPos = new Vector3(0, transform.position.y, transform.position.z);
            float distanceToCenterPos = Vector2.Distance(transform.position, centerPos);
            if(distanceToCenterPos <=0.1f)
            {
                m_rb.velocity = Vector2.zero;
                transform.position = centerPos;
            }    
        }    

        public void PlayerLand()
        {
            //khi player dap xuong block thi dung di chuyen block lai
            //ham nay se duoc goi trong kiem tra va cham o script player
            if(IsComponentsNull()||!canMove) return;

            canMove = false;
            m_rb.velocity = Vector2.zero;

        }    
        public void SpriteOrderUp(SpriteRenderer preBlockSp)
        {
            //tang order in layer cua cai block len

            if (IsComponentsNull()) return;
            m_sp.sortingOrder =preBlockSp.sortingOrder +1;
            
        }    
        public bool IsComponentsNull()
        {
            bool checking = m_rb == null || m_sp == null;
            if (checking)
            {
                Debug.LogError("Some component  is null .Please check!!!.");
            }
            return checking;
        }
    }
}
