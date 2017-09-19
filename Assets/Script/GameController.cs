using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameScreen screen;
    public Aircraft aircraft;
    public int spawnCount = 1;

    Aircraft selectedAircraft;

    /// <summary>
    /// Initialize any variables or game state before the game starts.
    /// </summary>
    void Awake()
    {
        // Check if there is a gamecontroller
        if (instance == null)
        {
            // Set this instance to be the gamecontroller
            instance = this;
        }
        else if (instance != this)
        {
            // Destroy duplicate
            Destroy(gameObject);
        }
    }

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
        // Instantiates a new Aircraft object at a random point on screen.
        // Add the returned aircraft to the list.
        //aircraftList.Add(aircraft.InstatiateAircraft());
        aircraft.InstatiateAircraft();
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

                // Set the aircraft as the currentAircraft
                selectedAircraft = hit.transform.GetComponent<Aircraft>();

                // Display the information on screen
                DisplayAircraftInformationOnScreen(selectedAircraft);

            }
        }
    }

    /// <summary>
    /// Displays the aircraft information on screen.
    /// </summary>
    /// <param name="hit">Hit information from Raycast2D.</param>
    void DisplayAircraftInformationOnScreen(Aircraft arc)
    {
        // Retrieve and store the FL and Speed values.
        TextMesh[] textArray = arc.GetComponentsInChildren<TextMesh>();

        // Set the information on screen.
        screen.SetScreenARCID(arc.transform.name);
        screen.SetScreenFL(textArray[0].text);
        screen.SetScreenSpeed(textArray[1].text);
    }

    public void OnAscendClick()
    {
        Debug.Log("Ascend Button Clicked.");
    }

    public void OnDescendClick()
    {
        Debug.Log("Descend Button Clicked.");
    }

    /// <summary>
    /// Destroys the aircraft.
    /// </summary>
    void DestroyAircraft()
    {
        // Only destroy the aircraft if there are aircraft to destroy.
        if (selectedAircraft != null)
        {
            selectedAircraft.RemoveAircraft();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Aircraft")
        {
            Debug.Log(collision.ToString());
        }


        Debug.Log(collision.ToString());
    }

}

