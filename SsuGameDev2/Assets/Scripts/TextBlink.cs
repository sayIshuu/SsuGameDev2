using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextBlink : MonoBehaviour
{
    Text flashingText;

    void Start()
    {
        flashingText = GetComponent<Text> ();
		StartCoroutine (BlinkText());
    }

    void Update()
    {
        
    }

    public IEnumerator BlinkText()
    {
		while (true)
        {
			flashingText.text = "";
			yield return new WaitForSeconds (0.5f);
			flashingText.text = "Click to Start";
			yield return new WaitForSeconds (0.5f);
		}
	}
}
