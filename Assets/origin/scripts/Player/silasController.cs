using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

public class silasController : PlayerController {
    [Header("silas config")]
    public bool spinning = false;
    public float silasroommodifier = 1.25f;

    protected override void Update() {
        base.Update();

        if (eevee.input.Collect("special") && !spinning && base.PlayerSpecificMeter > base.PlayerSpecificMeterUseRate) {
            base.PlayerSpecificMeter -= base.PlayerSpecificMeterUseRate;
            StartCoroutine(spin());
        }

        if (spinning) base.BaseAttackStamina = base.BaseAttackStaminaMax;
    }

    public IEnumerator spin() {
        spinning = true;
        base.speed *= 2;
        base.healModifier *= 3;
        base.attackComp.transform.localScale *= 1.5f;

        yield return new WaitForSeconds(1.5f);
        
        base.attackComp.transform.localScale /= 1.5f;
        base.speed /= 2;
        base.healModifier /= 3;
        spinning = false;
    }

    public override void increaseRoomIndex() {
        base.increaseRoomIndex();

        base.Heal(maxHealth * silasroommodifier);
    }

    public override void Heal(float Heal, bool modified = false) {
        base.Heal(Heal, modified);

        base.PlayerSpecificMeter += Heal;
    }
}
