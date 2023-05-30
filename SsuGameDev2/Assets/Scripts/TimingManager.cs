using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    enum State{Wait,Select,Result,End}

    State state;

    float timer =0;//초세는 시계

    float waitTime= 3f;//게임진입시 대기시간
    float selectTime= 1f;//행동 선택시간
    float ResultTime= 1f;//결과 보여주는 시간


    void BeSelectTime()
    {
         state=State.Select;
        //inputManger에서 bool값 하나 받아서 true로 바꿔서 값넣도록 허용하게 하기
    }
    void BeResultTime()
    {
        state=State.Result;
        //inputManger에서 bool값 하나 받아서 true로 바꿔서 값못넣도록 비허용하게 하기
    }
    void BeEndTime()
    {
        state=State.End;
        //결과보여주기
    }


    // Start is called before the first frame update
    void Start()
    {
        state=State.Wait;
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(state==State.Wait)
        {           
            if(timer>waitTime)
            {   timer=0f;
               
                BeSelectTime();
            }
        }
        else if(state==State.Select)
        {          
            if(timer>selectTime)
            {
                timer=0;
                BeResultTime();
            }
        }
        else if(state==State.Result)
        {
            //var int Result1= GetPlayer1Result() player1의 결과값 가져오기
            //var int Result2= GetPlayer2Result() player2의 결과값 가져오기
            //int Result = Compare(Result1,Result2 ) 결과값 비교 로직
            // if(timer>ResultTime)
            //  {
            //     if(result==1)
            //     {
            //     //player1 체력깎기
            //     }
            //     else if(result == 2)
            //     {
            //     //player2 체력깎기
            //     }
            //     else if(result==3)
            //     {
            //     //체력 변화없음 및 특정행동
            //     }

            //     if() 만약 둘중한명의 플레이어의 목숨이 0일경우
            //     {
                 // BeEndTime();
            //     }
                timer=0;
                BeResultTime();
            //} 
        }
    }
}
