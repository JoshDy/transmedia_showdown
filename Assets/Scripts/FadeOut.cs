using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {
    // Update is called once per frame
    public void FadeMe () {
        StartCoroutine(DoFade());
	}

    IEnumerator DoFade ()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while(canvasGroup.alpha>0)
        {
            canvasGroup.alpha -= Time.deltaTime / 8;
            yield return null;
        }

        canvasGroup.interactable = false;
        yield return null;
    }
}
