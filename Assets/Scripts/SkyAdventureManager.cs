using UnityEngine;
using UnityEngine.UI;

// The adventure! 5 islands, 5 lost eggs.
// Bring every egg home to the nest... then they ALL hatch!
public class SkyAdventureManager : MonoBehaviour
{
    [Header("Eggs to rescue")]
    public int totalEggs = 5;

    [Header("The home nest")]
    public Transform nest;

    [Header("Show progress here")]
    public Text progressText;

    [Header("Show this at the end")]
    public Text winText;

    private int eggsHome = 0;

    void Start()
    {
        Debug.Log("Toothless's Sky Adventure begins! Find 5 lost eggs!");
        UpdateUI();
    }

    // Call this when the dragon brings an egg to the nest
    public void EggDelivered(GameObject egg)
    {
        eggsHome++;
        Debug.Log("Egg " + eggsHome + "/" + totalEggs + " is home!");
        UpdateUI();

        if (eggsHome >= totalEggs)
        {
            HatchAll();
        }
    }

    void HatchAll()
    {
        Debug.Log("ALL 5 EGGS ARE HOME! They hatch! Baby dragons everywhere!");
        DragonEgg[] eggs = FindObjectsOfType<DragonEgg>();
        foreach (DragonEgg e in eggs) e.Hatch();

        if (winText) winText.text = "All 5 eggs hatched! You did it! THE END";
    }

    void UpdateUI()
    {
        if (progressText) progressText.text = "Eggs home: " + eggsHome + "/" + totalEggs;
    }
}
