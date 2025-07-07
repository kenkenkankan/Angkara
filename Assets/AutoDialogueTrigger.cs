using UnityEngine;

public class AutoDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            if (!DialogueManager.Instance.isDialogueActive)
            {
                hasTriggered = true;
                DialogueManager.Instance.StartDialogue(dialogue);
            }
        }
    }
}