using UnityEngine;

// A floating sky island! Each island hides ONE lost dragon egg.
// Land on the island (or fly close) to grab its egg.
public class SkyIsland : MonoBehaviour
{
    [Header("Which island is this? (1-5)")]
    public int islandNumber = 1;

    [Header("The lost egg on this island")]
    public GameObject lostEgg;

    [Header("Has its egg been rescued?")]
    public bool eggRescued = false;

    void Start()
    {
        Debug.Log("Island " + islandNumber + " floats in the sky... a lost egg waits here!");
    }

    void OnTriggerEnter(Collider other)
    {
        SkyFlight flyer = other.GetComponent<SkyFlight>();
        if (flyer != null && !eggRescued && !flyer.carryingEgg && lostEgg != null)
        {
            eggRescued = true;
            flyer.PickUpEgg(lostEgg);
            Debug.Log("Rescued the egg from island " + islandNumber + "!");
        }
    }
}
