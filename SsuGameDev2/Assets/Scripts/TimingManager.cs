using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    enum State { Wait, Select, Result, End }



    State state;

    float timer = 0f;//초세는 시계

    [SerializeField] float waitTime = 3f;//게임진입시 대기시간
    [SerializeField] float selectTime = 1f;//행동 선택시간
    [SerializeField] float ResultTime = 1f;//결과 보여주는 시간

    [SerializeField] float minimumSelectTime= 0.5f;
     [SerializeField]float decreaseTime= 0.1f;

    [SerializeField] InputManager inputManager;


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
        state = State.Select;
        CanInputChange = true;//입력값 바꿀수 있음

    }
    void BeResultTime()// 입력값 결과보여주기
    {
        state = State.Result;
        CanInputChange = false;//입력값 바꿀수없음

    }
    void BeEndTime()//둘중한명 hp가 0이되어 끝날때
    {
        state = State.End;
        CanInputChange = false;
        //결과보여주기
    }


    // Start is called before the first frame update
    void Start()
    {
        state = State.Wait;
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
            if(selectTime>=minimumSelectTime)
            {
                selectTime-=decreaseTime;
            }


            if (timer > selectTime)
            {
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
                if(HPmanager.Instance.player01CurrentHp == 0) //만약 둘중한명의 플레이어의 목숨이 0일경우  
                {
                    Debug.Log("종료");
                    inputManager.ResetAnimation();
                    AnimatorLeft.Instance.GameOver();
                    BeEndTime();
                }
                else if(HPmanager.Instance.player02CurrentHp == 0)
                {
                    Debug.Log("종료");
                    inputManager.ResetAnimation();
                    AnimatorRight.Instance.GameOver();
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
