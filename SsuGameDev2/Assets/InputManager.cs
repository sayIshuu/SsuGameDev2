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
    private Sign player1Choice = Sign.None;
    private Sign player2Choice = Sign.None;

    private int player1Energy = 0;
    private int player2Energy = 0;

    void Start()
    {

    }

    /*
    void Player1Choose(Sign choice)
    {
        player1Choice = choice;
        Player2Choose();
        DetermineWinner();
    }

    void Player2Choose()
    {
        // 임의로 Player2의 선택을 정하는 코드를 구현할 수 있습니다.
        // 예를 들어, Random.Range()를 사용하여 무작위로 선택하거나,
        // 실제로는 네트워크 통신 등을 통해 상대방의 선택을 받을 수 있습니다.
        player2Choice = (Sign)Random.Range(1, 4);
    }
    */

    void DetermineWinner()
    {
        //플레이어1의 공격
        if (player1Choice == Sign.Pa)
        {
            player1Energy = 0;
            if (player2Choice == Sign.Charge)
            {
                player2Energy = 0;
                Debug.Log("Player 1의 공격 성공!");
            }
            else if(player2Choice == Sign.Block)
            {
                Debug.Log("Blocking");
            }
            else if(player2Choice == Sign.Pa)
            {
                player2Energy = 0;
                if (player1Energy > player2Energy)
                    Debug.Log("Player 1의 공격 성공!");
                else if (player2Energy > player1Energy)
                    Debug.Log("Player 2의 공격 성공!");
                else
                    Debug.Log("힘의 균형");
            }
            else if(player2Choice == Sign.EnergyPa)
            {
                player2Energy = 0;
                Debug.Log("Player 2의 공격 성공!");
            }
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
                player2Energy = 0;
                Debug.Log("Player 2의 공격 성공!");
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
            }
            else if (player2Choice == Sign.EnergyPa)
            {
                player2Energy = 0; player1Energy = 0;
                Debug.Log("Player 2의 공격 성공!");
            }
        }

        //플레이어1의 에너지파
        if (player1Choice == Sign.EnergyPa)
        {
            player1Energy = 0;
            if (player2Choice == Sign.Charge)
            {
                player2Energy = 0;
                Debug.Log("Player 1의 공격 성공!");
            }
            else if (player2Choice == Sign.Block)
            {
                player2Energy = 0;
                Debug.Log("Player 1의 공격 성공!");
            }
            else if (player2Choice == Sign.Pa)
            {
                player2Energy = 0;
                Debug.Log("Player 1의 공격 성공!");
            }
            else if (player2Choice == Sign.EnergyPa)
            {
                player2Energy = 0;
                Debug.Log("힘의 균형");
            }
        }


        ResetChoices();
    }

    void ResetChoices()
    {
        player1Choice = Sign.None;
        player2Choice = Sign.None;
    }

    private void Update()
    {
        //=============Player01 키입력===============
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(player1Energy >= 3)
                player1Choice = Sign.EnergyPa;
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
                player2Choice = Sign.EnergyPa;
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



        if(Input.GetKeyUp(KeyCode.Space))
        {
            //일단은 스페이스바로 결과보여주기와 리셋을 제어, 리듬시스템 조정시 이 기능 옮겨갈 예정
            DetermineWinner();
        }
    }
}
