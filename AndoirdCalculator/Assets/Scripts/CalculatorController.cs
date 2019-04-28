using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorController : MonoBehaviour {

    public Text resultText;
    public Text helpText;
    public Text errorMsg;
    public string _lastChar = "";
    public double number;
    public bool DivideByZeroEx = false;
    
	public void SetResultText(string result)
    {
        resultText.text += result;
    }

    public void ClearResultText()
    {
        number = double.Parse(resultText.text);
        helpText.text = number.ToString();
        resultText.text = "";
    }

    public bool CheckLastChar()
    {
        if (_lastChar == "")
            return true;
        else
            return false;
    }

    public void SetLastChar(string lastChar)
    {
        if(DivideByZeroEx)
        {
            _lastChar = "/";
            DivideByZeroEx = false;
        }
        else
        {
            _lastChar = lastChar;
        }
       
    }

    public void LastFunc()
    {
        if(!DivideByZeroEx)
        {
            helpText.text = "";
            resultText.text = number.ToString();
            SetLastChar("");
            
        }
       
    }

    public void ClearAll()
    {
        helpText.text = "";
        resultText.text = "";
        number = 0;
        SetLastChar("");
    }

    public void CalculateByChar()
    {
        errorMsg.text = "";
        if(_lastChar != "")
        {
            switch(_lastChar)
            {
                case "+":
                    {
                        number = number + double.Parse(resultText.text);
                        helpText.text = number.ToString();
                        resultText.text = "";
                        break;
                    }
                case "-":
                    {
                        number = number - double.Parse(resultText.text);
                        helpText.text = number.ToString();
                        resultText.text = "";
                        break;
                    }
                case "*":
                    {
                        number = number * double.Parse(resultText.text);
                        helpText.text = number.ToString();
                        resultText.text = "";
                        break;
                    }
                case "/":
                    {
                        if(resultText.text != "0")
                        {
                            number = number / double.Parse(resultText.text);
                            helpText.text = number.ToString();
                            DivideByZeroEx = false;
                            resultText.text = "";
                            break;
                        }
                        else
                        {
                            errorMsg.text = "Nie dziel przez 0!";
                            DivideByZeroEx = true;
                            resultText.text = "";
                            break;
                        }
                       
                    }
            }
        }
    }
}
