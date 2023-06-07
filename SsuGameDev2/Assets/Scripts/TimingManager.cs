using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimingManager : MonoBehaviour
{
    enum State { Wait, Select, Result, End }

    public AudioSource bgm;
    public AudioClip bgmclip;

    public AudioSource kosound;
    public AudioClip kosoundclip;

    public AudioSource winsound;
    public AudioClip winsoundclip;

    public SpriteRenderer korenderer;
    public Sprite player1winImg;
    public Sprite player2winImg;

    State state;

    float timer = 0f;//초세는 시계

    [SerializeField] float waitTime = 3f;//게임진입시 대기시간
    [SerializeField] float selectTime = 1f;//행동 선택시간
    [SerializeField] float ResultTime = 1f;//결과 보여주는 시간

    [SerializeField] float minimumSelectTime = 0.5f;
    [SerializeField] float decreaseTime = 0.1f;

    [SerializeField] InputManager inputManager;

    [SerializeField] float minimumResultTime = 0.5f;

   public GameObject selectTimeLine;
    public Slider timingUI;

   
    bool canInputChange = true;
    public bool CanInputChange
    {
        get
        {
            return canInputChange;
        }
        set
        {
            canInputChange = value;
        }
    }
    void BeSelectTime()//입력값 넣기
    {
        if (selectTime >= minimumSelectTime)
        {
            selectTime -= decreaseTime;
        }
        selectTimeLine.SetActive(true);
        
        state = State.Select;
        CanInputChange = true;//입력값 바꿀수 있음

    }
    void BeResultTime()// 입력값 결과보여주기
    {
        if(ResultTime>=minimumResultTime)
        {
            ResultTime -= decreaseTime * 0.5f;
        }
        state = State.Result;
        CanInputChange = false;//입력값 바꿀수없음

    }
    void BeEndTime()//둘중한명 hp가 0이되어 끝날때
    {
        state = State.End;
        CanInputChange = false;
        //결과보여주기
    }

    void playerwin()
    {
        if (HPmanager.Instance.player01CurrentHp == 0)
        {
            GetComponent<SpriteRenderer>().sprite = player2winImg;
            winsound.Play();
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = player1winImg;
            winsound.Play();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        state = State.Wait;

        korenderer = GetComponent<SpriteRenderer>();
        //winrenderer = GetComponent<SpriteRenderer>();

        korenderer.enabled = false;
        //winrenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (state == State.Wait)//게임 시작전 대기시간
        {

            if (timer > waitTime)
            {
                Debug.Log("대기시간");
                timer = 0f;

                BeSelectTime();
            }
        }
        else if (state == State.Select)//행동어떤걸 할지 선택
        {


            timingUI.value= timer /selectTime;
            //Debug.Log(selectTime);
            if (timer > selectTime)
            {
                selectTimeLine.SetActive(false);

                Debug.Log("선택시간");
                timer = 0f;
                BeResultTime();
            }
        }
        else if (state == State.Result)//행동보여주기
        {
            //여기에 둘의 값비교 및 결과 로직작성해주셔서 비교해주면 됩니다.
            inputManager.DetermineWinner();
            
            if (timer >= ResultTime)
            {
                timer = 0f;
                if (HPmanager.Instance.player01CurrentHp == 0) //만약 둘중한명의 플레이어의 목숨이 0일경우  
                {
                    Debug.Log("종료");
                    inputManager.ResetAnimation();
                    AnimatorLeft.Instance.GameOver();
                    bgm.volume = 0f;
                    korenderer.enabled = true;
                    kosound.Play();
                    Invoke("playerwin", 3);
                    BeEndTime();
                }
                else if (HPmanager.Instance.player02CurrentHp == 0)
                {
                    Debug.Log("종료");
                    inputManager.ResetAnimation();
                    AnimatorRight.Instance.GameOver();
                    bgm.volume = 0f;
                    korenderer.enabled = true;
                    kosound.Play();
                    Invoke("playerwin", 3);
                    BeEndTime();
                }
                else //그게아니라면
                {
                    inputManager.ResetAnimation();
                    BeSelectTime();
                }
            }
        }
    }
}
