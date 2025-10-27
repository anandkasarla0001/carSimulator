using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // helps to work  on UI elements
using UnityEngine.SceneManagement; // helps  to  change  the scenes

public class carSelection : MonoBehaviour
{
    [Header("Buttons and Canvas")]
    public Button nextButton;
    public Button previousButton;


    [Header("Camers")]
    public GameObject cam1;
    public GameObject cam2;


    [Header("Buttons and Canvas")]
    public GameObject selectionCanvas;
    public GameObject skipButton;
    public GameObject PlayButton;
    private int currentCar;
    private GameObject[] carList;

    private void Awake()
    {
        selectionCanvas.SetActive(false);
        PlayButton.SetActive(false);
        cam2.SetActive(false);
        chooseCar(0);
    }
    private void Start()
    {
        currentCar = PlayerPrefs.GetInt("carselected");
        // feeding the  models to the carList
        carList = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }
        //helps to  keep the track of currentCar
        foreach (GameObject go in carList)
        {
            go.SetActive(false);
        }
        if (carList[currentCar])
        {
            carList[currentCar].SetActive(true);
        }
    }
    private void chooseCar(int index) // helps  to choose the car
    {
        previousButton.interactable = (currentCar  != 0);
        nextButton.interactable = (currentCar != transform.childCount - 1);

        for (int i =0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index); // helps to  select the car  index  number
        }
    }

     public void switchCar(int  switchCars)// helps  to switch between  different cars
    {
         currentCar +=switchCars; // it adds the next car index
        chooseCar(switchCars); // calling the choseCar functiona and  passing the index  to switchCar
    }

    public void playGame()
    {
        PlayerPrefs.SetInt("CarSelected", currentCar); //playerprefs is a class which stores the player info
        SceneManager.LoadScene("scene_day");
    }
    public void SkipButton()
    {
        selectionCanvas.SetActive(true);
        PlayButton.SetActive(true);
        skipButton.SetActive(false);
        cam1.SetActive(false);
        cam2.SetActive(true);
    }

}
