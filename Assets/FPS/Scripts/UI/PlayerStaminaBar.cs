using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStaminaBar : MonoBehaviour
{
    [Tooltip("Image component dispplaying current stamina")]
        public Image StaminaFillImage;

        Stamina m_PlayerStamina;

        void Start()
        {
            PlayerCharacterController playerCharacterController =
                GameObject.FindObjectOfType<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerStaminaBar>(
                playerCharacterController, this);

            m_PlayerStamina = playerCharacterController.GetComponent<Stamina>();
            DebugUtility.HandleErrorIfNullGetComponent<Stamina, PlayerStaminaBar>(m_PlayerStamina, this,
                playerCharacterController.gameObject);
        }

        void Update()
        {
            // update health bar value
            StaminaFillImage.fillAmount = m_PlayerStamina.CurrentStamina / m_PlayerStamina.MaxStamina;
        }
}
