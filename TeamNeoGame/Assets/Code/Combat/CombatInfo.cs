using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CombatInfo
{
    public static class CurrentCombatInfo
    {
        public static CombatInfo CombatInfo;
    }

    public class CombatInfo
    {
        public string EnemyName { get; set; }
        public Sprite EnemySprite { get; set; }
        public int PlayerDamage { get; set; }
        //The damage an enemy does per missed arrow
        public int EnemyDamage { get; set; }
        //The stamina gained per hit arrow
        public int StaminaGain { get; set; }
        public int MaxStamina { get; set; }
        public int MaxHealth { get; set; }
        public int EnemyHealth { get; set; }
        public float TimePerBar { get; set; }
        public int ArrowCount { get; set; }
        public float BufferTime { get; set; }
    }
}