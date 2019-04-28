using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendValue : MonoBehaviour
{

    public Button button;
    public Text buttonText;

    public CalculatorController calc;

    // Use this for initialization
    public double firstNumber = double.MaxValue;
    public void SetGameControllerReference(CalculatorController controller)
    {
        calc = controller;
    }
    public void UpdateText()
    {
        if (buttonText.text != "+" &&
            buttonText.text != "-" &&
            buttonText.text != "*" &&
            buttonText.text != "/" &&
            buttonText.text != "C" &&
            buttonText.text != "=")
        {
            calc.SetResultText(buttonText.text);
        }
        else
        {
            if (buttonText.text == "C")
            {
                calc.ClearAll();
            }
            else
            {
                if (calc.CheckLastChar())
                {
                    calc.SetLastChar(buttonText.text);
                    calc.ClearResultText();
                }
                else
                {
                    if (buttonText.text == "=")
                    {
                        calc.CalculateByChar();
                        calc.LastFunc();
                    }

                    else
                    {
                        calc.CalculateByChar();
                        calc.SetLastChar(buttonText.text);
                    }

                }
            }


        }


    }



}

