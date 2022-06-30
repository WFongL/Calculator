using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] public DisplayController displayController;
    public string value;

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