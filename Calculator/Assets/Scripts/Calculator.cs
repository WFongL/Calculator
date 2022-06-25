using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class Calculator : MonoBehaviour
{
    public string Calculate(string equation)
    {
        double[] values = equation.Split('+', '-', '*', '/', '^').Select(double.Parse).ToArray();
        char[] separators = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',' };
        string[] operators = equation.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        List<double> valuesList = values.ToList();
        List<string> operatorsList = operators.ToList();

        double answer = 0;
        for (int i = 0; i < operatorsList.Count; i++)
        {
            switch (operatorsList[i])
            {
                case "^":
                    valuesList[i] = Math.Pow(valuesList[i], valuesList[i + 1]);
                    valuesList.RemoveAt(i + 1);
                    operatorsList.RemoveAt(i);
                    i--;
                    break;
                default:
                    break;
            }
        }
        for (int i = 0; i < operatorsList.Count; i++)
        {
            switch (operatorsList[i])
            {
                case "*":
                    valuesList[i] *= valuesList[i+1];
                    valuesList.RemoveAt(i+1);
                    operatorsList.RemoveAt(i);
                    i--;
                    break;
                case "/":
                    if (valuesList[i+1] == 0)
                        answer = 0;
                    else
                    {
                        valuesList[i] /= valuesList[i + 1];
                        valuesList.RemoveAt(i + 1);
                        operatorsList.RemoveAt(i);
                    }
                    break;
                default:
                    break;
            }
        }
        answer = valuesList[0];
        for (int i = 0; i < operatorsList.Count; i++)
        {
            switch (operatorsList[i])
            {
                case "+":
                    answer += valuesList[i+1];
                    break;
                case "-":
                    answer -= valuesList[i+1];
                    break;
                default:
                    break;
            }
        }
        return $"{answer}";
    }
}