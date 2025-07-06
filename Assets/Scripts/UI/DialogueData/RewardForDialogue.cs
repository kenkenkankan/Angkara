using UnityEngine;

public class RewardForDialogue : MonoBehaviour
{
    [SerializeField] private ItemObject rewardItem; // Pakai ItemObject karena kamu juga pakai itu

    private bool rewardGiven = false;

    public void GiveReward()
    {
        if (rewardGiven)
        {
            Debug.Log("Reward sudah diberikan sebelumnya.");
            return;
        }

        if (rewardItem != null)
        {
            PlayerInventory.Instance.StoreItem(rewardItem); // Panggil StoreItem
            rewardGiven = true;
            Debug.Log("Reward diberikan: " + rewardItem.name);

            Destroy(gameObject); // Hapus objek ini setelah memberikan reward
        }
        else
        {
            Debug.LogWarning("Tidak ada reward item yang di-assign!");
        }
    }

    public void ResetReward()
    {
        rewardGiven = false; // Jika kamu mau bisa diulang
    }
}
