using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem.SelectionSort
{
    /// <summary>
    /// Creates cubes and then moves them based on size.
    /// </summary>
   public class SelectionSort : MonoBehaviour
   {
       public int NumberOfObj = 10; // how many things are being sorted
       public int ObjHeightMax = 10; // max height the obj will be
       public GameObject[] obj; // reference to the list of obj
   
       private void Start()
       {
           InitializeRandom(); // execute randomisation
           StartCoroutine(SelectionSorter(obj)); 
       }
        
       /// <summary>
       /// sorts through the randomised cubes and organises based on height.
       /// </summary>
       /// <param name="unsortedList"></param>
       IEnumerator SelectionSorter(GameObject[] unsortedList)
       {
           int min; // smallest number in the index
           GameObject temp; // temporary swapping place
           Vector3 tempPosition;
   
           for (int i = 0; i < unsortedList.Length; i++) // looping through list of objects
           {
               min = i; // sets the minimum obj to i incase its the first obj.
               yield return new WaitForSeconds(1f);
   
               for (int j = i + 1; j < unsortedList.Length; j++) // checks the next objects height.
               {
                   if (unsortedList[j].transform.localScale.y < unsortedList[min].transform.localScale.y)
                   {
                       min = j; // if the next object is smaller than the min then this becomes the new min.
                       
                   }
               }
   
               if (min != i) //if object height is lower than the minimum move it to the front.
               {
                   //swapping obj around so min is in right spot.
                   temp = unsortedList[i]; 
                   unsortedList[i] = unsortedList[min]; 
                   unsortedList[min] = temp; 
   
                   tempPosition = unsortedList[i].transform.localPosition;
   
                   unsortedList[i].transform.localPosition = 
                       new Vector3(unsortedList[min].transform.localPosition.x, tempPosition.y, tempPosition.z);
                   
                   
                   
                   unsortedList[min].transform.localPosition = 
                       new Vector3(tempPosition.x, unsortedList[min].transform.localPosition.y, unsortedList[min].transform.localPosition.z);
   
               }
           }
       }
   
        /// <summary>
        /// spawns cubes and randomises their position and height
        /// </summary>
       void InitializeRandom()
       {
           obj = new GameObject[NumberOfObj];
   
           for (int i = 0; i < NumberOfObj; i++) // loop through objects
           {
               int randomNumber = Random.Range(1, ObjHeightMax + 1); // gets random height
   
               GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); // creates a cube object
                
               //randomises the cube height and position
               cube.transform.localScale = new Vector3(0.9f, randomNumber, 1);
               cube.transform.position = new Vector3(i, randomNumber / 2.0f, 0);
   
               cube.transform.parent = this.transform;
   
               obj[i] = cube;
           }
           transform.position = new Vector3(-NumberOfObj / 2f, -ObjHeightMax / 2.0f, 0);
       }
   } 
}

