using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class happinessbar : MonoBehaviour {

    public Image bar;
    public float var;
    private float vel;
    public Color enabled, disabled, lowColor, fullColor;
    Vector3 startscale,bigscale;
    public Text txt;

    public enum happiness
    {
        happy,
        neutral,
        bored
    };

    public Image[] happinesssprites;

    happiness Happiness;

    // Use this for initialization
    void Start() {
        bar.fillAmount = .52f;
        happinesssprites[0].color = disabled;
        happinesssprites[2].color = disabled;
        Happiness = happiness.happy;
        startscale = happinesssprites[1].transform.localScale;
        bigscale = happinesssprites[1].transform.localScale * 1.25f;
        happinesssprites[1].transform.localScale = bigscale;
    }

    // Update is called once per frame
    void Update()
    {
        if (bar.fillAmount <= 0)
        {
            //Game Over
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            var += .1f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            var -= .1f;
        }

        if (bar.fillAmount != var)
        {
            float tempvar = Mathf.SmoothDamp(bar.fillAmount, var, ref vel, Time.deltaTime * 40);
            txt.text = (((int)(tempvar*100)).ToString()+"%");
            int oldval = (int)(bar.fillAmount * 100);

            if ((int)(var * 100)<oldval)
            {
                if (oldval <= 30)
                {
                    if (Happiness != happiness.bored)
                    {
                        Happiness = happiness.bored;
                        switchHappiness(1, 0);
                    }
                }else if (oldval > 30 && oldval<70)
                {
                    if (Happiness != happiness.neutral)
                    {
                        Happiness = happiness.neutral;
                        switchHappiness(2, 1);
                    }
                }
            }
            else
            {
                if (oldval >= 70)
                {
                    if (Happiness != happiness.happy)
                    {
                        Happiness = happiness.happy;
                        switchHappiness(1, 2);
                    }
                }
                else if (oldval > 30 && oldval < 70)
                {
                    if (Happiness != happiness.neutral)
                    {
                        Happiness = happiness.neutral;
                        switchHappiness(0, 1);
                    }
                }
            }
        }

        bar.color = Color.Lerp(lowColor, fullColor, bar.fillAmount);
        bar.fillAmount = Mathf.SmoothDamp(bar.fillAmount, (float)var, ref vel, Time.deltaTime * 40);
    }

    private void switchHappiness(int i, int j)
    {
        happinesssprites[i].transform.localScale = Vector3.Lerp(startscale, bigscale, Time.deltaTime * 10f);
        happinesssprites[i].color = disabled;
        happinesssprites[j].transform.localScale = Vector3.Lerp(bigscale, startscale, Time.deltaTime * 10f);
        happinesssprites[j].color = enabled;
    }



    
}
