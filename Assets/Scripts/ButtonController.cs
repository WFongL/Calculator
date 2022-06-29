using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public string value;
    public DisplayController displayController;

    public void Start()
    {
        displayController = GameObject.Find("DisplayPanel").GetComponent<DisplayController>();
    }

    public void AppendValueToDisplay()
    {
        displayController.UpdateDisplayText(value);
    }

    public void Clear() // C 
    {
        displayController.ClearDisplay();
    }

    public void RemoveDigit() // < 
    {
        displayController.RemoveDigitDisplay();
    }

    public void ClearCurrentEntry() // CE 
    {
        displayController.ClearCurrentEntryDisplay();
    }

    public void EvaluateEquation() // = 
    {
        displayController.DisplayAnswer();
    }
}