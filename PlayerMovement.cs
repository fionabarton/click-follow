using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On click sets a target position that the player game object will move towards
// until it either reaches said destination, or another target is set.
public class PlayerMovement : MonoBehaviour {
    [Header("Set in Inspector")]
    public GameObject playerDestination;

    [Header("Set dynamically")]
    Vector2 target;
    float   defaultSpeed = 1;
    float   speed = 1;
    float   maxSpeed = 10;

    void Update() {
        // Get amount to move for each frame
        float step = speed * Time.deltaTime;

        // Move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        // Set target position
        if (Input.GetMouseButtonDown(0)) {
            Vector2 p = Input.mousePosition;
            Vector2 pos = Camera.main.ScreenToWorldPoint(p);
            target = pos;
            playerDestination.transform.position = pos;
        }

        // Gradually increase speed
        if (Input.GetMouseButton(0)) {
            if (speed <= maxSpeed) {
                speed += Time.deltaTime * 5;
            }
        }

        // Reset speed
        if (Input.GetMouseButtonUp(0)) {
            speed = defaultSpeed;
        }

        //// Get amount to move for each frame
        //float step = speed * Time.deltaTime;

        //// Move sprite towards the target location
        //transform.position = Vector2.MoveTowards(transform.position, target, step);

        //// Set target position
        //if (Input.GetMouseButtonDown(0)) {
        //    //Vector2 p = Input.mousePosition;
        //    //Vector2 pos = Camera.main.ScreenToWorldPoint(p);
        //    //target = pos;

        //    // Reset speed
        //    speed = defaultSpeed;
        //}  
        
        //if (Input.GetMouseButton(0)) {
        //    Vector2 p = Input.mousePosition;
        //    Vector2 pos = Camera.main.ScreenToWorldPoint(p);
        //    target = pos;

        //    // Gradually increase speed
        //    if (speed <= maxSpeed) {
        //        speed += Time.deltaTime * 5;
        //    } else {
        //        speed = maxSpeed;
        //    }
        //} 
        
        //if (Input.GetMouseButtonUp(0)) {
        //    // Reset speed
        //    speed = defaultSpeed;
        //}
    }
}