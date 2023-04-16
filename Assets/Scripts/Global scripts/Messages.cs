using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{
    [SerializeField] private float visibleTime = 2f;

    private Image panel;
    private TMPro.TextMeshProUGUI text;

    private float startPanelAlpha;
    private float startTextAlpha;

    private Color startPanelColor;
    private Color startTextColor;
    private Color endPanelColor;
    private Color endTextColor;


    private void Awake()
    {
        panel = GetComponent<Image>();
        text = GetComponentInChildren<TMPro.TextMeshProUGUI>();

        startPanelAlpha = panel.color.a;
        startTextAlpha = text.color.a;

        startPanelColor = new Color(panel.color.r, panel.color.g, panel.color.b, startPanelAlpha);
        startTextColor = new Color(text.color.r, text.color.g, text.color.b, startTextAlpha);

        endPanelColor = new Color(panel.color.r, panel.color.g, panel.color.b, 0);
        endTextColor = new Color(text.color.r, text.color.g, text.color.b, 0);
    }
    private void OnEnable()
    {
        StartCoroutine(VisibleTime());
    }

    private IEnumerator VisibleTime()
    {
        float time = 0;
        float step = 1f / visibleTime;

        while (time < visibleTime)
        {
            time += Time.deltaTime;

            panel.color = Color.Lerp(startPanelColor, endPanelColor, step * time);
            text.color = Color.Lerp(startTextColor, endTextColor, step * time);

            yield return null;
        }

        this.gameObject.SetActive(false);

    }

}
