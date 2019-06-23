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
        Vector2Int newNum = new Vector2Int();
        int tempNumerator1; int tempNumerator2;
        int tempDenominator1; int tempDenominator2;
        int lcd = 0; int gcd = 0;

        int answerNumerator; int answerDenominator;        
        
        //Check the Denominators to make sure they're the same
        
        if (fraction1.y != fraction2.y)
        {
            lcd = Mathf.Abs(findLCD(fraction1.y,fraction2.y));
            Debug.Log("LCD: " + lcd);
            gcd = Mathf.Abs(findGCD(fraction1.y,fraction2.y));
            Debug.Log("GCD: " + gcd);

            tempNumerator1 = fraction1.x * (lcd/fraction1.y);
            tempNumerator2 = fraction2.x * (lcd/fraction2.y);
            Debug.Log("TempNumerator: " + tempNumerator2);
            tempDenominator1 = lcd;
            tempDenominator2 = lcd; 
            
            
            
            Debug.Log("Fraction 1: " + tempNumerator1 + "/" + tempDenominator1);
            Debug.Log("Fraction 2: " + tempNumerator2 + "/" + tempDenominator2);
            Debug.Log(lcd);

            answerNumerator = tempNumerator1 + tempNumerator2;
            answerDenominator = lcd;

            gcd = Mathf.Abs(findGCD(answerNumerator,answerDenominator));

            answerNumerator = answerNumerator/gcd;
            answerDenominator = answerDenominator/gcd;
            
            Vector2Int tempAnswer = new Vector2Int(answerNumerator,answerDenominator);
            newNum = tempAnswer;

            Debug.Log("Answer = " + answerNumerator + "/" + answerDenominator);


        }
        Debug.Log(newNum);
        return newNum;
    }
    public Vector2Int subFractions(Vector2Int fraction1, Vector2Int fraction2)
    {
        Vector2Int newNum = new Vector2Int();
        int tempNumerator1; int tempNumerator2;
        int tempDenominator1; int tempDenominator2;
        int lcd = 0; int gcd = 0;

        int answerNumerator; int answerDenominator;
        
        //Check the Denominators to make sure they're the same
        if (fraction1.y != fraction2.y)
        {
            lcd = Mathf.Abs(findLCD(fraction1.y,fraction2.y));
            gcd = Mathf.Abs(findGCD(fraction1.y,fraction2.y));

            tempNumerator1 = fraction1.x * (lcd/fraction1.y);
            tempNumerator2 = fraction2.x * (lcd/fraction2.y);
            tempDenominator1 = lcd;
            tempDenominator2 = lcd; 
            
            
            
            Debug.Log("Fraction 1: " + tempNumerator1 + "/" + tempDenominator1);
            Debug.Log("Fraction 2: " + tempNumerator2 + "/" + tempDenominator2);
            Debug.Log(lcd);

            answerNumerator = tempNumerator1 - tempNumerator2;
            answerDenominator = lcd;

            gcd = Mathf.Abs(findGCD(answerNumerator,answerDenominator));

            answerNumerator = answerNumerator/gcd;
            answerDenominator = answerDenominator/gcd;
            
            Vector2Int tempAnswer = new Vector2Int(answerNumerator,answerDenominator);
            newNum = tempAnswer;

            Debug.Log("Answer = " + answerNumerator + "/" + answerDenominator);

        }
        Debug.Log(newNum);
        return newNum;
    }

    public Vector2Int multFractions(Vector2Int fraction1, Vector2Int fraction2)
    {
       Vector2Int fractionOutput = new Vector2Int();
        int answerNumerator; int answerDenominator;
        int temporaryNumerator; int temporaryDenominator;
        
        //Multiply the Numerators
        temporaryNumerator = fraction1.x * fraction2.x;
        
        //Multiply the Denomonators
        temporaryDenominator = fraction1.y * fraction2.y;

        answerNumerator = temporaryNumerator;
        answerDenominator = temporaryDenominator;
        
        Debug.Log("Numerator: " + answerNumerator);
        Debug.Log("Denomonator: " + answerDenominator);
        
        //Finding the GCD of the Numerator and the denomoniator of the answer, to ensure fraction has been simplified
        int gcd = findGCD(answerNumerator, answerDenominator);
        
        //Simplifying the fraction
        answerNumerator = answerNumerator/gcd;
        Debug.Log("Numerator: " + answerNumerator);
        answerDenominator = answerDenominator/gcd;
        Debug.Log("Denomonator: " + answerDenominator);

        return fractionOutput;
    }

    public Vector2Int divFractions(Vector2Int fraction1, Vector2Int fraction2)
    {
        
        //Setting the recripicle
        
        Vector2Int recripicleFraction = new Vector2Int(fraction2.y,fraction2.x);
        Vector2Int tempFraction = new Vector2Int();
        Vector2Int answerFraction = new Vector2Int();

        //Multiplying the Numerator of fraction 1 by the recripicle of Fraction 2
        tempFraction.x = fraction1.x * recripicleFraction.x;
        tempFraction.y  = fraction1.y * recripicleFraction.y;

        //Finding the GCD of the answer to simplify
        int GCD = findGCD(tempFraction.x,tempFraction.y);

        //Simplifying the fraction down
        answerFraction.x = tempFraction.x/GCD;
        Debug.Log("Numerator: "+ answerFraction.x );
        answerFraction.y = tempFraction.y/GCD;
        Debug.Log("Denomonator: "+ answerFraction.y );

        return answerFraction;
    }

#endregion



}
