using UnityEngine;
using TMPro;

public class displayContinueButtonDeath : MonoBehaviour {
    void Start() {
        transform.GetComponent<TMP_Text>().text = $"press Keyboard: {(KeyCode)eevee.Qlock.extractr()["MenuSelect"].KEYBOARD_code} / Controller: {eevee.Qlock.extractr()["MenuSelect"].CONTROLLER_name} to continue";
    }
}