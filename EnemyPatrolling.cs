using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Repeatedly moves a game object back and forth between two points
public class EnemyPatrolling : MonoBehaviour {
    [Header("Set in Inspector")]
    public Transform    startPoint;
    public Transform    endPoint;
    public float        speed = 0.75f;

    [Header("Set Dynamically")]
    public bool         isMovingToEndPoint;
    public bool         canMove = false;

    void FixedUpdate() {
        if (canMove) {
            // Get amount to move for each frame
            float step = speed * Time.fixedDeltaTime;

            if (isMovingToEndPoint) {
                transform.position = Vector3.MoveTowards(transform.position, endPoint.position, step);

                if (Vector3.Distance(transform.position, endPoint.position) < 0.001f) {
                    isMovingToEndPoint = !isMovingToEndPoint;
                }
            } else {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, step);

                if (Vector3.Distance(transform.position, startPoint.position) < 0.001f) {
                    isMovingToEndPoint = !isMovingToEndPoint;
                }
            }
        }
    }

    private void OnBecameInvisible() {
        canMove = false;
    }

    private void OnBecameVisible() {
        canMove = true;
    }
}