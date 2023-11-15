using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class EnemyRotating : MonoBehaviour {
    [Header("Set in Inspector")]
    public bool isRotatingClockwise;

    [Header("Set Dynamically")]
    Animator    anim;

    private void Start() {
        anim = GetComponent<Animator>();

        // Play animation clip (rotate enemy arm either clockwise or counterclockwise)
        if (isRotatingClockwise) {
            anim.CrossFade("Rotate Clockwise", 0);
        } else {
            anim.CrossFade("Rotate Counterclockwise", 0);
        }
    }
}