using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public GameObject Panel;

    [Header("Health")]
    [SerializeField] public float initialHealth = 10f;
    [SerializeField] public float maxHealth = 10f;

    [Header("Shield")]
    [SerializeField] public float initialShield = 5f;
    [SerializeField] public float maxShield = 5f;

    [Header("Settings")]
    [SerializeField] private bool destroyObject;

    public Character character;
    private CharacterController controller;
    private Collider2D collider2D;
    private SpriteRenderer spriteRenderer;
    private GameObject RestartPanel;

    private bool isPlayer;
    public bool shieldBroken;

    // Controls the current health of the object    
    public float CurrentHealth { get; set; }

    // Returns the current health of this character
    public float CurrentShield { get; set; }

    private void Awake()
    {
        character = GetComponent<Character>();
        controller = GetComponent<CharacterController>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        CurrentHealth = initialHealth;
        CurrentShield = initialShield;

        if (character != null)
        {
            isPlayer = character.CharacterType == Character.CharacterTypes.Player;
        }

         //UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentShield, maxShield, isPlayer);
        UpdateCharacterHealth();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }
    }

    // Take the amount of damage we pass in parameters
    public virtual void TakeDamage(int damage)
    {
        if (CurrentHealth <= 0)
        {
            return;
        }

        if (!shieldBroken && character != null)
        {
            CurrentShield -= damage;
            //UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentShield, maxShield, isPlayer);
            UpdateCharacterHealth();


            if (CurrentShield <= 0||CurrentShield-damage<0)
            {
                CurrentShield = 0;
                shieldBroken = true;
            }
            return;
        }
        
        CurrentHealth -= damage;
         //UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentShield, maxShield, isPlayer);
        UpdateCharacterHealth();


        if (CurrentHealth <= 0)
        {
            
            Die();
        }
    }

    // Kills the game object
    public void Die()
    {
        if (character != null)
        {
            collider2D.enabled = false;
            spriteRenderer.enabled = false;

            character.enabled = false;
            controller.enabled = false;
        }

        if (destroyObject)
        {
            DestroyObject();
        }
        if(isPlayer)
        {
            Panel.SetActive(true);
        }
    }

    // Revive this game object    
    public void Revive()
    {
        if (character != null)
        {
            collider2D.enabled = true;
            spriteRenderer.enabled = true;

            character.enabled = true;
            controller.enabled = true;
        }

        gameObject.SetActive(true);

        CurrentHealth = initialHealth;
        CurrentShield = initialShield;

        shieldBroken = false;

        //UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentShield, maxShield, isPlayer);
        UpdateCharacterHealth();
    }
   public void GainHealth(int amount)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + amount, maxHealth); //Logic if full HP, cannot add anymore

        UpdateCharacterHealth();
    }
     public void GainShield(int amount)
    {
        CurrentShield = Mathf.Min(CurrentShield + amount, maxShield);
        UpdateCharacterHealth();
        shieldBroken=false;
    }

    // If destroyObject is selected, we destroy this game object
    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }
    public void UpdateCharacterHealth()
    {        
        // Update Player health
        if (character != null)
        {
            UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentShield, maxShield, isPlayer);
        }
    }
}
