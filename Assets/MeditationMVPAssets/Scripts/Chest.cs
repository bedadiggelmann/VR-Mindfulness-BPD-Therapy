using UnityEngine;
using DG.Tweening;

public class Chest : MonoBehaviour
{
    [Header("UI")]
    public ChestUI chestUI;

    [Header("Audio")]
    public AudioClip MeditationClip;

    [Header("Chest Lid")]
    public GameObject ChestLid;
    public Vector3 OpenLidRotation;
    Vector3 ClosedLidRotation;
    bool opened = false;
    bool keyTriggered = false; 

    [Header("Chest Contents")]
    public ParticleSystem ChestOpenParticles;
    public MeditationCrystal Crystal;

    private void Start()
    {
        ClosedLidRotation = ChestLid.transform.localEulerAngles;
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.O))
        {
            OnOpenButtonPressed();
        }
#endif
    }

    void OnTriggerEnter(Collider other)
    {
        if (keyTriggered) return; 
        if (other.tag == "Key")
        {
            keyTriggered = true; 
            OnOpenButtonPressed();
            other.gameObject.SetActive(false);
        }
    }

    public void OnOpenButtonPressed()
    {
        if (opened) return;
        chestUI.HideUI();
        OpenChest();
        opened = true;
        MeditationSoundManager.instance.PlayClip(MeditationClip);
    }

    public void OpenChest()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(ChestLid.transform.DOLocalRotate(OpenLidRotation, 1f));
        sequence.Play();
        sequence.OnComplete(() =>
        {
            ChestOpenParticles.Play();
        });

        Crystal.StartMeditation();
    }

    public void CloseChest()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(ChestLid.transform.DOLocalRotate(ClosedLidRotation, 1f));
        sequence.Play();
        sequence.OnComplete(() =>
        {
            chestUI.ActivateRestartPanel();
            chestUI.ShowUI();
        });
    }
}