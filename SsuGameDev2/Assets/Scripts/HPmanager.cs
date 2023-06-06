using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPmanager : MonoBehaviour
{
    //==================�̱����������� ��������ȭ==================
    private static HPmanager instance = null;
    float fillB;
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
    public static HPmanager Instance
    {
        get
        {
            if (null == instance)
                return null;
            return instance;
        }
    }
    //=============================================================

    public float chipSpeed = 2f;
    [SerializeField] private float lerpTimer1 = 0f;
    [SerializeField] private float lerpTimer2 = 0f;
    [SerializeField] private Image player01HpBar;

    public Image player01BackHPBar;
    public Image player02BackHPBar;
    [SerializeField] private Image player02HpBar;
    public float maxHp, player01CurrentHp, player02CurrentHp;

    public void player01HpDown(int damege)
    {
        float downAmount = (float)((damege + 1) * 10);
        player01CurrentHp -= downAmount;

        if (player01CurrentHp < 0)
            player01CurrentHp = 0;
        //player01HpBar.value = Mathf.Lerp(player01HpBar.value, (float)player01CurrentHp / (float)maxHp, Time.deltaTime * 5f);
        player01HpBar.fillAmount = (float)player01CurrentHp / (float)maxHp;
    }
    //�������� �Ἥ �ε巴�� �����ϰ� �Ϸ��� �ߴµ� �����߽��ϴ�..

    public void player02HpDown(int damege)
    {
        float downAmount = (float)((damege + 1) * 10);
        player02CurrentHp -= downAmount;
        fillB = player02BackHPBar.fillAmount;

        if (player02CurrentHp < 0)
            player02CurrentHp = 0;
        //player02HpBar.value = Mathf.Lerp(player02HpBar.value, (float)player02CurrentHp / (float)maxHp, Time.deltaTime *5f);
        player02HpBar.fillAmount = (float)player02CurrentHp / (float)maxHp;
    }

    void Start()
    {
        player01HpBar.fillAmount = ((float)player01CurrentHp) / (float)maxHp;
        player02HpBar.fillAmount = ((float)player02CurrentHp) / (float)maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        UPdateUI1();
        UPdateUI2();
        if (lerpTimer1 >= 1)
            lerpTimer1 = 0;
        if (lerpTimer2 >= 1)
            lerpTimer2 = 0;
    }


    void UPdateUI1()
    {
        float fillF = player01HpBar.fillAmount;
        float fillB = player01BackHPBar.fillAmount;
        float hFraction = player01CurrentHp / maxHp;
        if (player01HpBar.fillAmount < fillB)
        {
            player01HpBar.fillAmount = hFraction;
            player01BackHPBar.color = Color.red;
            lerpTimer1 += Time.deltaTime;
            float percentComplete = lerpTimer1 / chipSpeed;

            player01BackHPBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
    }

    void UPdateUI2()
    {
        float fillF = player02HpBar.fillAmount;
        float fillB = player02BackHPBar.fillAmount;
        float hFraction = player02CurrentHp / maxHp;
        if (player02HpBar.fillAmount < fillB)
        {
            player02HpBar.fillAmount = hFraction;
            player02BackHPBar.color = Color.red;
            lerpTimer2 += Time.deltaTime;
            float percentComplete = lerpTimer2 / chipSpeed;

            player02BackHPBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
    }




}
