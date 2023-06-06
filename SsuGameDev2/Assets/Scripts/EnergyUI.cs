using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyUI : MonoBehaviour
{
    public GameObject player1charge1;       //player1_energy_state
    public GameObject player1charge2;
    public GameObject player1charge3;

    public GameObject player2charge1;       //player2_energy_state
    public GameObject player2charge2;
    public GameObject player2charge3;

    public Sprite energy;
    public Sprite noenergy;

    GameObject InputManager;

    void Awake()
    {
        InputManager = GameObject.Find("InputManager");
    }

    void Start()
    {

    }

    //energy_state
    void Charge()
    {
        //player1
        if (InputManager.GetComponent<InputManager>().player1Energy == 0)
        {
            //Debug.Log("player1Energy is 0");
            player1charge1.GetComponent<SpriteRenderer>().sprite = noenergy;
            player1charge2.GetComponent<SpriteRenderer>().sprite = noenergy;
            player1charge3.GetComponent<SpriteRenderer>().sprite = noenergy;
        }
        else if (InputManager.GetComponent<InputManager>().player1Energy == 1)
        {
           // Debug.Log("player1Energy is 1");
            player1charge1.GetComponent<SpriteRenderer>().sprite = energy;
            player1charge2.GetComponent<SpriteRenderer>().sprite = noenergy;
            player1charge3.GetComponent<SpriteRenderer>().sprite = noenergy;
        }
        else if (InputManager.GetComponent<InputManager>().player1Energy == 2)
        {
            //Debug.Log("player1Energy is 2");
            player1charge1.GetComponent<SpriteRenderer>().sprite = energy;
            player1charge2.GetComponent<SpriteRenderer>().sprite = energy;
            player1charge3.GetComponent<SpriteRenderer>().sprite = noenergy;
        }
        else if (InputManager.GetComponent<InputManager>().player1Energy == 3)
        {
            //Debug.Log("player1Energy is 3");
            player1charge1.GetComponent<SpriteRenderer>().sprite = energy;
            player1charge2.GetComponent<SpriteRenderer>().sprite = energy;
            player1charge3.GetComponent<SpriteRenderer>().sprite = energy;
        }

        //player2
        if (InputManager.GetComponent<InputManager>().player2Energy == 0)
        {
            //Debug.Log("player2Energy is 0");
            player2charge1.GetComponent<SpriteRenderer>().sprite = noenergy;
            player2charge2.GetComponent<SpriteRenderer>().sprite = noenergy;
            player2charge3.GetComponent<SpriteRenderer>().sprite = noenergy;
        }
        else if (InputManager.GetComponent<InputManager>().player2Energy == 1)
        {
            //Debug.Log("player2Energy is 1");
            player2charge1.GetComponent<SpriteRenderer>().sprite = energy;
            player2charge2.GetComponent<SpriteRenderer>().sprite = noenergy;
            player2charge3.GetComponent<SpriteRenderer>().sprite = noenergy;
        }
        else if (InputManager.GetComponent<InputManager>().player2Energy == 2)
        {
            //Debug.Log("player2Energy is 2");
            player2charge1.GetComponent<SpriteRenderer>().sprite = energy;
            player2charge2.GetComponent<SpriteRenderer>().sprite = energy;
            player2charge3.GetComponent<SpriteRenderer>().sprite = noenergy;
        }
        else if (InputManager.GetComponent<InputManager>().player2Energy == 3)
        {
            //Debug.Log("player2Energy is 3");
            player2charge1.GetComponent<SpriteRenderer>().sprite = energy;
            player2charge2.GetComponent<SpriteRenderer>().sprite = energy;
            player2charge3.GetComponent<SpriteRenderer>().sprite = energy;
        }
    }

    void Update()
    {
        if (InputManager.GetComponent<InputManager>().a == 1)
        {
            Charge();
            InputManager.GetComponent<InputManager>().a = 0;
        }
    }
}