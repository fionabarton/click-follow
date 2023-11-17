using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class EnemyOneShot : MonoBehaviour {
    [Header("Set in Inspector")]
    public GameObject target;
    public float speed = 0.75f;

    [Header("Set Dynamically")]
    public Vector3 targetDestination;
    public bool canMove = false;

    void FixedUpdate() {
        if (canMove) {
            // Get amount to move for each frame
            float step = speed * Time.fixedDeltaTime;

            // Move sprite towards the target location
            transform.position = Vector2.MoveTowards(transform.position, targetDestination, step);
        }
    }

    private void OnBecameInvisible() {
        canMove = false;
    }

    private void OnBecameVisible() {
        canMove = true;
        targetDestination = target.transform.position;
    }
}