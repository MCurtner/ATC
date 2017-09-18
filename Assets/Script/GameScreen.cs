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
}
