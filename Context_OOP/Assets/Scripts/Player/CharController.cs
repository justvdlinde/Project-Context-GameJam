using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour {
    private SpriteRenderer SR;

    public float speed;
    private bool isGrounded = true;
    private int stairs = 0;

    private bool inLiv;
    private bool inBed;
    private bool inBat;
    private bool inKit;

    public Texture2D c1;
    public Texture2D c2;

    public DrunkGuy1 guy1;
    public DrunkGuy2 guy2;
    public DrunkGuy3 guy3;

    public int happiness;
    public float payment;
    public double payment_double;
    public int location;
    public Text happinessText;
    public Text paymentText;
    public Scrollbar happinessBar;
    public Scrollbar paymentBar;
    public Gradient_Test G1;
    public Gradient_Test G2;

    public Renderer TV;
    public Renderer Microwave;
    public Renderer Charger;
    public Renderer Computer;
    public Renderer Discoball;
    public Renderer Radio;

    public Renderer livLight;
    public Renderer kitLight;
    public Renderer bedLight;
    public Renderer bathLight;


    // Use this for initialization
    void Start() {
        happiness = 10;
        payment = 0;

        happinessBar.size = 0.5f;
        paymentBar.size = 0;

        happinessText.text = happiness.ToString();

        InvokeRepeating("CallPayment", 1.0f, 1.0f);

        SR = GetComponent<SpriteRenderer>();

        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        CallHappiness();
        
        if (Input.GetMouseButtonDown(0)) {
            CastRay();
        }

        if (Input.GetKey(KeyCode.A) && stairs != 2) {
            transform.position += Vector3.left * Time.deltaTime * 4;
            SR.flipX = false;

            Vector3 currentPosition = this.transform.position;
            if (currentPosition[0] > -6.78f && currentPosition[0] < -6.37f) stairs = 1;
            else if (currentPosition[0] > -13.36f && currentPosition[0] < -12.61f) stairs = 1;
            else if (currentPosition[0] < -13.90f && currentPosition[1] == -5.9f) {
                currentPosition[0] = -13.90f;
                transform.position = currentPosition;
            }
            else if (currentPosition[0] < -13.90f && currentPosition[1] == 1.7f) {
                currentPosition[0] = -13.90f;
                transform.position = currentPosition;
            }
            else stairs = 0;
        }
        if (Input.GetKey(KeyCode.D) && stairs != 2) {
            transform.position += Vector3.right * Time.deltaTime * 4;
            SR.flipX = true;

            Vector3 currentPosition = this.transform.position;
            if (currentPosition[0] > -6.78f && currentPosition[0] < -6.37f) stairs = 1;
            else if (currentPosition[0] > -13.36f && currentPosition[0] < -12.61f) stairs = 1;
            else if (currentPosition[0] > 16.20f && currentPosition[1] == -5.9f) {
                currentPosition[0] = 16.20f;
                transform.position = currentPosition;
            }
            else if (currentPosition[0] > -5.60f && currentPosition[1] == 1.7f) {
                currentPosition[0] = -5.60f;
                transform.position = currentPosition;
            }
            else stairs = 0;

        }

        if (Input.GetKey(KeyCode.W) && stairs != 0) {
            Vector3 currentPosition = this.transform.position;
            if (currentPosition[1] >= -5.9f && currentPosition[1] < 1.7f) {
                transform.position += Vector3.up * Time.deltaTime * 4;
                if ((transform.position)[1] > 1.7f) {
                    currentPosition[1] = 1.7f;
                    transform.position = currentPosition;
                }
                stairs = 2;
            }
            else {
                stairs = 1;
            }
        }

        if (Input.GetKey(KeyCode.S) && stairs != 0) {
            Vector3 currentPosition = this.transform.position;
            if (currentPosition[1] > -5.9f && currentPosition[1] <= 1.7f) {
                transform.position += Vector3.down * Time.deltaTime * 4;
                if ((transform.position)[1] < -5.9f) {
                    currentPosition[1] = -5.9f;
                    transform.position = currentPosition;
                }
                stairs = 2;
            }
            else {
                stairs = 1;
            }
        }
    }

    public void CallHappiness() {
        int totalH = 10;
        totalH += GuyHappiness(guy1.location);
        totalH += GuyHappiness(guy2.location);
        totalH += GuyHappiness(guy3.location);
        happiness = totalH;
        happinessText.text = happiness.ToString();
        happinessBar.size = (float)totalH / 19;
        G1.t = (float)totalH / 19;
    }
    int GuyHappiness(int i) {
        int score = 0;
        switch (i) {
            case 0: //bathroom
                if (bathLight.enabled == true) score++; else score--;
                if (Radio.enabled == true) score++; else score--;
                break;

            case 1: //bedroom
                if (bedLight.enabled == true) score++; else score--;
                if (Charger.enabled == true) score++; else score--;
                if (Computer.enabled == true) score++; else score--;
                break;

            case 2: //kitchen
                if (kitLight.enabled == true) score++; else score--;
                if (Microwave.enabled == true) score++; else score--;
                break;

            case 3: //living room
                if (livLight.enabled == true) score++; else score--;
                if (Discoball.enabled == true) score++; else score--;
                if (TV.enabled == true) score++; else score--;
                break;
        }
        return score;
    }

    void CallPayment() {
        if (TV.enabled == true) payment += 0.03f;
        if (Microwave.enabled == true) payment += 0.19f;
        if (Charger.enabled == true) payment += 0.32f;
        if (Computer.enabled == true) payment += 0.08f;
        if (Discoball.enabled == true) payment += 0.02f;
        if (Radio.enabled == true) payment += 0.07f;
        if (livLight.enabled == true) payment += 0.01f;
        if (kitLight.enabled == true) payment += 0.01f;
        if (bedLight.enabled == true) payment += 0.01f;
        if (bathLight.enabled == true) payment += 0.01f;

        payment_double = System.Math.Round(payment, 2);
        paymentText.text = (payment_double + 10).ToString();
        paymentBar.size = (float)payment_double / 30;
        G2.t = (float)payment_double / 30;
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (hit.collider.gameObject.name == "KitchenLight" && inKit) {
                kitLight.enabled = false;
                bathLight.GetComponent<AudioSource>().clip = GetComponent<AudioManager>().GetClip(6);
                bathLight.GetComponent<AudioSource>().Play();
            }
            if (hit.collider.gameObject.name == "BedroomLight" && inBed) {
                bedLight.enabled = false;
                bathLight.GetComponent<AudioSource>().clip = GetComponent<AudioManager>().GetClip(6);
                bathLight.GetComponent<AudioSource>().Play();
            }
            if (hit.collider.gameObject.name == "BathroomLight" && inBat) {
                bathLight.enabled = false;
                bathLight.GetComponent<AudioSource>().clip = GetComponent<AudioManager>().GetClip(6);
                bathLight.GetComponent<AudioSource>().Play();
            }
            if (hit.collider.gameObject.name == "LivingroomLight" && inLiv) {
                livLight.enabled = false;
                bathLight.GetComponent<AudioSource>().clip = GetComponent<AudioManager>().GetClip(6);
                bathLight.GetComponent<AudioSource>().Play();
            }
            if (hit.collider.gameObject.name == "Discoball" && inLiv) {
                Discoball.enabled = false;
                Discoball.GetComponent<AudioSource>().clip = GetComponent<AudioManager>().GetClip(2);
                Discoball.GetComponent<AudioSource>().Play();
            }
            if (hit.collider.gameObject.name == "Computer" && inBed) {
                Computer.enabled = false;
                Computer.GetComponent<AudioSource>().Play();
            }
            if (hit.collider.gameObject.name == "Charger" && inBed) {
                Charger.enabled = false;
                Charger.GetComponent<AudioSource>().clip = GetComponent<AudioManager>().GetClip(0);
                Charger.GetComponent<AudioSource>().Play();
            }
            if (hit.collider.gameObject.name == "Microwave" && inKit) {
                Microwave.enabled = false;
                Microwave.GetComponent<AudioSource>().clip = GetComponent<AudioManager>().GetClip(7);
                Microwave.GetComponent<AudioSource>().Play();
            }
            if (hit.collider.gameObject.name == "Radio" && inBat) {
                Radio.enabled = false;
                Radio.GetComponent<AudioSource>().Play();
            }
            if (hit.collider.gameObject.name == "TV" && inLiv) {
                TV.enabled = false;
                TV.GetComponent<AudioSource>().Play();
            }
            if (hit.collider.gameObject.name == "Microwave") {
                print("yep");
            }
        }
    }

    private void OnCollisionStay(Collision collision) {
        isGrounded = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Bathroom") {
            inBat = true;
            inLiv = false;
            inBed = false;
            inKit = false;
        }
        if (col.gameObject.name == "Bedroom") {
            inBed = true;
            inKit = false;
            inBat = false;
            inLiv = false;

        }
        if (col.gameObject.name == "Kitchen") {
            inKit = true;
            inLiv = false;
            inBed = false;
            inBat = false;
        }
        if (col.gameObject.name == "Living Room") {
            inLiv = true;
            inBed = false;
            inKit = false;
            inBat = false;
        }
    }
}