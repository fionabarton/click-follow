using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class CamFollow : MonoBehaviour {
    [Header("Set in Inspector")]
    public List<GameObject> camTargets;
    public float            speed = 0.75f;

    [Header("Set dynamically")]
    GameObject              currentCamTarget;
    int                     currentTargetNdx = 0;
    public bool             canMove = false;

    private void Start() {
        // Set first target in list to current target
        currentCamTarget = camTargets[0];
    }

    void FixedUpdate() {
        if (canMove) {
            // Get amount to move for each frame
            float step = speed * Time.deltaTime;

            // Move camera towards the target location
            transform.position = Vector3.MoveTowards(transform.position, 
                new Vector3(currentCamTarget.transform.position.x, 
                currentCamTarget.transform.position.y, -10), 
                step);
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "CamTarget") {
            // Increment target index
            currentTargetNdx += 1;

            // If there are remaining targets on the list...
            if (currentTargetNdx <= camTargets.Count - 1) {
                // Set next target on the list to current target
                currentCamTarget = camTargets[currentTargetNdx];
            } else {
                // Stop
                canMove = false;
            }
        }
    }
}