using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DisplayController : MonoBehaviour
{
    private TMP_Text display;
    public Calculator calculator;

    List<char> digits = new List<char>(11) { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',' };
    List<char> operators = new List<char>(4) { '+', '-', '*', '/', '^' };

    void Start()
    {
        display = GameObject.Find("DisplayText").GetComponent<TMP_Text>();
    }

    public void UpdateDisplayText(string newValue) // validation check 
    {
        if (newValue == "," && operators.Contains(display.text[display.text.Length - 1]))
            return; // do not allow to put a comma after the operator

        if (newValue == ",")
        {
            for (int i = display.text.Length - 1; i > 0 ; i--)
            {
                if (operators.Contains(display.text[i]))
                {
                    display.text += newValue;
                    return;
                }
                if (display.text[i] == ',')
                    return;  // do not allow to put more than one comma in a number
            }
        }

        if (operators.Contains(newValue[0]) && operators.Contains(display.text[display.text.Length - 1]))
            display.text = display.text.Substring(0, display.text.Length - 1);
            // do not allow to place more than one operator in a row

        if (operators.Contains(display.text[0]))
            display.text = "0"; // do not allow the operator before the number

        if (display.text == "0" && digits.Contains(newValue[0]) || display.text.Contains('='))
        {
            if (newValue[0] == ',') { } // if it is a coma then continue from scratch
            else
                display.text = ""; // clear the equation before entering the number
        }

        display.text += newValue;
    }

    public void ClearDisplay() // C 
    {
        display.text = "0";
    }

    public void RemoveDigitDisplay() // < 
    {
        if (display.text.Length - 1 <= 0)
        {
            display.text = "0";
            return;
        }
        display.text = display.text.Substring(0, display.text.Length - 1);
    }

    public void ClearCurrentEntryDisplay() // CE 
    {
        for (int i = display.text.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                display.text = "0";
                return;
            }
            if (digits.Contains(display.text[i]))
                display.text = display.text.Substring(0, display.text.Length - 1);
            else
                return;
        }
    }

    public void DisplayAnswer() // = 
    {
        if (operators.Contains(display.text[display.text.Length - 1]))
            return;
        string answer = calculator.Calculate(display.text);
        display.text = $"{answer}";
    }
}