using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sign
{
    None,       //�ʱ����, ���Է�
    Pa,         //����
    Block,      //����
    Charge,     //�������
    EnergyPa    //Ǯ������������
}

public class InputManager : MonoBehaviour
{
    [SerializeField] TimingManager timingManager;

    private Sign player1Choice = Sign.None;
    private Sign player2Choice = Sign.None;

    public int player1Energy = 0;
    public int player2Energy = 0;

    public int a = 0;

    /*
    public AudioSource leftattack;
    public AudioSource rightattack;
    public AudioSource leftcharge;
    public AudioSource rightcharge;
    public AudioSource block;
    public AudioSource leftsuperattack;
    public AudioSource rightsuperattack;
    public AudioSource lefthit;
    public AudioSource righthit;
    public AudioSource death;
    */

    public AudioSource player1;
    public AudioSource player2;

    public AudioClip leftattackclip;
    public AudioClip rightattackclip;
    public AudioClip leftchargeclip;
    public AudioClip rightchargeclip;
    public AudioClip blockclip;
    public AudioClip leftsuperattackclip;
    public AudioClip rightsuperattackclip;
    public AudioClip lefthitclip;
    public AudioClip righthitclip;
    public AudioClip deathclip;

    void Start()
    {

    }


//======================��������========================
//: ���Ŀ� ���ϰ��� �ִ� �Լ��� �����Ͽ� �Ʒ� Debug.Log -> return ���� �����ҿ����Դϴ�.
//  �� ���ϰ��� TimingManager�� ���Ȯ���Լ����� �޾ƿ��� �˴ϴ�.
//  �߰��� �ݺ��Ǵ� �ڵ尡 ���Ƽ� ����� �ϴ� ��ɱ������� �ϰ� ���Ŀ� ������ �� ������ �ϰڽ��ϴ�.
    public void DetermineWinner()
    {
        if(player1Choice == Sign.None)
        {
            /*
            if (player2Choice == Sign.None)
            {
                Debug.Log("Ű�Է´��");
            }
            */
            if (player2Choice == Sign.Charge)
            {
                AnimatorRight.Instance.Charge();
                player2.clip = rightchargeclip;
                player2.Play(); //audio in
                player2Energy++;
                //Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Block)
            {
                AnimatorRight.Instance.Block();
                player2.clip = blockclip;
                player2.Play(); //audio in
                //Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Pa)
            {
                AnimatorRight.Instance.Pa();
                AnimatorLeft.Instance.Damaged();
                player1.clip = lefthitclip;
                player2.clip = rightattackclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
               // Debug.Log("Player 2�� ���� ����!");
                HPmanager.Instance.player01HpDown(1);
                player2Energy--;    
                if(player1Energy >0)
                    player1Energy--;
            }
            else if (player2Choice == Sign.EnergyPa)
            {
                AnimatorRight.Instance.EnergyPa();
                AnimatorLeft.Instance.Damaged();
                player1.clip = lefthitclip;
                player2.clip = rightsuperattackclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                //Debug.Log("Player 2�� ���� ����!");
                HPmanager.Instance.player01HpDown(3);
                player2Energy = 0;  player1Energy = 0;
            }
        }


        //�÷��̾�1�� ����
        if (player1Choice == Sign.Pa)
        {
            if(player2Choice == Sign.None)
            {
                AnimatorLeft.Instance.Pa();
                AnimatorRight.Instance.Damaged();
                player1.clip = leftattackclip;
                player2.clip = righthitclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                if (player2Energy > 0)
                    player2Energy--;
                HPmanager.Instance.player02HpDown(1);
            }
            else if (player2Choice == Sign.Charge)
            {
                AnimatorLeft.Instance.Pa();
                AnimatorRight.Instance.Damaged();
                player1.clip = leftattackclip;
                player2.clip = righthitclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                if (player2Energy > 0)
                    player2Energy--;
                //Debug.Log("Player 1�� ���� ����!");
                HPmanager.Instance.player02HpDown(1);   //�Ϲ� Pa�������� ������ �� -> 10���� ����
            }
            else if(player2Choice == Sign.Block)
            {
                AnimatorLeft.Instance.Pa();
                AnimatorRight.Instance.Block();
                player1.clip = leftattackclip;
                player2.clip = blockclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                //Debug.Log("Blocking");
            }
            else if(player2Choice == Sign.Pa)
            {
                AnimatorLeft.Instance.Pa();
                AnimatorRight.Instance.Pa();
                player1.clip = leftattackclip;
                player2.clip = rightattackclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                //Debug.Log("Pa ���");
                player2Energy--;
            }
            else if(player2Choice == Sign.EnergyPa)
            {
                AnimatorRight.Instance.EnergyPa();
                AnimatorLeft.Instance.Damaged();
                player1.clip = lefthitclip;
                player2.clip = rightsuperattackclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                //Debug.Log("Player 2�� ���� ����!");
                HPmanager.Instance.player01HpDown(3);
                player2Energy = 0;  player1Energy = 0;
            }
            if(player1Energy > 0)
                player1Energy--;
        }

        //�÷��̾�1�� ����
        if (player1Choice == Sign.Block)
        {
            if(player2Choice == Sign.None)
            {
                AnimatorLeft.Instance.Block();
                player1.clip = blockclip;
                player1.Play(); //audio in
                //Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Charge)
            {
                AnimatorLeft.Instance.Block();
                AnimatorRight.Instance.Charge();
                player1.clip = blockclip;
                player2.clip = rightchargeclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                player2Energy++;
                //Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Block)
            {
                AnimatorLeft.Instance.Block();
                AnimatorRight.Instance.Block();
                player1.clip = blockclip;
                player2.clip = blockclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                //Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Pa)
            {
                AnimatorLeft.Instance.Block();
                AnimatorRight.Instance.Pa();
                player1.clip = blockclip;
                player2.clip = rightattackclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                player2Energy--;
                //Debug.Log("Blocking");
            }
            else if (player2Choice == Sign.EnergyPa)
            {
                AnimatorRight.Instance.EnergyPa();
                AnimatorLeft.Instance.Damaged();
                player1.clip = lefthitclip;
                player2.clip = rightsuperattackclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                //Debug.Log("Player 2�� ���� ����!");
                HPmanager.Instance.player01HpDown(3);
                player2Energy = 0; player1Energy = 0;
            }
        }

        //�÷��̾�1�� �������
        if (player1Choice == Sign.Charge)
        {
            player1Energy++;
            if(player2Choice == Sign.None)
            {
                AnimatorLeft.Instance.Charge();
                player1.clip = leftchargeclip;
                player1.Play(); //audio in
                //Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Charge)
            {
                AnimatorLeft.Instance.Charge();
                AnimatorRight.Instance.Charge();
                player1.clip = leftchargeclip;
                player2.clip = rightattackclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                player2Energy++;
                //Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Block)
            {
                AnimatorLeft.Instance.Charge();
                AnimatorRight.Instance.Block();
                player1.clip = leftchargeclip;
                player2.clip = blockclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                //Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Pa)
            {
                AnimatorRight.Instance.Pa();
                AnimatorLeft.Instance.Damaged();
                player1.clip = lefthitclip;
                player2.clip = rightattackclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                player2Energy--; player1Energy--;
                if (player1Energy > 0)
                    player1Energy--;
                //Debug.Log("Player 2�� ���� ����!");
                HPmanager.Instance.player01HpDown(1);
            }
            else if (player2Choice == Sign.EnergyPa)
            {
                AnimatorRight.Instance.EnergyPa();
                AnimatorLeft.Instance.Damaged();
                player1.clip = lefthitclip;
                player2.clip = rightsuperattackclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                //Debug.Log("Player 2�� ���� ����!");
                HPmanager.Instance.player01HpDown(3);
                player2Energy = 0; //player1Energy = 0;
                player1Energy = 0; //����
            }
        }

        //�÷��̾�1�� ��������
        if (player1Choice == Sign.EnergyPa)
        {
            if(player2Choice == Sign.None)
            {
                AnimatorLeft.Instance.EnergyPa();
                AnimatorRight.Instance.Damaged();
                player1.clip = leftsuperattackclip;
                player2.clip = righthitclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                player2Energy = 0;
                HPmanager.Instance.player02HpDown(3);
            }
            else if (player2Choice == Sign.Charge)
            {
                AnimatorLeft.Instance.EnergyPa();
                AnimatorRight.Instance.Damaged();
                player1.clip = leftsuperattackclip;
                player2.clip = righthitclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                player2Energy = 0;
                //Debug.Log("Player 1�� ���� ����!");
                HPmanager.Instance.player02HpDown(3);
            }
            else if (player2Choice == Sign.Block)
            {
                AnimatorLeft.Instance.EnergyPa();
                AnimatorRight.Instance.Damaged();
                player1.clip = leftsuperattackclip;
                player2.clip = righthitclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                player2Energy = 0;
                //Debug.Log("Player 1�� ���� ����!");
                HPmanager.Instance.player02HpDown(3);
            }
            else if (player2Choice == Sign.Pa)
            {
                AnimatorLeft.Instance.EnergyPa();
                AnimatorRight.Instance.Damaged();
                player1.clip = leftsuperattackclip;
                player2.clip = righthitclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                //Debug.Log("Player 1�� ���� ����!");
                HPmanager.Instance.player02HpDown(3);
                player2Energy = 0;
            }
            else if (player2Choice == Sign.EnergyPa)
            {
                AnimatorLeft.Instance.EnergyPa();
                AnimatorRight.Instance.EnergyPa();
                player1.clip = leftsuperattackclip;
                player2.clip = rightsuperattackclip;
                player1.Play(); //audio in
                player2.Play(); //audio in
                //Debug.Log("�������� ���");
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

    public void ResetAnimation()
    {
        AnimatorLeft.Instance.Stand();
        AnimatorRight.Instance.Stand();
    }

    private void Update()
    {
        //�߰��Һκ�=====Ÿ�ָ̹Ŵ����� �Һ����� �����ͼ� ���¼��ð��������� ū ���ǹ� �߰����ּ���.====
        //����Ʈ(�ð� �� �� �Է�)�� Sign.None���� �������ֽø� �˴ϴ�.
        if (timingManager.CanInputChange)
        {
            //=============Player01 Ű�Է�===============
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if(player1Energy == 0)
                {
                    player1Choice = Sign.None;
                }
                else if (player1Energy >= 3)
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

            //=============Player02 Ű�Է�==============
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                if( player2Energy == 0)
                {
                    player2Choice = Sign.None;
                }
                else if (player2Energy >= 3)
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


        /*
        if(Input.GetKeyUp(KeyCode.Space))
        {
            //�ϴ��� �����̽��ٷ� ��������ֱ�� ������ ����, ����ý��� ������ �� ��� �Űܰ� ����
            DetermineWinner();
        }
        */
    }
}
