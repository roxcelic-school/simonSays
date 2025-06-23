using UnityEngine;

public class MeleeHitboxScript : MonoBehaviour
{
    public int dmg = 2;
    protected float lasthit;
    public GameObject hiteffect;
    protected string parentuser;

    void Start()
    {

    }

    void Update()
    {

    }
    void OnTriggerEnter(Collider colobj)
    {
        Instantiate(hiteffect, transform.position, Quaternion.Euler(-90, 0, 0));//swipe effect or whatever
        if (parentuser == "Player")
        {
            if (colobj.gameObject.tag == "Enemy" && Time.time > lasthit + 0.1f)
            {
                if (colobj.gameObject.GetComponent<enemyclass>() != null)
                {
                    colobj.gameObject.GetComponent<enemyclass>().takedamage(dmg, "melee");
                    lasthit = Time.time;
                    Destroy(gameObject);
                }
            }
        }
        else if (parentuser == "enemy")
        {
            if (colobj.gameObject.tag == "Player" && Time.time > lasthit + 0.1f)
            {
                if (colobj.gameObject.GetComponent<PlayerControllerH>() != null)
                    {
                    colobj.gameObject.GetComponent<PlayerControllerH>().playertookdamage(dmg);
                    lasthit = Time.time;
                    Destroy(gameObject);
                    }

            }
        }
        else
        {
            Debug.Log("Error with the parent user");
        }

        
        
    }
}
