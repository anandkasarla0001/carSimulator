using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class finish : MonoBehaviour
{
    [Header("Finish UI variable")]
    public GameObject finishUI;
    public GameObject playerUI;
    public GameObject playerCar;

    [Header("WIN / LOOSE STATUS")]
    public Text status;

    private void Start()
    {
        StartCoroutine(waitForTheFinishUI());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(finishZoneTimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;
            status.text = "YOU WIN";
            status.color = Color.red;
        }
        else if(other.gameObject.tag == "opponentCar")
        {
            StartCoroutine(finishZoneTimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;
            status.text = "YOU LOOSE";
            status.color = Color.red;

        }
    }

    IEnumerator waitForTheFinishUI()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(25f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    IEnumerator finishZoneTimer()
    {
        finishUI.SetActive(true);
        playerUI.SetActive(false);
        playerCar.SetActive(false);

        yield return new WaitForSeconds(5f);
        Time.timeScale = 0f;
    }

}
