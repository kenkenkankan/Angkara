using UnityEngine;

public class LanternArea : MonoBehaviour
{
    private SanityUIManager sanityUI;

    private void Start()
    {
        sanityUI = FindObjectOfType<SanityUIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sanityUI?.StartSanityRegen();
            Debug.Log("Player entered Lantern Area, starting sanity regen.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sanityUI?.StopSanityRegen();
            Debug.Log("Player left Lantern Area, stopping sanity regen.");
        }
    }
}
