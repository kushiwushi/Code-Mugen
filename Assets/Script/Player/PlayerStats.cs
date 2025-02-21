using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int playerLevel = 1;

    [Header("Self")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float defense = 5f;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float luck = 0f;

    [Header("Offensives")]
    [SerializeField] private float damage = 20f;
    [SerializeField] private float haste = 2f;
    [SerializeField] private float critRate = 10f;

    [Header("Miscallenous")]
    [SerializeField] private float pickupRange = 20f;


    //I did this so you can modify the values through the inspector whilst keeping the variables private

    //self
    public int Level => playerLevel;
    public float MaxHealth => maxHealth;
    public float Defense => defense;
    public float MoveSpeed => moveSpeed;
    public float Luck => luck;

    //offensives
    public float Damage => damage;
    public float AttackSpeed => haste;
    public float CritRate => critRate;

    //misc
    public float PickupRange => pickupRange;


    //setters - will add later..
    public void SetLevel()
    {
        playerLevel++;
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed *= value;
    }

    public void SetDamge(float value)
    {
        damage *= value;
    }

    public void SetDefense(float value)
    {
        defense += value;
    }

    public void SetHaste(float value)
    {
        haste *= value;
    }

    public void SetLuck(float value)
    {
        luck += value;
    }

    public void SetCritRate(float value)
    {
        critRate += value;
    }

    public void SetPickupRange(float value)
    {
        pickupRange *= value;
    }
}
