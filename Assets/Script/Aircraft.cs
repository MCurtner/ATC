using UnityEngine;

public class Aircraft : MonoBehaviour
{
    public Vector2 moveBy;
    TextMesh[] textArray;

    /// <summary>
    /// Initialize the Aircraft with repeating speed
    /// </summary>
    void Start()
    {
        // Set the aircraft's name
        GetComponent<Aircraft>().name = RandomeName();
        textArray = GetComponentsInChildren<TextMesh>();
        textArray[0].text = RandomFL();
        textArray[1].text = RandomSpeed();

        InvokeRepeating("MoveAircraft", 0, 2);
    }

    /// <summary>
    /// Instatiates the aircraft gameobject.
    /// </summary>
    /// <returns>The aircraft object.</returns>
    public Aircraft InstatiateAircraft()
    {
        return Instantiate(GetComponent<Aircraft>(), RandomStartingPoint(), Quaternion.identity);
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

    /// <summary>
    /// Set the initial position and direction of the Aircraft object.
    /// </summary>
    void MoveAircraft()
    {
        Vector3 currentPosition = transform.position;
        Vector3 moveTo = new Vector3(currentPosition.x + moveBy.x,
                                     currentPosition.y + moveBy.y, 0);
    }

    /// <summary>
    /// Creates a random name.
    /// </summary>
    /// <returns>Random name.</returns>
    string RandomeName()
    {
        return "DLT" + Random.Range(0, 50).ToString();
    }

    string RandomFL()
    {
        return Random.Range(100, 999).ToString();
    }

    string RandomSpeed()
    {
        return Random.Range(100, 600).ToString();
    }
}
