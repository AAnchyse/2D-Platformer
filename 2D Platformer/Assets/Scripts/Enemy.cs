using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [System.Serializable] //permet de voir la classe
    public class EnemyStats
    {
        public int MaxHealth = 100;

        private int _currentHealth;
        public int currentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = Mathf.Clamp(value, 0, MaxHealth); }
        }

        public void Init()
        {
            currentHealth = MaxHealth;
        }
    }
    public EnemyStats enemyStats = new EnemyStats();

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    private void Start()
    {
        enemyStats.Init();

        if(statusIndicator!=null)
        {
            statusIndicator.SetHealth(enemyStats.currentHealth, enemyStats.MaxHealth);
        }
        
    }

    public void DamageEnemy(int damage)
    {
        enemyStats.currentHealth -= damage;
        if (enemyStats.currentHealth <= 0)
        {
            GameMaster.KillEnemy(this);
        }

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(enemyStats.currentHealth, enemyStats.MaxHealth);
        }
    }  
}
