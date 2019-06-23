using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class testCalc : MonoBehaviour
{
    public fractionStuff fractionsAndthings;

    [HideInInspector]
    public int numerator1; 
   [HideInInspector]
    public int numerator2; 
    [HideInInspector]
    public int denominator1; 
    [HideInInspector]
    public int denominator2;
    
    void Start()
    {
                

    }

    void Update()
    {
       
        string dOperator;        

        if (Input.GetKeyDown("enter"))
        {
            
            if(int.TryParse(fractionsAndthings.numeratorA.text, out numerator1) && int.TryParse(fractionsAndthings.denomonatorA.text, out denominator1)
            && int.TryParse(fractionsAndthings.numeratorB.text, out numerator2) && int.TryParse(fractionsAndthings.denomonatorB.text, out denominator2))
            {

            dOperator = fractionsAndthings.operators.text.ToString();

                if (dOperator == "+")
                {
                    addFractions(numerator1, numerator2, denominator1, denominator2,fractionsAndthings.aDenomonator, fractionsAndthings.aNumerator);
                }

                else if (dOperator =="-")
                {
                    subFractions(numerator1, numerator2, denominator1, denominator2,fractionsAndthings.aDenomonator, fractionsAndthings.aNumerator);
                }

                else if (dOperator=="/")
                {
                    divFractions(numerator1, numerator2, denominator1, denominator2,fractionsAndthings.aDenomonator, fractionsAndthings.aNumerator);
                }

                else if (dOperator=="X")
                {
                    multFractions(numerator1, numerator2, denominator1, denominator2,fractionsAndthings.aDenomonator, fractionsAndthings.aNumerator);
                }
                
                Debug.Log(dOperator);            
                //Debug.Log(divFractions(n1,n2,d1,d2, fractionsAndthings.aDenomonator, fractionsAndthings.aNumerator));
            }
            
            else
            {
                Debug.LogError("Please Enter a Valid Number");
            }
        }
        

    }

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
    public Vector2Int addFractions(int numerator1, int numerator2, int denominator1, int denominator2, Text tDenominator, Text tNumerator)
    {
        Vector2Int newNum = new Vector2Int();
        int tempNumerator1; int tempNumerator2;
        int tempDenominator1; int tempDenominator2;
        int lcd = 0; int gcd = 0;

        int answerNumerator; int answerDenominator;        
        
        //Check the Denominators to make sure they're the same
        
        if (denominator1 != denominator2)
        {
            lcd = Mathf.Abs(findLCD(denominator1,denominator2));
            gcd = Mathf.Abs(findGCD(denominator1,denominator2));

            tempNumerator1 = numerator1 * (lcd/denominator1);
            tempNumerator2 = numerator2 * (lcd/denominator2);
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

            tDenominator.text = newNum.y.ToString();
            tNumerator.text = newNum.x.ToString();

        }
        Debug.Log(newNum);
        return newNum;
    }
    public Vector2Int subFractions(int numerator1, int numerator2, int denominator1, int denominator2, Text tDenominator, Text tNumerator)
    {
        Vector2Int newNum = new Vector2Int();
        int tempNumerator1; int tempNumerator2;
        int tempDenominator1; int tempDenominator2;
        int lcd = 0; int gcd = 0;

        int answerNumerator; int answerDenominator;
        
        //Check the Denominators to make sure they're the same
        if (denominator1 != denominator2)
        {
            lcd = Mathf.Abs(findLCD(denominator1,denominator2));
            gcd = Mathf.Abs(findGCD(denominator1,denominator2));

            tempNumerator1 = numerator1 * (lcd/denominator1);
            tempNumerator2 = numerator2 * (lcd/denominator2);
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

            tDenominator.text = newNum.y.ToString();
            tNumerator.text = newNum.x.ToString();

        }
        Debug.Log(newNum);
        return newNum;
    }

    public Vector2Int multFractions(int numerator1, int numerator2, int denominator1, int denominator2, Text tDenominator, Text tNumerator)
    {
       Vector2Int fractionOutput = new Vector2Int();
        int answerNumerator; int answerDenominator;
        int temporaryNumerator; int temporaryDenominator;
        
        //Multiply the Numerators
        temporaryNumerator = numerator1 * numerator2;
        
        //Multiply the Denomonators
        temporaryDenominator = denominator1 * denominator2;

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


        //Setting the textbox to display the answer
        tDenominator.text = answerDenominator.ToString();
        tNumerator.text = answerNumerator.ToString();

        return fractionOutput;
    }

    public int divFractions(int n1, int n2, int d1, int d2, Text tDen, Text tNum)
    {
        
        int results = 0;
        
        //Setting the recripicle
        int rN = d2; int rD = n2;
        int aN; int aD;
        int tN; int tD;

        //Multiplying the Numerator of fraction 1 by the recripicle of Fraction 2
        tN = n1 * rN;
        tD = d1 * rD;

        //Finding the GCD of the answer to simplify
        int GCD = findGCD(tN,tD);

        //Simplifying the fraction down
        aN = tN/GCD;
        Debug.Log("Numerator: "+ aN );
        aD = tD/GCD;
        Debug.Log("Denomonator: "+ aD );
        
        //Displaying the number
        tDen.text = aD.ToString();
        tNum.text = aN.ToString();

        return results;
    }

#endregion

        [System.Serializable]
        public class fractionStuff
        {
            public InputField numeratorA;
            public InputField numeratorB;
            public InputField operators;
            public InputField denomonatorA;
            public InputField denomonatorB;
            public Text aNumerator;
            public Text aDenomonator;
            public Text instructionsDialogue;
            [TextArea(100,200)]
            public string initialInstructions;

        }

}