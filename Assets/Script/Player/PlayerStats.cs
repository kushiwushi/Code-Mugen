using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int playerLevel;

    [Header("Self")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float defense;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float luck;

    [Header("Offensives")]
    [SerializeField] private float damage;
    [SerializeField] private float haste;
    [SerializeField] private float critRate;

    [Header("Miscallenous")]
    [SerializeField] private float pickupRange;

    [Header("Scripts")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PickupRange pickupRangeScript;


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

        //update dash
        playerMovement.currMoveSpeed = moveSpeed;
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
        haste *= 1f - value;
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
        pickupRange += pickupRange * value;
        pickupRangeScript.UpdateRange();
    }
}
