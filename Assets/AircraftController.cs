using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AircraftController : MonoBehaviour
{

    float circleRadius;

    float circleSpeed;

    float circleAngle;

    float selfRotationSpeed;

    Vector3 lastDirection;

    float speed = 1.0f;

    public Rigidbody rb;

    public int overlap = 0;

    public int laps = 2;

    public float timer = 15;

    public Text WinText;

    public Text TimeText;

    public Text WinLose;

    public float spcontrol;

    private GameObject gameController;

    void Start()
    {

        WinText.text = "Laps Remaining: " + laps.ToString();

        TimeText.text = "Time remaining: " + timer.ToString();

        WinLose.text = "";

        rb = GetComponent<Rigidbody>();

        circleRadius = 10;

        circleSpeed = 0.5f;

        circleAngle = 0;

        selfRotationSpeed = 100;

        lastDirection = new Vector3(1, 0, 0);

        lastDirection.Normalize();

    }

    void Update()
    {
        gameController = GameObject.Find("Spotlight");

        SpotlightController controllerscript = (SpotlightController)gameController.GetComponent("SpotlightController");

        timer -= Time.deltaTime;

        WinText.text = "Laps Remaining: " + laps.ToString();

        TimeText.text = "Time: " + timer.ToString();

        if(timer <= 0)
        {
            WinLose.text = "You Lose!";
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown("f"))
        {
            if (speed < 2)
            {
                speed = speed + 0.5f;
            }
        }

        if (Input.GetKeyDown("r"))
        {
            if (speed > 0.5)
            {
                speed = speed - 0.5f;
            }
        }

        if (Input.GetKey("up"))
        {
            if (overlap == 0)
            {
                spcontrol = -speed * Time.deltaTime;

                spcontrol = (spcontrol + 360) % 360;

                circleAngle += speed * circleSpeed * Time.deltaTime;

                circleAngle = (circleAngle + 360) % 360;

                float newPositionX = circleRadius * (float)Mathf.Cos(circleAngle);

                float newPositionZ = circleRadius * (float)Mathf.Sin(circleAngle);

                Vector3 newPosition = new Vector3(newPositionX, transform.position.y, newPositionZ);

                Vector3 newDirection = newPosition - transform.position;

                newDirection.Normalize();

                float rotationAngle = -Vector3.Angle(lastDirection, newDirection);

                gameController.transform.Rotate(Vector3.up, rotationAngle , Space.World);

                transform.Rotate(Vector3.up, rotationAngle, Space.World);

                transform.position = newPosition;

                lastDirection = newDirection;
            }
        }

        if (Input.GetKey("right"))
        {
            transform.Rotate(Vector3.forward, selfRotationSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.back, selfRotationSpeed * Time.deltaTime, Space.Self);
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Frame"))
        {
            overlap = 1;
        }

        if (other.gameObject.CompareTag("Invisibletrigger"))
        {
            overlap = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("lapcomplete"))
        {
            if (laps >= 0)
            {
                laps--;
            }

            if (laps < 0)
            {
                WinLose.text = "You Win!";
                gameObject.SetActive(false);
            }

            if (laps == 1)
            {
                timer = 12;
            }

            if(laps == 0)
            {
                timer = 9;
            }

        }
    }

}