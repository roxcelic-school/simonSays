using UnityEngine;

public class loadMenuManager : MonoBehaviour {
    public void Disable() {
        gameObject.SetActive(false);
    }
    public void Enable() {
        gameObject.SetActive(true);
    }
    public void SetTimeScale(float time){
        Time.timeScale = time;
    }
}