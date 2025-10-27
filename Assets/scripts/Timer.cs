using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    public float countDownTimer = 3f;

    [Header("Things to stop")]
    public playerCarControl PlayeyrCarControl;
    public playerCarControl PlayeyrCarControl1; // used for spawning the car  
    public playerCarControl PlayeyrCarControl2;
    public opponentCar OpponentCar0;
    public opponentCar OpponentCar1;
    public opponentCar OpponentCar2;
    public opponentCar OpponentCar3;
    //public opponentCar OpponentCar0;

    public Text countDownText;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeCount()); // calling the IEnums method
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countDownTimer > 1) // helps to stop the opponent car
        {
            PlayeyrCarControl.AccelerationForce = 0f;
            PlayeyrCarControl1.AccelerationForce = 0f;
            PlayeyrCarControl2.AccelerationForce = 0f;// used to stop the second car
            OpponentCar0.movingSpeed = 0f;
            OpponentCar1.movingSpeed = 0f;
            OpponentCar2.movingSpeed = 0f;
            OpponentCar3.movingSpeed = 0f;
        }
        else if(countDownTimer == 0)
        {
            PlayeyrCarControl.AccelerationForce = 300f;
            PlayeyrCarControl1.AccelerationForce = 300f;
            PlayeyrCarControl2.AccelerationForce = 300f;
            OpponentCar0.movingSpeed = 10f;
            OpponentCar1.movingSpeed = 12f;
            OpponentCar2.movingSpeed = 14f;
            OpponentCar3.movingSpeed = 8f;

        }
        
    }
    IEnumerator TimeCount()
    {
        while (countDownTimer > 0)
        {
            countDownText.text = countDownTimer.ToString();
            yield return new WaitForSeconds(1f); // yield return ==“pause this function here, then come back after some condition or time.”
            //new WaitForSeconds(1f) == Wait for 1 second of real time before continuing.”
            countDownTimer--;
        }
        countDownText.text = "GO";
        yield return new WaitForSeconds(1f);
        countDownText.gameObject.SetActive(false); // helps  to  remove  the timer

    }
}
