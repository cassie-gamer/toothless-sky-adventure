using UnityEngine;

// A glowing wind ring! Fly through it for a SPEED BOOST!
// Chain rings together to go super fast!
public class WindRing : MonoBehaviour
{
    [Header("Boost power")]
    public float boostAmount = 8f;
    [Header("How long the boost lasts (seconds)")]
    public float boostTime = 3f;

    void OnTriggerEnter(Collider other)
    {
        SkyFlight flyer = other.GetComponent<SkyFlight>();
        if (flyer != null)
        {
            Debug.Log("WIND RING! Speed boost!");
            flyer.StartCoroutine(Boost(flyer));
            gameObject.SetActive(false); // ring used up, respawns later
            Invoke("Respawn", 10f);
        }
    }

    System.Collections.IEnumerator Boost(SkyFlight flyer)
    {
        flyer.forwardSpeed += boostAmount;
        yield return new WaitForSeconds(boostTime);
        flyer.forwardSpeed -= boostAmount;
    }

    void Respawn()
    {
        gameObject.SetActive(true);
    }
}
