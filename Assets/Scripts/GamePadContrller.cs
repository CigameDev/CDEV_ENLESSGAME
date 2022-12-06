using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CDEV.EnlessGame
{
    public class GamePadContrller : MonoBehaviour
    {
        //dau vao ban phim chuot cac kieu
        public static GamePadContrller Ins;
        public bool isMobile;
        
        private bool m_canJump;

        public bool CanJump { get => m_canJump; set => m_canJump = value; }

        private void Awake()
        {
            Ins = this;
        }
        private void Update()
        {
            if(!isMobile)
            {
                m_canJump = Input.GetKeyDown(KeyCode.Space);//neu nhan space thi canJump khong thi thoi
            }    

        }
    }
}

