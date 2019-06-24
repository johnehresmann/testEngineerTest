using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class fractionFormulas
{
    #region GCD and LCD

    //Find the LCD of variables
    public int findLCD(int a, int b)
    {
        int num1; int num2;
        if(a > b)
        {
            num1 = a; num2 = b;
        }
        else
        {
            num1 = b; num2 = a;
        }
        for (int i = 1; i < num2; i++)
        {
            if ((num1*i) % num2 ==0)
            {
                return i * num1;
            }
        }

        return num1 * num2;
    }

    //Find the GCD of variables
    public int findGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

#endregion

#region Math Functions
    public Vector2Int addFractions(Vector2Int fraction1, Vector2Int fraction2)
    {
        Vector2Int answerFraction = new Vector2Int();

        int lcd = Mathf.Abs(findLCD(fraction1.y,fraction2.y));
        int gcd = Mathf.Abs(findGCD(fraction1.y,fraction2.y));

        int answerNumerator; 
        int answerDenominator = lcd;
        Debug.Log("Fraction 2: " + fraction2.x + "/" + fraction2.y);
        
        //Check the Denominators to make sure they're the same
        if (fraction1.y != fraction2.y)
        {
            
            int tempNumerator1; int tempNumerator2;
            
            if (fraction1.y != lcd)
            {
                tempNumerator1 = fraction1.x * (lcd/fraction1.y);
                fraction1.x = tempNumerator1;
                fraction1.y = lcd;
                answerDenominator = fraction1.y;
            }

            else if(fraction2.y != lcd)
            {
                
                
                tempNumerator2 = fraction2.x * (lcd/fraction2.y);
                fraction2.x = tempNumerator2;
                fraction1.y = lcd;
                answerDenominator = fraction1.y;
            }
        }
        else
        {
            answerDenominator = lcd;

        }
        
        Debug.Log("Fraction 1: " + fraction1.x + "/" + fraction1.y);
        
        Debug.Log(lcd);

        answerNumerator = fraction1.x + fraction2.x;
        Debug.Log("The Numerator for Fraction 2 is: " + fraction2.x);
        

        gcd = Mathf.Abs(findGCD(answerNumerator,answerDenominator));

        answerNumerator = answerNumerator/gcd;
        answerDenominator = answerDenominator/gcd;
        
        Vector2Int tempAnswer = new Vector2Int(answerNumerator,answerDenominator);
        answerFraction = tempAnswer;

        Debug.Log("Answer = " + answerNumerator + "/" + answerDenominator);

        return answerFraction;

    }
    public Vector2Int subFractions(Vector2Int fraction1, Vector2Int fraction2)
    {
        Vector2Int answerFraction = new Vector2Int();

        int lcd = Mathf.Abs(findLCD(fraction1.y,fraction2.y));
        int gcd = Mathf.Abs(findGCD(fraction1.y,fraction2.y));

        int answerNumerator; 
        int answerDenominator = lcd;
        
        //Check the Denominators to make sure they're the same
        if (fraction1.y != fraction2.y)
        {
            int tempNumerator1; int tempNumerator2;
            
            if (fraction1.y != lcd)
            {
                tempNumerator1 = fraction1.x * (lcd/fraction1.y);
                fraction1.x = tempNumerator1;
                fraction1.y = lcd;
                answerDenominator = fraction1.y;
            }

            else if(fraction2.y != lcd)
            {
                tempNumerator2 = fraction2.x * (lcd/fraction2.y);
                fraction2.x = tempNumerator2;
                fraction1.y = lcd;
                answerDenominator = fraction1.y;
            }
        }
        else
        {
            answerDenominator = lcd;

        }
        
        Debug.Log("Fraction 1: " + fraction1.x + "/" + fraction1.y);
        Debug.Log("Fraction 2: " + fraction2.y + "/" + fraction2.y);
        Debug.Log(lcd);

        answerNumerator = fraction1.x - fraction2.x;
        

        gcd = Mathf.Abs(findGCD(answerNumerator,answerDenominator));

        answerNumerator = answerNumerator/gcd;
        answerDenominator = answerDenominator/gcd;
        
        Vector2Int tempAnswer = new Vector2Int(answerNumerator,answerDenominator);
        answerFraction = tempAnswer;

        Debug.Log("Answer = " + answerNumerator + "/" + answerDenominator);

        return answerFraction;

    }

    public Vector2Int multFractions(Vector2Int fraction1, Vector2Int fraction2)
    {
       Vector2Int answerFraction = new Vector2Int();
        

        //Multiply the Numerators
        answerFraction.x = fraction1.x * fraction2.x;
        
        //Multiply the Denomonators
        answerFraction.y = fraction1.y * fraction2.y;
        
        Debug.Log("Numerator: " + answerFraction.x);
        Debug.Log("Denomonator: " + answerFraction.y);
        
        //Finding the GCD of the Numerator and the denomoniator of the answer, to ensure fraction has been simplified
        int gcd = Mathf.Abs(findGCD(answerFraction.x, answerFraction.y));
        
        //Simplifying the fraction
        answerFraction.x =answerFraction.x/gcd;
        Debug.Log("Numerator: " + answerFraction.x);
        answerFraction.y = answerFraction.y/gcd;
        Debug.Log("Denomonator: " + answerFraction.y);

        if (answerFraction.y < 0)
        {
            answerFraction = answerFraction * -1;
        }
        return answerFraction;
    }

    public Vector2Int divFractions(Vector2Int fraction1, Vector2Int fraction2)
    {
        
        //Setting the recripicle
        
        Vector2Int recripicleFraction = new Vector2Int(fraction2.y,fraction2.x);
        Debug.Log("Recripcle of: " + fraction2 + "is " + recripicleFraction);
        
        Vector2Int answerFraction = new Vector2Int();

        //Multiplying the Numerator of fraction 1 by the recripicle of Fraction 2
        answerFraction.x = fraction1.x * recripicleFraction.x;
        Debug.Log("Answer Numerator: " + answerFraction.x);
        answerFraction.y  = fraction1.y * recripicleFraction.y;
        Debug.Log("Answer Denominator: " + answerFraction.y);

        //Finding the GCD of the answer to simplify
        int GCD = Mathf.Abs(findGCD(answerFraction.x,answerFraction.y));
        Debug.Log(GCD);

        //Simplifying the fraction down
        answerFraction.x = answerFraction.x/GCD;
        Debug.Log("Numerator: "+ answerFraction.x );
        answerFraction.y = answerFraction.y/GCD;
        Debug.Log("Denomonator: "+ answerFraction.y );

        if (answerFraction.y < 0)
        {
            answerFraction = answerFraction * -1;
        }

        return answerFraction;
    }

#endregion



}
