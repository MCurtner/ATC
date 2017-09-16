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
