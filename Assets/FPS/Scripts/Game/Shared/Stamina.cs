using UnityEngine;
using UnityEngine.Events;

public class Stamina : MonoBehaviour
{
    [Tooltip("Maximum amount of stamina")] public float MaxStamina = 100f;

    [Tooltip("Stamina ratio at which the critical stamina vignette starts appearing")]
    public float CriticalStaminaRatio = 0.3f;
    
    private float StaminaLossPerFrame = 2f;
    private float StaminaGainPerFrame = 2f;

    public float CurrentStamina { get; set; }

    private bool CanGetStamina { get; set; }
    private float Timer;
    private float TimerToRegenerate;

    void Start()
    {
        CurrentStamina = MaxStamina;
        TimerToRegenerate = 10f;
    }

    public void RegenerateStamina() {
        if (this.CurrentStamina < MaxStamina)
            this.CurrentStamina += StaminaGainPerFrame;
    }

    public void LoseStamina() {
        if (this.CurrentStamina > 0)
            this.CurrentStamina -= StaminaLossPerFrame;
    }

    public void StaminaTimer() {
        Timer += 0.2f;
        if (Timer > TimerToRegenerate) {
            CanGetStamina = true;
        } else { CanGetStamina = false; }
    }

    public void ResetTimer() {
        Timer = 0f;
    }

    public bool CanRegenerate () {
        return this.CanGetStamina;
    }

}
