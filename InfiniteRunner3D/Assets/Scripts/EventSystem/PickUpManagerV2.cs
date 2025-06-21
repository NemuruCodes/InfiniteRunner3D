using UnityEngine;
using System.Collections;
using TMPro;


public class PickUpManagerV2 : MonoBehaviour
{
    [Header("Buff Settings")]
    public float duration = 5f;
    public PowerEffects JumpBuff;

    [Header("References")]
    public GameObject Shield;
    public PickUpUI pickUpUI;

    private bool jumpRoutineStarted = false;

    public static bool IsPointBuffActive { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        GameEvents.Instance.OnBulletPickup += HandleBulletPickup;
        GameEvents.Instance.OnJumpPickup += HandleJumpPickup;
        GameEvents.Instance.OnShieldPickup += HandleShieldPickup;
        GameEvents.Instance.OnPointPickup += HandlePointPickup;
    }
    
    private void OnDisable()
    {
        GameEvents.Instance.OnBulletPickup -= HandleBulletPickup;
        GameEvents.Instance.OnJumpPickup -= HandleJumpPickup;
        GameEvents.Instance.OnShieldPickup -= HandleShieldPickup;
        GameEvents.Instance.OnPointPickup -= HandlePointPickup;
    }
    
    private void HandleBulletPickup()
    {
        Shoot.BulletChecked = true;
    }

    private void HandleJumpPickup()
    {
        if (!jumpRoutineStarted)
        {
            StartCoroutine(JumpRoutine());
            jumpRoutineStarted = true;
        }
    }

    private void HandleShieldPickup()
    {
        Debug.Log("Sheild?");
        StartCoroutine(ShieldRoutine());
    }

    private void HandlePointPickup()
    {
        StartCoroutine(PointRoutine());
    }

    private IEnumerator JumpRoutine()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float elapsed = 0f;

        pickUpUI.ShowBuff("Jump Boost", duration);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            JumpBuff.ApplyEffect(player);
            yield return null;
        }

        JumpBuff.RemoveEffect(player);
        jumpRoutineStarted = false;
    }

    private IEnumerator ShieldRoutine()
    {
        pickUpUI.ShowBuff("Shield", duration);
        Shield.SetActive(true);
        yield return new WaitForSeconds(duration);
        Shield.SetActive(false);
    }

    private IEnumerator PointRoutine()
    {
        pickUpUI.ShowBuff("X2 Points", duration);
        IsPointBuffActive = true;
        yield return new WaitForSeconds(duration);

        IsPointBuffActive = false;
    }
}
