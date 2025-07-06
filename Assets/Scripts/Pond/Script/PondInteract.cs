using UnityEngine;

public class PondInteraction : MonoBehaviour, IInteractable
{
    public GameObject pondUI;
    public GameObject confirmNotif;

    public float interactRange = 2f;

    public Vector2 InitPosition => transform.position;
    public GameObject ConfirmNotif => confirmNotif;

    public void Interact(PlayerInput player = null)
    {
        ActivatePondGrid();
    }

    void ActivatePondGrid()
    {
        if (pondUI != null)
        {
            pondUI.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Pond minigame activated");
        }

        if (confirmNotif != null)
            confirmNotif.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            Debug.Log("Player near pond");

            // Daftarkan ke PlayerInput agar bisa dipanggil saat tekan E
            player.GetComponent<PlayerInput>().Interactable = this;

            confirmNotif?.SetActive(true);
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            Debug.Log("Player left pond");

            // Hapus referensi
            player.GetComponent<PlayerInput>().Interactable = null;

            confirmNotif?.SetActive(false);
        }
    }
}
