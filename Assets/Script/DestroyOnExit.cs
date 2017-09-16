using UnityEngine;

public class DestroyOnExit : MonoBehaviour
{
    /// <summary>
    /// Check if the game object is no longer visible on any camera.
    /// </summary>
    void OnBecameInvisible()
    {
        // Destroy the game object
        Destroy(GetComponent<Renderer>().transform.root.gameObject);
    }
}
