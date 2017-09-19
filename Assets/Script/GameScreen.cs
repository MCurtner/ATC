using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    public GameScreen gameScreen;

    // GUI Elements
    public Text arcid;
    public Text speed;
    public Text flightLevel;

    public Button upButton;
    public Button downButton;

    void Awake()
    {
        // Check if there is a gamecontroller
        if (gameScreen == null)
        {
            // Set this instance to be the gamecontroller
            gameScreen = this;
        }
        else if (gameScreen != this)
        {
            // Destroy duplicate
            Destroy(gameObject);
        }
    }

    // Setter for Aircraft ID Text
    public void SetScreenARCID(string arcid)
    {
        this.arcid.text = arcid;
    }

    // Setter for Aircraft FL Text
    public void SetScreenFL(string flightLevel)
    {
        this.flightLevel.text = flightLevel;
    }

    // Setter for Aircraft Speed Text
    public void SetScreenSpeed(string speed)
    {
        this.speed.text = speed;
    }
}
