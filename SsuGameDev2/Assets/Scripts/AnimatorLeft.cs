using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorLeft : MonoBehaviour
{
    private static AnimatorLeft instance = null;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    public static AnimatorLeft Instance
    {
        get
        {
            if (null == instance)
                return null;
            return instance;
        }
    }
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Pa()
    {
        animator.SetBool("pa", true);
    }

    public void Stand()
    {
        animator.SetBool("pa", false);
        animator.SetBool("block", false);
        animator.SetBool("charge", false);
        animator.SetBool("energypa", false);
        animator.SetBool("damaged", false);
    }

    public void Block()
    {
        animator.SetBool("block", true);
    }

    public void Charge()
    {
        animator.SetBool("charge", true);
    }

    public void EnergyPa()
    {
        animator.SetBool("energypa", true);
    }

    public void Damaged()
    {
        animator.SetBool("damaged", true);
    }

    public void GameOver()
    {
        animator.SetBool("gameover", true);
    }
}
