using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string SceneToLoad;

    private CanvasGroup canvasGroup;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public AudioSource audioSource2;
    public AudioClip audioClip2;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    IEnumerator FadeOut()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 0.5f;
            audioSource2.volume -= Time.deltaTime * 0.5f;
            yield return null;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            StartCoroutine(FadeOut());
        }

        if (canvasGroup.alpha == 0)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
