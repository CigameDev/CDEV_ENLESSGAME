using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CDEV.EnlessGame
{
    public enum GameTag
    {
        Player,
        Block,
        DeadZone
    }
    
    public enum GameLayer
    {
        Player,
        Block,
        Dead
    }

    public enum ChacAnim
    {
        Idle,
        Jump,
        Land,
        OnAir,
        Dead
    }
    public enum GamePref
    {
        BestScore,
        LevelUnlocked_,
        CurLevelId,
        IsMusicOn,
        IsSoundOn
    }

    public enum GameScene
    {
        MainMenu,
        GamePlay
    }
    public enum MoveDirection
    {
        Left,
        Right
    }
    public enum GameState
    {
        Starting,
        Playing,
        GameOver
    }
    [System.Serializable]
    public class LevelItem
    {
        public int scoreRequire;//diem so yeu cau de mo khoa man ke tiep
        public Sprite unlockThumb;
        public Sprite lockThumb;
        public Sprite levelBG;
        public Sprite chaPreviewImage;
        public Player playerPrefab;
        public Block blockPrefab;
        public float spawnTime;//thoi gian tao ra block cua moi level
        public float baseSpeed;//toc do di chuyen co ban cua block o moi level
        public float maxSpeed;//toc do di chuyen toi da cua block o moi level

    }
}
