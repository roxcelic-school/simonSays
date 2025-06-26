using UnityEngine;

public class attackrest : MonoBehaviour {
    public tags eviltag;
    public enum tags {
        Player,
        enemy
    }

    public float damage = 1;
    public nockbackTest nock;

    void OnEnable() {
        CheckRadius();
    }

    public void Disable() {
        transform.gameObject.SetActive(false);
    }

    void CheckRadius() {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, transform.localScale.x / 2);

        foreach (Collider collider in hitColliders){
            GameObject gameObject = collider.gameObject;
            if (gameObject.tag == eviltag.ToString())
                DealDamage(gameObject);
        }
    }

    void DealDamage(GameObject target){
        switch (eviltag) {
            case tags.Player:
                target.GetComponent<PlayerController>().Damage(damage, sys.damageTypes.Base, transform.parent.GetComponent<MainMenace>());
                nock.DamageDone = true;
                
                break;
            case tags.enemy:
                target.GetComponent<MainMenace>().Damage(damage);
                transform.parent.GetComponent<PlayerController>().Heal(damage);
                nock.DamageDone = true;

                break;
        }
    }

}