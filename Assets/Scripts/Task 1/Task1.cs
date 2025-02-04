using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Napisz funkcje, ktora bedzie losowac n roznych elementow z danej kolekcji.
//List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//int[] intArray = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

//intList.GetRandomElements(2); < --zwroci kolekcje 2 roznych elementow z intList 
//intArray.GetRandomElements(5); < --zwroci kolekcje 5 roznych elementow z intArray 
public class Task1 : MonoBehaviour
{
    private List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private int[] intArray = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

    [SerializeField] private Text randomFromListToText;
    [SerializeField] private Text randomFromArreyToText;

    [SerializeField] private List<Button> buttons;

    private string randomFromListToString;
    private string randomFromArreyToString;
    private string arreyNumbers;
    private string listNumbers;

    private List<int> intListToCheck;
    private List<int> intArreyToCheck;

    private List<string> intListToString;
    private List<string> intArreyToString;

    private int randomizeIntFromList;
    private int randomizeIntFromArray;


    public void getRandomeElementsList()
    {
        intListToCheck = new List<int>();
        while (intListToCheck.Count < 2)
        {
            randomizeIntFromList = Random.Range(1, 11);
            if (intListToCheck.Count == 0)
            {
                intListToCheck.Add(randomizeIntFromList);
            }
            else if (!intListToCheck.Contains(randomizeIntFromList))
            {
                intListToCheck.Add(randomizeIntFromList);
            }
        }
        writeRandomeFromList();
    }

    public void getRandomeElementsArrey()
    {
        intArreyToCheck = new List<int>();
        while (intArreyToCheck.Count < 5)
        {
            randomizeIntFromArray = intArray[Random.Range(0, intArray.Length)];
            if (intArreyToCheck.Count == 0)
            {
                intArreyToCheck.Add(randomizeIntFromArray);
            }
            else if (!intArreyToCheck.Contains(randomizeIntFromArray))
            {
                intArreyToCheck.Add(randomizeIntFromArray);
            }
        }
        writeRandomeFromArrey();
    }

    public void doBoth()
    {
        buttons[2].image.sprite = buttons[2].spriteState.pressedSprite;
        getRandomeElementsList();
        getRandomeElementsArrey();
    }
    private void writeRandomeFromArrey()
    {
        arreyNumbers = "";
        for (int i = 0; i < intArreyToCheck.Count; i++)
        {
            if( i < intArreyToCheck.Count-1)
            arreyNumbers += intArreyToCheck[i] + ", ";
            else
                arreyNumbers += intArreyToCheck[i];
        }
        randomFromArreyToText.text = arreyNumbers; 
    }

    private void writeRandomeFromList()
    {
        listNumbers = "";
        for (int i = 0; i < intListToCheck.Count; i++)
        {
            if (i < intListToCheck.Count - 1)
                listNumbers += intListToCheck[i] + ", ";
            else
                listNumbers += intListToCheck[i];
        }
        randomFromListToText.text = listNumbers;
    }

    void Start()
    {
        intListToCheck = new List<int>();
        intArreyToCheck = new List<int>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            buttons[0].image.sprite = buttons[0].spriteState.pressedSprite;
            buttons[0].onClick.Invoke();
        }
        if(Input.GetKeyUp(KeyCode.L))
        {
            buttons[0].image.sprite = buttons[0].spriteState.selectedSprite;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            buttons[1].image.sprite = buttons[1].spriteState.pressedSprite;
            buttons[1].onClick.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            buttons[1].image.sprite = buttons[1].spriteState.selectedSprite;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            buttons[2].onClick.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            buttons[2].image.sprite = buttons[2].spriteState.selectedSprite;
        }
    }
}
