using UnityEngine;
using DG.Tweening;
using HighlightPlus;
using HurricaneVR.Framework.Core.Player;

public class MeditationCrystal : MonoBehaviour
{
    bool isMeditating = false;

    [Header("Meditation")]
    [Header("DelayedStart")]
    public float DelayedStartDuration;
    bool onDelay = false;
    [Header("Starting")]
    public float StartingDuration;
    public float StartInhaleDuration;
    public float StartExhaleDuration;
    bool onStart = false;
    [Header("Ending")]
    public float EndingDuration;
    public float EndInhaleDuration;
    public float EndExhaleDuration;
    bool onEnd = false;
    [Header("Scale")]
    public float MaxScale;
    public float MinScale;
    [Header("Height")]
    public float MaxHeight;
    public float MinHeight;
    [Header("HighlightEffect")]
    public HighlightEffect HighlightEffects;

    [Header("Other Objects")]
    [Header("Chest")]
    public Chest ChestObject;
    [Header("Player Locking")]
    public GameObject Player;


    float timer = 0.0f;

    void Start()
    {
        transform.DOScale(0, 0);
    }

    void Update()
    {
        if (!isMeditating) return;

        if (onDelay)
        {
            timer += Time.deltaTime;
            if (timer >= DelayedStartDuration)
            {
                onDelay = false;
                onStart = true;
                timer = 0.0f;
                transform.DOScale(MinScale, 5.0f);
                transform.DOLocalMoveY(MaxHeight, 5.0f).OnComplete(Pulse);
            }
        }

        if (onStart)
        {
            timer += Time.deltaTime;
            if (timer >= StartingDuration)
            {
                onStart = false;
                onEnd = true;
                timer = 0.0f;
            }
        }

        if (onEnd)
        {
            timer += Time.deltaTime;
            if (timer >= EndingDuration)
            {
                EndMeditation();
            }
        }
    }

    public void Pulse()
    {
        if (!isMeditating) return;
        if (onDelay) return;

        Sequence sequence = DOTween.Sequence();
        if (onStart)
        {
            sequence.Append(transform.DOScale(MaxScale, StartInhaleDuration).SetEase(Ease.Linear));
            sequence.Append(transform.DOScale(MinScale, StartExhaleDuration).SetEase(Ease.Linear));
        }
        else if (onEnd)
        {
            sequence.Append(transform.DOScale(MaxScale, EndInhaleDuration).SetEase(Ease.Linear));
            sequence.Append(transform.DOScale(MinScale, EndExhaleDuration).SetEase(Ease.Linear));
        }
        sequence.Play();
        sequence.OnComplete(Pulse);
    }

    public void EndMeditation()
    {
        // Enable player movement 
        // Player.GetComponent<HVRPlayerController>().MoveSpeed = 1;
        // Player.GetComponent<HVRTeleporter>().enabled = true;

        // End meditation
        isMeditating = false;

        onDelay = false;
        onStart = false;
        onEnd = false;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0, 25.0f).SetEase(Ease.Linear));
        sequence.Join(transform.DOLocalMoveY(MinHeight, 30.0f).SetEase(Ease.Linear));
        sequence.Play();
        sequence.OnComplete(ChestObject.CloseChest);
    }

    public void StartMeditation()
    {
        // Disable player movement 
        // Player.GetComponent<HVRPlayerController>().MoveSpeed = 0;
        // Player.GetComponent<HVRTeleporter>().enabled = false;
        // Start meditation
        isMeditating = true;
        timer = 0.0f;

        onDelay = true;
        onStart = false;
        onEnd = false;
    }
}