using UnityEngine;
using UnityEngine.Timeline;
using System.Collections;
using System.Numerics;
public class ArcherScript : enemyclass{
    protected override void Start(){
        enmhealth = 6f;
        cooldown = 4f;
        movspeed = 4;
        normalspeed = 4;
        //sets stats and such
        base.Start();
        StartCoroutine(fire());
    }

    protected override void Update()
    {
        base.Update();
    }

    public IEnumerator fire()//you made this I believe, I can't remember but it works!
    {
        while (true)
        {
            RangedAttack();
            yield return new WaitForSeconds(2);
        }
    }


}
