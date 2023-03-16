using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenAnim : MonoBehaviour
{
    [SerializeField] private float animationTime = 2f;
    [SerializeField] private float waitingTime = 0.3f;

    private Image ObjectImage;
    private Color fullColor;
    private Color transparentColor;

    public bool test;

    private void Awake()
    {
        ObjectImage = GetComponent<Image>();

        fullColor = ObjectImage.color;
        fullColor.a = 1f;

        transparentColor = ObjectImage.color;
        transparentColor.a = 0f;
    }

    private void Update()
    {
        if (test)
        {
            test = false;
            PlayAnimation();
        }
    }

    public void PlayAnimation()
    {
        StopCoroutine(anim());
        StartCoroutine(anim());
        Debug.Log("Black screen");
    }

    private IEnumerator anim()
    {
        float time = 0;
        float step = 1f / animationTime;
        ObjectImage.color = fullColor;

        yield return new WaitForSeconds(waitingTime); // pause before start

        while (time < animationTime)
        {
            time += Time.deltaTime;
            ObjectImage.color = Color.Lerp(fullColor, transparentColor, step * time);
            yield return null;
        }

    }

}