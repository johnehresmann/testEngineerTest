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
        string instructions = fractionsAndthings.initialInstructions.ToString();
        fractionsAndthings.instructionsDialogue.text = instructions;
    }

    void Update()
    {
       string mCurrent = fractionsAndthings.userOpperator.text.ToString();

        if (Input.GetKeyDown("enter") | Input.GetKeyDown("return"))
        {
            
            if(int.TryParse(fractionsAndthings.numeratorA.text, out numerator1) && int.TryParse(fractionsAndthings.denomonatorA.text, out denominator1)
            && int.TryParse(fractionsAndthings.numeratorB.text, out numerator2) && int.TryParse(fractionsAndthings.denomonatorB.text, out denominator2))
            {
                fraction1.x = numerator1; fraction1.y = denominator1;
                fraction2.x = numerator2; fraction2.y = denominator2;

                

                if (mCurrent == "+")
                {
                    answerFraction = customMath.addFractions(fraction1, fraction2);
                    fractionsAndthings.aNumerator.text = answerFraction.x.ToString();
                    fractionsAndthings.aDenomonator.text = answerFraction.y.ToString();
                    fractionsAndthings.instructionsDialogue.text = fractionsAndthings.initialInstructions;                 
                }

                else if (mCurrent =="-")
                {
                    answerFraction = customMath.subFractions(fraction1, fraction2);
                    fractionsAndthings.aNumerator.text = answerFraction.x.ToString();
                    fractionsAndthings.aDenomonator.text = answerFraction.y.ToString();
                    fractionsAndthings.instructionsDialogue.text = fractionsAndthings.initialInstructions;
                }

                else if (mCurrent=="/")
                {
                    answerFraction = customMath.divFractions(fraction1, fraction2);
                    fractionsAndthings.aNumerator.text = answerFraction.x.ToString();
                    fractionsAndthings.aDenomonator.text = answerFraction.y.ToString();
                    fractionsAndthings.instructionsDialogue.text = fractionsAndthings.initialInstructions;

                }

                else if (mCurrent=="X")
                {
                    answerFraction = customMath.multFractions(fraction1, fraction2);
                    fractionsAndthings.aNumerator.text = answerFraction.x.ToString();
                    fractionsAndthings.aDenomonator.text = answerFraction.y.ToString();
                    fractionsAndthings.instructionsDialogue.text = fractionsAndthings.initialInstructions;
                }

                else
                {
                    fractionsAndthings.instructionsDialogue.text =("Please enter either '+', '-', 'X', or '/'");
                }
                            
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
            public InputField userOpperator;
            public InputField denomonatorA;
            public InputField denomonatorB;
            public Text aNumerator;
            public Text aDenomonator;
            public Text instructionsDialogue;
            [TextArea(100,200)]
            public string initialInstructions;

        }


}