using System.Collections;
using UnityEngine;
using DG.Tweening;

public class LoadingFadePanel : MonoBehaviour
{
    CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        // StartCoroutine(WaitAndFade());
    }

    // Update is called once per frame
    IEnumerator WaitAndFade()
    {
        yield return new WaitForSeconds(2.0f);
        canvasGroup.DOFade(0, 2.0f).SetEase(Ease.Linear).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
