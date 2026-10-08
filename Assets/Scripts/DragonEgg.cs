using UnityEngine;

// A lost dragon egg! Carry it home to the nest.
// When all 5 eggs are home... they HATCH!
public class DragonEgg : MonoBehaviour
{
    [Header("Has this egg hatched?")]
    public bool hatched = false;

    public void Hatch()
    {
        hatched = true;
        Debug.Log("A baby dragon hatches! So cute!");
        // Swap the egg model for a baby dragon here!
    }
}
