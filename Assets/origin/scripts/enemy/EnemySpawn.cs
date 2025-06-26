using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {
    [SerializeField] public List<GameObject> enemys = new List<GameObject>();
    public Collider col;
    public bool activated = false;
    public bool Forceactivated = false;
    public bool endRoom = false;
    public int count = -1;
    public float safeborder = 5f;

    private GameObject world;

    void Start() {
        col = GetComponent<Collider>();

        if (Forceactivated && !activated)
            StartCoroutine(SpawnCreatures());

        world = transform.parent.parent.gameObject; 

        StartCoroutine(waitforallenemystodie());
    }

    public int GetRoomCount() {
        int basic = 0;

        foreach (Transform child in world.transform)
            basic++;

        return basic;
    }

    public void DoTheRoar() {
        StartCoroutine(SpawnCreatures());
    }

    public IEnumerator SpawnCreatures() {
        yield return new WaitForSeconds(1);

        if (!GameObject.Find("Canvas").transform.Find("powerups").gameObject.activeSelf) foreach (GameObject bean in enemys){
            GameObject newBean = Instantiate(bean, new Vector3(0, 0, 0), Quaternion.identity);

            // add pointer to player
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if(players[0].GetComponent<PlayerController>() != null && players[0].GetComponent<PlayerController>().pointer) players[0].GetComponent<PlayerController>().SpawnPointer(newBean);

            Bounds bounds = col.bounds;

            newBean.transform.position = transform.position + new Vector3(0, 1, 0);

            Debug.Log($"spawn position = {newBean.transform.position}");
        }

        activated = true;
    }

    void Update() {
        if (!endRoom || PlayerPrefs.GetString("generated", "false") != "true") return;

        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, transform.localScale.x / 2);

        foreach (Collider collider in hitColliders){
            GameObject gameObject = collider.gameObject;
            if (gameObject.tag == "Player") {
                Time.timeScale = 1f;
                GameObject loadingScreen = GameObject.Find("Canvas").transform.Find("powerups").gameObject;
                loadingScreen.SetActive(true);
            }
        }
    }

    public IEnumerator waitforallenemystodie() {
        yield return new WaitUntil(() => ((GameObject.FindGameObjectsWithTag("enemy").Length == 0 && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)&& activated));

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length != 0 && players[0].GetComponent<PlayerController>() != null) {
            if(world.transform.childCount - 1 >= players[0].GetComponent<PlayerController>().room + 1) world.transform.GetChild(players[0].GetComponent<PlayerController>().room + 1).gameObject.GetComponent<ImprovedGeneration>().gate.GetComponent<DoorBlock>().RemoveBlockAid();

            players[0].GetComponent<PlayerController>().increaseRoomIndex();

            if (GetRoomCount() - 1< players[0].GetComponent<PlayerController>().room) {    
                Time.timeScale = 1f;
                GameObject loadingScreen = GameObject.Find("Canvas").transform.Find("powerups").gameObject;
                loadingScreen.SetActive(true);
            } else {
                Destroy(transform.gameObject);
                transform.parent.parent.GetChild(transform.parent.GetSiblingIndex() + 1).Find("enemys").GetComponent<EnemySpawn>().DoTheRoar();
            }
        } else if (players.Length != 0) {
            Transform parentTransform = transform.parent.parent;
            int siblingIndex = transform.parent.GetSiblingIndex();

            if (parentTransform != null) {
                if (siblingIndex + 1 < parentTransform.childCount) { 
                    Transform siblingTransform = parentTransform.GetChild(siblingIndex + 1);
                    GameObject Child = siblingTransform.gameObject;

                    Debug.Log(Child.name);

                    Child.GetComponent<ImprovedGeneration>().gate.GetComponent<DoorBlock>().RemoveBlockAid();
                    Child.GetComponent<ImprovedGeneration>().enemySpawnering.GetComponent<EnemySpawn>().DoTheRoar();

                    Destroy(transform.gameObject);
                } else {
                    Time.timeScale = 1f;
                    GameObject loadingScreen = GameObject.Find("Canvas").transform.Find("powerups").gameObject;
                    loadingScreen.SetActive(true);
                }
            }
        }
    }
}