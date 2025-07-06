using UnityEngine;

public class DialogueTriggerZone : MonoBehaviour
{
    public DialogueObject dialogue; // <-- Drag ScriptableObject di inspector

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;
        if (other.CompareTag("Player"))
        {
            PlayerInput playerInput = other.GetComponent<PlayerInput>();
            Debug.Log("Player entered dialogue zone");
            if (playerInput != null && dialogue != null)
            {
                playerInput.DialogueUI.ShowDialogue(dialogue);
                hasTriggered = true;
            }
        }
    }
}
