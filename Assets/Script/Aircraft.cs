using UnityEngine;

public class Aircraft : MonoBehaviour
{
    public Vector2 moveBy;

    /// <summary>
    /// Initialize the Aircraft with repeating speed
    /// </summary>
    void Start()
    {
        // Set the aircraft's name
        GetComponent<Aircraft>().name = RandomeName();

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
}
