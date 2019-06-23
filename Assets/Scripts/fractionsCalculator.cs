using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class fractionsCalculator : MonoBehaviour
{
    public fractionStuff fractionsAndthings;
    fractionFormulas customMath = new fractionFormulas();

    public Vector2Int fraction1;
    public Vector2Int fraction2;

    [HideInInspector]
    public int numerator1; 
   [HideInInspector]
    public int numerator2; 
    [HideInInspector]
    public int denominator1; 
    [HideInInspector]
    public int denominator2;
    [HideInInspector]
    public Vector2Int answerFraction;
    
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
                fraction1.x = numerator1; fraction1.y = denominator1;
                fraction2.x = denominator1; fraction2.y = denominator2;

                dOperator = fractionsAndthings.operators.text.ToString();

                if (dOperator == "+")
                {
                    answerFraction = customMath.addFractions(fraction1, fraction2);
                    fractionsAndthings.aNumerator.text = answerFraction.x.ToString();
                    fractionsAndthings.aDenomonator.text = answerFraction.y.ToString();                   
                }

                else if (dOperator =="-")
                {
                    answerFraction = customMath.addFractions(fraction1, fraction2);
                    fractionsAndthings.aNumerator.text = answerFraction.x.ToString();
                    fractionsAndthings.aDenomonator.text = answerFraction.y.ToString();
                }

                else if (dOperator=="/")
                {
                    answerFraction = customMath.addFractions(fraction1, fraction2);
                    fractionsAndthings.aNumerator.text = answerFraction.x.ToString();
                    fractionsAndthings.aDenomonator.text = answerFraction.y.ToString();

                }

                else if (dOperator=="X")
                {
                    answerFraction = customMath.addFractions(fraction1, fraction2);
                    fractionsAndthings.aNumerator.text = answerFraction.x.ToString();
                    fractionsAndthings.aDenomonator.text = answerFraction.y.ToString();
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