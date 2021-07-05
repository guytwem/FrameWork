using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    public int NumberOfObj = 10;
    public int ObjHeightMax = 10;
    public GameObject[] obj;

    private void Start()
    {
        InitializeRandom();
        SelectionSorter(obj);
    }

    void SelectionSorter(GameObject[] unsortedList)
    {
        int min;
        GameObject temp;
        Vector3 tempPosition;

        for (int i = 0; i < unsortedList.Length; i++)
        {
            min = i;

            for (int j = i + 1; j < unsortedList.Length; j++)
            {
                if (unsortedList[j].transform.localScale.y < unsortedList[min].transform.localScale.y)
                {
                    min = j;
                }
            }

            if (min != i)
            {
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


    void InitializeRandom()
    {
        obj = new GameObject[NumberOfObj];

        for (int i = 0; i < NumberOfObj; i++)
        {
            int randomNumber = Random.Range(1, ObjHeightMax + 1);

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube.transform.localScale = new Vector3(0.9f, randomNumber, 1);
            cube.transform.position = new Vector3(i, randomNumber / 2.0f, 0);

            cube.transform.parent = this.transform;

            obj[i] = cube;
        }
        transform.position = new Vector3(-NumberOfObj / 2f, -ObjHeightMax / 2.0f, 0);
    }
}
