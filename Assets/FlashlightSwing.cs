using UnityEngine;

public class FlashlightSwing : MonoBehaviour
{
    [SerializeField] private float offsetMovingX = 3.2f;
    [SerializeField] private float offsetIdleX = 0.3f;

    [SerializeField] private float offsetMovingY = -0.2f;
    [SerializeField] private float offsetIdleY = 2.67f;

    [SerializeField] private Animator playerAnimator;
    private Transform player;

    private int lastDirection = 1; // 1 = kanan, -1 = kiri
    private bool isMoving;

    void Start()
    {
        player = transform.parent; // Pastikan anchor adalah child dari player
    }

    void Update()
    {
        float inputX = UnityEngine.Input.GetAxisRaw("Horizontal");

        // Simpan arah terakhir jika ada input
        if (inputX != 0)
        {
            lastDirection = (int)Mathf.Sign(inputX);
        }

        // Cek status animasi
        isMoving = playerAnimator.GetBool("IsMoving");

        // Tentukan offset berdasarkan status gerakan
        float offsetX = isMoving ? offsetMovingX : offsetIdleX;
        float offsetY = isMoving ? offsetMovingY : offsetIdleY;

        // Atur posisi anchor
        transform.localPosition = new Vector3(offsetX * lastDirection, offsetY, transform.localPosition.z);
    }
}
