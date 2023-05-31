using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sign
{
    None,       //초기상태, 미입력
    Pa,         //공격
    Block,      //막기
    Charge,     //기모으기
    EnergyPa    //풀차지에너지파
}

public class InputManager : MonoBehaviour
{
    [SerializeField] TimingManager timingManager;

    private Sign player1Choice = Sign.None;
    private Sign player2Choice = Sign.None;

    public int player1Energy = 0;
    public int player2Energy = 0;

    public int a = 0;

    void Start()
    {

    }


//======================수정예정========================
//: 추후에 리턴값이 있는 함수로 변경하여 아래 Debug.Log -> return 으로 수정할예정입니다.
//  그 리턴값을 TimingManager의 결과확인함수에서 받아오면 됩니다.
//  추가로 반복되는 코드가 많아서 더러운데 일단 기능구현부터 하고 추후에 수정할 수 있으면 하겠습니다.
    public void DetermineWinner()
    {
        //플레이어1의 공격
        if (player1Choice == Sign.Pa)
        {
            if (player2Choice == Sign.Charge)
            {
                player2Energy = 0;
                Debug.Log("Player 1의 공격 성공!");
                HPmanager.Instance.player02HpDown(player1Energy);
            }
            else if(player2Choice == Sign.Block)
            {
                Debug.Log("Blocking");
            }
            else if(player2Choice == Sign.Pa)
            {
                if (player1Energy > player2Energy)
                {
                    Debug.Log("Player 1의 공격 성공!");
                    HPmanager.Instance.player02HpDown(player1Energy - player2Energy);
                }
                else if (player2Energy > player1Energy)
                {
                    Debug.Log("Player 2의 공격 성공!");
                    HPmanager.Instance.player01HpDown(player2Energy - player1Energy);
                }
                else
                    Debug.Log("힘의 균형");
                player2Energy = 0;
            }
            else if(player2Choice == Sign.EnergyPa)
            {
                Debug.Log("Player 2의 공격 성공!");
                HPmanager.Instance.player01HpDown(player2Energy - player1Energy);
                player2Energy = 0;
            }
            player1Energy = 0;
        }

        //플레이어1의 막기
        if (player1Choice == Sign.Block)
        {
            if (player2Choice == Sign.Charge)
            {
                player2Energy++;
                Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Block)
            {
                Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Pa)
            {
                player2Energy = 0;
                Debug.Log("Blocking");
            }
            else if (player2Choice == Sign.EnergyPa)
            {
                Debug.Log("Player 2의 공격 성공!");
                HPmanager.Instance.player01HpDown(player2Energy - 1);
                player2Energy = 0;
            }
        }

        //플레이어1의 기모으기
        if (player1Choice == Sign.Charge)
        {
            player1Energy++;
            if (player2Choice == Sign.Charge)
            {
                player2Energy++;
                Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Block)
            {
                Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Pa)
            {
                player2Energy = 0; player1Energy = 0;
                Debug.Log("Player 2의 공격 성공!");
                HPmanager.Instance.player01HpDown(player2Energy);
            }
            else if (player2Choice == Sign.EnergyPa)
            {
                Debug.Log("Player 2의 공격 성공!");
                HPmanager.Instance.player01HpDown(player2Energy);
                player2Energy = 0; player1Energy = 0;
            }
        }

        //플레이어1의 에너지파
        if (player1Choice == Sign.EnergyPa)
        {
            if (player2Choice == Sign.Charge)
            {
                player2Energy = 0;
                Debug.Log("Player 1의 공격 성공!");
                HPmanager.Instance.player02HpDown(player1Energy);
            }
            else if (player2Choice == Sign.Block)
            {
                player2Energy = 0;
                Debug.Log("Player 1의 공격 성공!");
                HPmanager.Instance.player02HpDown(player1Energy -1);
            }
            else if (player2Choice == Sign.Pa)
            {
                Debug.Log("Player 1의 공격 성공!");
                HPmanager.Instance.player02HpDown(player1Energy - player2Energy);
                player2Energy = 0;
            }
            else if (player2Choice == Sign.EnergyPa)
            {
                Debug.Log("힘의 균형");
                player2Energy = 0;
            }
            player1Energy = 0;
        }


        a++;
        ResetChoices();
    }

    void ResetChoices()
    {
        player1Choice = Sign.None;
        player2Choice = Sign.None;
    }

    private void Update()
    {
        //추가할부분=====타이밍매니저의 불변수를 가져와서 상태선택가능한지로 큰 조건문 추가해주세요.====
        //디폴트(시간 내 미 입력)는 Sign.None으로 유지해주시면 됩니다.
        if (timingManager.CanInputChange)
        {
            //=============Player01 키입력===============
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (player1Energy >= 3)
                {
                    player1Energy = 3;
                    player1Choice = Sign.EnergyPa;
                }
                else
                    player1Choice = Sign.Pa;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                player1Choice = Sign.Block;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                player1Choice = Sign.Charge;
            }

            //=============Player02 키입력==============
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                if (player2Energy >= 3)
                {
                    player2Energy = 3;
                    player2Choice = Sign.EnergyPa;
                }
                else
                    player2Choice = Sign.Pa;
            }
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                player2Choice = Sign.Block;
            }
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                player2Choice = Sign.Charge;
            }
        }
//====================================================================



        if(Input.GetKeyUp(KeyCode.Space))
        {
            //일단은 스페이스바로 결과보여주기와 리셋을 제어, 리듬시스템 조정시 이 기능 옮겨갈 예정
            DetermineWinner();
        }
    }
}
