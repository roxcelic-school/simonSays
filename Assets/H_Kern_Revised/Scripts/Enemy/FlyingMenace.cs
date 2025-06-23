using UnityEngine;
using UnityEngine.Timeline;
using System.Collections;
public class FlyingMenace : enemyclass{
    protected override void Start(){
        enmhealth = 3f;
        cooldown = 4f;
        movspeed = 10;
        normalspeed = 10;
        //sets stats and such
        base.Start();
        StartCoroutine(fire());
    }

    protected override void Update()
    {
        targetpos.y = 3;
        transform.position = Vector3.MoveTowards(transform.position, targetpos, movspeed * Time.deltaTime);//moves enemy to that random point, and checks if it's still there? idk how to explain it.
        if (Vector3.Distance(transform.position, targetpos) < 0.1f)
        {
            ismoving = false;
        }
        
        base.Update();
    }

    public IEnumerator fire()//you made this I believe, I can't remember but it works!
    {
        while (true)
        {
            Relocate();
            // for (int i = 0; i < ; i++) 
            // {
            //     RangedAttack();
            //     yield return new WaitForSeconds(1);
            // }
            RangedAttack();
            yield return new WaitForSeconds(1);
        }
    }


}
