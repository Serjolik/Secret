using UnityEngine;
using UnityEngine.UI;
public class UIBaseFill : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Image imageBar;
    [SerializeField] protected TMPro.TMP_Text textBox;
    [Header("BarName")]
    [SerializeField] private string barName = "name";

    private float fill = 1f;
    protected virtual void FillBar(float param, float maxParam)
    {
        fill = param / maxParam;

        if (fill < 0 || fill > 1)
        {
            Debug.Log($"EXCEPTION in {name} bar incorrect filling");
            Debug.Log("variable (fill) is assigned 0");
            fill = 0;
        }

        imageBar.fillAmount = fill;
        TextBoxEdit(barName, param, maxParam);
    }

    private void TextBoxEdit(string fillingText, float param, float maxParam)
    {
        textBox.text = $"{fillingText}: {param}/{maxParam}";
        //Writes like Health: 20/50
    }
}