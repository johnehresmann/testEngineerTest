using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class linkedLists : MonoBehaviour
{
    public projectSetup projectInformation = new projectSetup();
     
   void Start()
   {
       int[] tempNumbersStored = projectInformation.arrayOfNumbers;
       LinkedList<int> tempListsofNumbers = new LinkedList<int>(tempNumbersStored);
       
       projectInformation.numbersWeHaveStored = tempListsofNumbers;
       
       projectInformation.linkedListDisplay.text = "";
       
   }

   void Update()
   {
       int integerForArray;

       int.TryParse(projectInformation.userInput.text, out integerForArray);

       if (Input.GetKeyDown("enter"))
       {
           Text displayedList = projectInformation.linkedListDisplay;
           InputField inputFromUser = projectInformation.userInput;

           addtoListandSort(integerForArray, projectInformation.numbersWeHaveStored , displayedList, inputFromUser);

       }

   }
   
   public void addtoListandSort(int integerToStore, LinkedList<int> lListofNumbers ,Text listDisplay, InputField userIn )
    {
        LinkedList<int> storedIntegers = new LinkedList<int>();
        
        

        storedIntegers.AddLast(integerToStore);
        Debug.ClearDeveloperConsole();
        Debug.Log(storedIntegers.Count);
        for (int p = 0; p <= storedIntegers.Count - 2; p++)
        {
            for (int i = 0; i <= storedIntegers.Count - 2; i++)
            {
                
            }
        }
           
    }

    [System.Serializable]
   public class projectSetup
   {
       public InputField userInput;
       public Text linkedListDisplay;
       public int[] arrayOfNumbers;
       public LinkedList<int> numbersWeHaveStored;

   }
}
