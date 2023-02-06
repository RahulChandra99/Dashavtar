using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBar : MonoBehaviour
{
    public Image fillBar;
    public float currentAbility;
    public float maxAbilty;
    private ParshuSpecialAttack pl;

    private void Start()
    {
        pl = FindObjectOfType<ParshuSpecialAttack>();
    }

    private void Update()
    {
        currentAbility = pl.abilityBar;
        fillBar.fillAmount = currentAbility / maxAbilty;
    }
}
