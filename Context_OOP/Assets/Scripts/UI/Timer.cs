using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject player;
    public GameObject bill;
    public Renderer greenBill;
    public Renderer redBill;

    public Text paymentText;
    public Text budgetText;
    public Text moneyLeftText;
    public Text happinessText;


    private float timeLeft = 120;
    private float happiness;
    private float payment;
    private int budget = 50;


    void Update()
    {
        happiness = player.GetComponent<CharController>().happiness;
        payment = Mathf.RoundToInt(player.GetComponent<CharController>().payment);
        timeLeft -= Time.deltaTime;

        paymentText.text = ("€" + payment.ToString() + ",-");
        budgetText.text = ("€" + budget.ToString() + ",-");
        moneyLeftText.text = ("€" + (budget - payment).ToString() + ",-");

        

        if (timeLeft < 0) {
            Time.timeScale = 0;
            bill.SetActive(true);
            if (payment < (budget - budget)) {
                redBill.enabled = true;
            }
            else {
                greenBill.enabled = true;
            }
        }
    }
    public void newGame(string Menu) {
        SceneManager.LoadScene(Menu);
    }
    public void quitGame() {
        Application.Quit();
    }
}


