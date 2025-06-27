using UnityEngine;

public class ArcherProjectile : ProjectileScript
{
    void Start()
    {
        movspeed = 20f;
        parry = true;
        dmg = 1;
    }

    void Update()
    {
          transform.position += transform.forward * movspeed * Time.deltaTime; //moves projectile forwards. When the projectile is spawned, it should be facing the intended direction from the shooter.
          base.Update();
    }
}
