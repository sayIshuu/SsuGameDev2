using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPUI : MonoBehaviour
{


    [SerializeField] private float lerpTimer = 0f;
    public float maxHealth = 1000;
    public float chipSpeed = 2f;
    public Image frontHealthBar1;
    public Image BackHealthBar1;
    public Image frontHealthBar2;
    public Image BackHealthBar2;

    bool updateUI = false;

    public float fillSpeed = 3f;
    


    HPmanager hpManager;
  


/*
    
    void Start()
    {
        hpManager =hpManager.GetComponent<HPmanager>();
        maxHealth = hpManager.maxHp;// boss대신 가져온 스크립트 내부 변수명에 health가 있어야합니다.
    frontHealthBar1=hpManager.player01CurrentHp;
      
    }

 
    void Update()
    {
        boss.health = Mathf.Clamp(boss.health, 0, maxHealth);
        UpdateHealthUI();

        
    }

    public void UpdateHealthUI()//체력 증가 및 감소 로직
    {

        float fillF = frontHealthBar.fillAmount;
        float fillB = BackHealthBar.fillAmount;
        float hFraction = boss.health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            BackHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;

            BackHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            BackHealthBar.color = Color.green;
            BackHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;

            frontHealthBar.fillAmount = Mathf.Lerp(fillF, BackHealthBar.fillAmount, percentComplete);
        }
    }

*/
    
}
