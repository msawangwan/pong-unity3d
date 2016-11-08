using UnityEngine;

public class Collectable : MonoBehaviour {
    private void OnTriggerEnter2D (Collider2D c) {
        gameObject.SetActive(false);
    }
}
