using UnityEngine;

// A storm cloud! Steer around it!
// Flying into one slows you down and shakes your dragon.
public class StormCloud : MonoBehaviour
{
    [Header("How much it slows you (seconds)")]
    public float slowTime = 2f;

    void OnTriggerEnter(Collider other)
    {
        SkyFlight flyer = other.GetComponent<SkyFlight>();
        if (flyer != null)
        {
            Debug.Log("Oh no, a storm cloud! Shaky!");
            flyer.StartCoroutine(SlowDown(flyer));
        }
    }

    System.Collections.IEnumerator SlowDown(SkyFlight flyer)
    {
        float normal = flyer.forwardSpeed;
        flyer.forwardSpeed = normal * 0.4f;
        yield return new WaitForSeconds(slowTime);
        flyer.forwardSpeed = normal;
        Debug.Log("Phew! Out of the storm!");
    }
}
