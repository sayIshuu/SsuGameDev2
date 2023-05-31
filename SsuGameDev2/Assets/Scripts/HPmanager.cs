using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPmanager : MonoBehaviour
{
//==================싱글톤패턴으로 전역변수화==================
    private static HPmanager instance = null;
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



    [SerializeField] private Slider player01HpBar;
    [SerializeField] private Slider player02HpBar;
    public float maxHp, player01CurrentHp, player02CurrentHp;

    public void player01HpDown(int damege)
    {
        float downAmount = (float)((damege+1)*10);
        player01CurrentHp -= downAmount;

        if (player01CurrentHp < 0)
            player01CurrentHp = 0;
        //player01HpBar.value = Mathf.Lerp(player01HpBar.value, (float)player01CurrentHp / (float)maxHp, Time.deltaTime * 5f);
        player01HpBar.value = (float)player01CurrentHp / (float)maxHp;
    }
    //선형보간 써서 부드럽게 감소하게 하려고 했는데 실패했습니다..

    public void player02HpDown(int damege)
    {
        float downAmount = (float)((damege +1) * 10);
        player02CurrentHp -= downAmount;

        if (player02CurrentHp < 0)
            player02CurrentHp = 0;
        //player02HpBar.value = Mathf.Lerp(player02HpBar.value, (float)player02CurrentHp / (float)maxHp, Time.deltaTime *5f);
        player02HpBar.value = (float)player02CurrentHp / (float)maxHp;
    }

    void Start()
    {
        player01HpBar.value = ((float)player01CurrentHp) / (float)maxHp;
        player02HpBar.value = ((float)player02CurrentHp) / (float)maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
