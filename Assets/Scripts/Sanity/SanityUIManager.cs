using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SanityUIManager : MonoBehaviour
{
    [SerializeField] Gradient fineGrad;
    [SerializeField] Gradient damagedGrad;
    [SerializeField] Gradient cautionGrad;
    [SerializeField] Gradient dangerGrad;
    [SerializeField] ParticleSystem colorOver;
    [SerializeField] Color newColor;
    [SerializeField] bool debug;
    private Coroutine regenRoutine;
    public void UpdateVisual(float sanityValue)
    {
        Debug.Log("invoke!");

        ParticleSystem.ColorOverLifetimeModule colormodule = colorOver.colorOverLifetime;
        if (sanityValue >= 75)
            colormodule.color = knob.color = newColor = fineGrad.colorKeys[0].color;
        else if (sanityValue < 75 && sanityValue >= 50)
            colormodule.color = knob.color = newColor = damagedGrad.colorKeys[0].color;
        else if (sanityValue < 50 && sanityValue >= 25)
            colormodule.color = knob.color = newColor = cautionGrad.colorKeys[0].color;
        else
            colormodule.color = knob.color = newColor = dangerGrad.colorKeys[0].color;
    }
    event Action<float> OnSanityChanged = delegate { };

    Image knob;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        knob = transform.GetChild(0).GetComponent<Image>();
        OnSanityChanged += (san) => UpdateVisual(san);
    }

    [Range(0, 100)] public float sanityVal;

    void Update()
    {
        animator.SetFloat("Sanity", sanityVal);
        OnSanityChanged?.Invoke(sanityVal);
    }

    public void StartSanityRegen()
    {
        if (regenRoutine == null)
            regenRoutine = StartCoroutine(RegenerateSanity());
    }

    public void StopSanityRegen()
    {
        if (regenRoutine != null)
        {
            StopCoroutine(regenRoutine);
            regenRoutine = null;
        }
    }

    IEnumerator RegenerateSanity()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.5f); // pakai Realtime agar tetap bisa jalan saat Time.timeScale = 0
            sanityVal += 2f;
            if (sanityVal > 100f)
                sanityVal = 100f;
        }
    }
}
