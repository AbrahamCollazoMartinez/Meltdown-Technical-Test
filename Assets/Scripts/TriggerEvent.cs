using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{

    // Called when a game object enters the trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the other game object has the "Player" tag
        if (other.CompareTag("Player"))
        {

            GameManager_.Instance.EndGame(false);
        }
    }

}
