using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using System.Collections; // Jangan lupa tambahkan ini untuk coroutine

public class VideoCutsceneTrigger : MonoBehaviour
{
    [Header("References")]
    public VideoPlayer videoPlayer;
    public Canvas videoCutsceneUI;

    [Header("Settings")]
    public float delayBeforeVideo = 3f; // Delay 3 detik

    [Header("Events")]
    public UnityEvent onTriggerEnter;
    public UnityEvent onVideoComplete;

    private bool hasTriggered = false;

    private void Start()
    {
        videoPlayer.playOnAwake = false;
        videoPlayer.Stop();

        if (videoCutsceneUI != null)
            videoCutsceneUI.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            onTriggerEnter.Invoke();
            Debug.Log("Player entered trigger area");

            // Mulai coroutine untuk delay
            StartCoroutine(PlayVideoWithDelay());
        }
    }

    IEnumerator PlayVideoWithDelay()
    {
        Debug.Log($"Waiting for {delayBeforeVideo} seconds before playing video...");

        // Tunggu selama delayBeforeVideo detik
        yield return new WaitForSeconds(delayBeforeVideo);

        // Setelah delay, mainkan video
        PlayVideo();
    }

    public void PlayVideo()
    {
        if (videoCutsceneUI != null)
            videoCutsceneUI.gameObject.SetActive(true);

        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        onVideoComplete.Invoke();
        Debug.Log("Video finished");

        if (videoCutsceneUI != null)
            videoCutsceneUI.gameObject.SetActive(false);
    }
}