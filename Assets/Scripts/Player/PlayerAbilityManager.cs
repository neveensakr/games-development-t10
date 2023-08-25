using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType
{
    Invulnerability,
    Dash
}

public class PlayerAbilityManager : MonoBehaviour
{
    [SerializeField] public AbilityType abilityType = AbilityType.Invulnerability;
    [SerializeField] public float abilityActiveTime = 3f; // The amount of time the ability will be active
    [SerializeField] public float abilityCooldownTime = 20f; // The amount of time the ability needs to be able to be activated again
    public bool abilityActive = false;

    public bool canUseAbility = true;

    // Update is called once per frame
    void Update()
    {
        if (canUseAbility && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(AbilityActiveCoroutine());
        }
    }

    private IEnumerator AbilityActiveCoroutine()
    {
        abilityActive = true; // Set the abilityActive flag to true when ability is activated

        // Wait for the specified time before disabling ability
        yield return new WaitForSeconds(abilityActiveTime);

        abilityActive = false; // Set the abilityActive flag to false when ability is finished
        StartCoroutine(AbilityCooldownCoroutine()); // Start Cooldown for ability
    }

    private IEnumerator AbilityCooldownCoroutine()
    {
        canUseAbility = false; // Set the canUseAbility flag to false when ability is used and in cooldown

        // Wait for the specified time before fully cool down the ability
        yield return new WaitForSeconds(abilityCooldownTime);

        canUseAbility = true; // Set the canUseAbility flag to false when ability is out of cooldown and can be used again
    }
}
