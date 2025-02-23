using System.Collections;
using UnityEngine;

public class LaunchAttack : MonoBehaviour
{
    private Animator attackAnimator;
    private Attack attackScript;
    AudioManager audioManager;

    private PlayerStats playerStats;

    private void Awake() {
        //instantiate components
        playerStats = GetComponent<PlayerStats>();
        attackAnimator = GetComponent<Animator>();
        attackScript = GetComponentInChildren<Attack>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {
        StartCoroutine(Attack()); //start auto attack
    }

    void Update(){

    }

    IEnumerator Attack() {
        while(true) {
            yield return new WaitForSeconds(playerStats.AttackSpeed);
            audioManager.PlaySFX(audioManager.attack);
            attackScript.AimMousePoint();
            attackAnimator.SetTrigger("Attack");
        }
    }
}
