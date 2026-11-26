using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class HeroPlayer : MonoBehaviour
{
    public Animator HeroAnimator;
    public Animator EnemyAnimator;
    public int heroHealth = 100;
    public TextMeshProUGUI Health;
    public int enemyHealth = 100;
    public TextMeshProUGUI eHealth;
    public GameObject YouWin;
    public GameObject YouLose;
    public ParticleSystem hitEffect;
    public ParticleSystem hitEffect1;
 

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            GetAttack();
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            GetAttack2();
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            GetHurt();
        }
    }

    IEnumerator GameOver()
    {
        HeroAnimator.SetBool("death", true);
        yield return new WaitForSeconds(3f);
        YouLose.SetActive(true);
    }
    IEnumerator GameOverW()
    {
        EnemyAnimator.SetBool("death", true);
        yield return new WaitForSeconds(3f);
        YouWin.SetActive(true);
    }

    public void GetHurt()
    {
        if (heroHealth >= 0) { 
            HeroAnimator.SetTrigger("hurt");
        EnemyAnimator.SetTrigger("attack1");
        heroHealth = heroHealth - 20;
            hitEffect.Play();
            Health.text = "Health: " + heroHealth.ToString();
    }
        if (heroHealth <= 0)
        {
            StartCoroutine(GameOver());
        }
    }
    public void GetAttack()
    {
        if (enemyHealth >= 0)
        {
            HeroAnimator.SetTrigger("attack1");
        EnemyAnimator.SetTrigger("hurt");
        enemyHealth = enemyHealth - 10;
            hitEffect.Play();
            eHealth.text = "Evil Knight Health: " + enemyHealth.ToString();
    }
        if (enemyHealth <= 0)
        {
            StartCoroutine(GameOverW());

        }

    }

    public void GetAttack2()
    {
        if (enemyHealth >= 0)
        {
            HeroAnimator.SetTrigger("attack2");
            EnemyAnimator.SetTrigger("hurt");
            enemyHealth = enemyHealth - 20;
            hitEffect1.Play();
            eHealth.text = "Evil Knight Health: " + enemyHealth.ToString();
        }
            if (enemyHealth <= 0)
        {
            StartCoroutine(GameOverW());
        }
    }
}

