using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneybar : MonoBehaviour {

    public Image bar;
    public GameObject player;
    private float payment;
    public float var;
    public float budget;
    private float vel;
    public Color lowColor, fullColor;
    public Text txt;
   
    public Image[] moneySprites;
   
    public enum money {
        low,
        medium,
        high
    };

    money Money;

    // Use this for initialization
    void Start() {
        Money = money.high;
        payment = Mathf.RoundToInt(player.GetComponent<CharController>().payment);
    }

    // Update is called once per frame
    void Update()
    {
        if (bar.fillAmount <= 0) {
            //Game Over
        }

        var -= Time.deltaTime/6;

        if (bar.fillAmount != (var/100))
        {
            txt.text = ("€"+(((float)((int)(var*100)))/100).ToString());
            int oldval = (int)(bar.fillAmount * 100);

            if ((var/budget*100)<oldval) {
                if (oldval <= 30) {
                    if (Money != money.low) {
                        Money = money.low;
                        moneySprites[0].enabled = true;
                        moneySprites[1].enabled = false;
                    }
                    
                }else if (oldval > 30 && oldval <70) {
                    if (Money != money.medium) {
                        Money = money.medium;
                        moneySprites[1].enabled = true;
                        moneySprites[2].enabled = false;
                    }
                }
            }
            else {
                if (oldval >= 70) {
                    if (Money != money.high) {
                        Money = money.high;
                        moneySprites[1].enabled = false;
                        moneySprites[2].enabled = true;
                    }  
                }
                else if (oldval > 30 && oldval < 70) {
                    if (Money != money.medium) {
                        Money = money.medium;
                        moneySprites[1].enabled = true;
                        moneySprites[2].enabled = false;
                    }
                }
            }
        }

        bar.color = Color.Lerp(lowColor, fullColor, bar.fillAmount);
        bar.fillAmount = var/budget;
    }

}
