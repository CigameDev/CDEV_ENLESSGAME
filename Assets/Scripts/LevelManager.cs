using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CDEV.EnlessGame
{
    public class LevelManager : MonoBehaviour,ISingleton
    {
        public static LevelManager Ins;
        public LevelItem[] levelItems;
        private void Awake()
        {
            MakeSingleton();
        }
        void Start()
        {

        }

        private void Init()
        {
            //khoi tao xem level nao dc mo khoa ,level nao chua duoc mo khoa
            if (levelItems == null || levelItems.Length <= 0) return;
            for(int i=0;i<levelItems.Length;i++)
            {
                var levelItem = levelItems[i];
                if(levelItem ==null) continue;
                string levelDataKey = GamePref.LevelUnlocked_.ToString() + i;
                if(i==0)
                {
                    //mo khoa level dau tien
                    Pref.SetlevelUnlocked(i, true);
                }    
                else
                {
                    //neu du lieu chua duoc luu xuong may nguoi choi thi se luu du lieu
                    //tuc la se khoa cac level khac lai
                    if(!PlayerPrefs.HasKey(levelDataKey))
                    {
                        Pref.SetlevelUnlocked(i, false);

                    }    
                }    
            }    
        }

        public LevelItem Getlevel()
            //lay ra level hien tai
        {
            if(levelItems!=null   || levelItems.Length > 0)
            {
                return levelItems[Pref.CurLevelId];
            }
            return null;
        }    
        public void MakeSingleton()
        {
            if (Ins == null)
            {
                Ins = this;
                DontDestroyOnLoad(this);
            }
            else Destroy(gameObject);
        }
    }
}
