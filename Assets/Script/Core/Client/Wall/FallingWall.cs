using UnityEngine;
using System.Collections;

public class FallingWall : MonoBehaviour {
    public float downwardPressure = 0.02f;
    private void FixedUpdate () {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(0, Mathf.Abs(downwardPressure) * -1f, 0));
    }
}
