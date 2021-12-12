using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MonsterHealth : Health
{
    [Header("BarSettings")]
    [SerializeField] public Image healthBar;
    [SerializeField] public Image shieldBar;
    private MonsterBase monster;
    private void Start()
    {
        monster = GetComponent<MonsterBase>();
    }

    public override void TakeDamage(int damage)
    {

        if (CurrentHealth <= 0)
        {
            return;
        }

        if (!shieldBroken && character != null)
        {
            CurrentShield -= damage;
            //UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentShield, maxShield, isPlayer);
            MonsterUpdateCharacterHealth();
            if (CurrentShield <= 0 || CurrentShield - damage < 0)
            {
                CurrentShield = 0;
                shieldBroken = true;
            }
            return;
        }

        CurrentHealth -= damage;
        //UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentShield, maxShield, isPlayer);
        MonsterUpdateCharacterHealth();


        if (CurrentHealth <= 0)
        {
            monster.DieAni();
            Die();
        }
    }
    public void MonsterUpdateCharacterHealth()
    {

        // Update Player health
        if (character != null)
        {
            healthBar.fillAmount = CurrentHealth / maxHealth;
            shieldBar.fillAmount = CurrentShield / maxShield;
        }
    }
}
