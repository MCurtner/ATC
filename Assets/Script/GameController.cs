using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Aircraft aircraft;

    public int spawnCount = 1;

    public Text arcidText;
    public Text arcFL;
    public Text arcSpeed;


    List<Aircraft> aircraftList = new List<Aircraft>();

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {
        // Spawn the specified number of aircraft.
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnAircraft();
        }

    }

    /// <summary>
    /// Spawns the aircraft.
    /// </summary>
    void SpawnAircraft()
    {
        // Set the intial coarse of the Aircraft.
        aircraft.moveBy = new Vector2(1, 1);

        // Instantiate a new Aircraft object at a random point on screen.
        Aircraft clone = Instantiate(aircraft, RandomStartingPoint(), Quaternion.identity);

        // Add the clone to the list.
        aircraftList.Add(clone);
    }

    /// <summary>
    /// Generate a random starting point for the aircraft object.
    /// </summary>
    /// <returns>Random Vector3 starting point.</returns>
    Vector3 RandomStartingPoint()
    {
        int randomInt = Random.Range(0, 4);
        Vector3 pos = new Vector3();

        /* Use for setring starting point outside of screen
        switch (randomInt)
        {
            case 0:
                pos = new Vector3(Random.Range(-12, 12), -12);
                break;
            case 1:
                pos = new Vector3(Random.Range(-12, 12), 12);
                break;
            case 2:
                pos = new Vector3(-15, Random.Range(-12, 12));
                break;
            case 3:
                pos = new Vector3(15, Random.Range(-12, 12));
                break;
        }
        */

        // Set the position anywhere within the screen boundaries
        pos = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10));

        return pos;
    }

    void FixedUpdate()
    {
        SelectAircraftOnScreen();
    }

    /// <summary>
    /// Selects the aircraft on screen.
    /// </summary>
    void SelectAircraftOnScreen()
    {
        // Left mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            // Find the origin of the mouse click position
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            // Send a raycast to the point of origin 
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);

            // If hit was detected then display the aircrafts name
            // and set a new position.
            if (hit)
            {
                Debug.Log(hit.transform.gameObject.name);
                Vector3 temp = new Vector3(7.0f, 7.0f, 0);

                //hit.transform.position += temp;

                DisplayAircraftInformationOnScreen(hit);
            }
        }
    }

    /// <summary>
    /// Displays the aircraft information on screen.
    /// </summary>
    /// <param name="hit">Hit information from Raycast2D.</param>
    void DisplayAircraftInformationOnScreen(RaycastHit2D hit)
    {
        // Retrieve and store the FL and Speed values.
        TextMesh[] textArray = hit.transform.gameObject.GetComponentsInChildren<TextMesh>();

        // Display the values on screen
        arcidText.text = hit.transform.gameObject.name;
        arcFL.text = textArray[0].text;
        arcSpeed.text = textArray[1].text;
    }
}

