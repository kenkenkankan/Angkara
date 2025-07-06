using UnityEngine;

public class GhostAffectSanityUI : MonoBehaviour
{
    public float detectRadius = 5f;
    public float sanityDrainRate = 10f; // per detik

    private Transform player;
    private SanityUIManager sanityUI;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        sanityUI = FindObjectOfType<SanityUIManager>();
    }

    private void Update()
    {
        if (player == null || sanityUI == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectRadius)
        {
            float newSanity = Mathf.Max(0, sanityUI.sanityVal - sanityDrainRate * Time.deltaTime);
            sanityUI.sanityVal = newSanity;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
