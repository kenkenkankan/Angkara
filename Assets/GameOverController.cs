using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private SanityUIManager sanityUI;
    [SerializeField] private GameObject gameOverPanel;
    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver && sanityUI.sanityVal <= 0f)
        {
            if (!isGameOver && sanityUI.sanityVal <= 0f)
            {
                // Pastikan AudioManager ada dan referensi death clip sudah di-set
                if (AudioManager.Instance != null && AudioManager.Instance.death != null)
                {
                    AudioManager.Instance.Play(AudioManager.Instance.death);
                }
                else
                {
                    Debug.LogError("AudioManager atau death clip tidak ditemukan!");
                }

                TriggerGameOver();
                isGameOver = true; // Pastikan hanya trigger sekali
            }
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // freeze gameplay  
    }

    // Dipanggil oleh button di UI  
    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.sceneLoaded += OnSceneLoaded; // Tunggu sampai scene selesai dimuat
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        GameObject panel = GameObject.Find("GameOverCanvas");
        if (panel != null)
            panel.SetActive(false); // hide panel di scene baru
    }


    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }
}
