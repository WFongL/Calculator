using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class Calculator : MonoBehaviour
{
    private List<double> numbers;
    private List<string> operators;

    private double answer = 0;

    public string Calculate(string equation)
    {
        double[] arrayOfNumbers = equation.Split('+', '-', '*', '/', '^').Select(double.Parse).ToArray();
        char[] separators = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',' };
        string[] arrayOperators = equation.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        List<double> numbers = arrayOfNumbers.ToList();
        List<string> operators = arrayOperators.ToList();

        NumberInPower(numbers, operators);

        MultiplicationDndDivision(numbers, operators);

        answer = numbers[0];
        AddingAndSubtracting(numbers, operators);
        return $"{answer}";
    }

    private void NumberInPower(List<double> numbers, List<string> operators)
    {
        for (int i = 0; i < operators.Count; i++)
        {
            if (operators[i] == "^")
            {
                numbers[i] = Math.Pow(numbers[i], numbers[i + 1]);
                numbers.RemoveAt(i + 1);
                operators.RemoveAt(i);
                i--;
            }
        }
    }

    private void MultiplicationDndDivision(List<double> numbers, List<string> operators)
    {
        for (int i = 0; i < operators.Count; i++)
        {
            switch (operators[i])
            {
                case "*":
                    numbers[i] *= numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                    break;
                case "/":
                    if (numbers[i + 1] == 0)
                        answer = 0;
                    else
                    {
                        numbers[i] /= numbers[i + 1];
                        numbers.RemoveAt(i + 1);
                        operators.RemoveAt(i);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void AddingAndSubtracting(List<double> numbers, List<string> operators)
    {
        for (int i = 0; i < operators.Count; i++)
        {
            if(operators[i] == "+")
                answer += numbers[i + 1];
            if (operators[i] == "-")
                answer -= numbers[i + 1];
        }
    }
}