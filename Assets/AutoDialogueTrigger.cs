using System.Collections;
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
                DialogueManager.Instance.StartDialogue(dialogue);
                hasTriggered = true;
                Debug.Log("Auto-dialogue triggered with " + dialogue.dialogueLines.Count + " lines.");
            }
        }
    }

}
