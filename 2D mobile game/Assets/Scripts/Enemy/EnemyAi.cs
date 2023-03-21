using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyAi : MonoBehaviour
{
    //Reference to waypoints
    public List<Transform> points;
    //The int value for the next point index
    public int NextID = 0;
    //The value of that applies to ID for changing
    private int _idChangeValue = 1;
    //Speed of movement
    public float speed = 2;

    private void Reset()
    {
        Init();
    }

    private void Init()
    {
        //Make box collider trigger
        GetComponent<BoxCollider2D>().isTrigger = true;

        //Create Root object
        GameObject root = new GameObject(name + "_Root");
        //Reset position of Root to enemy object
        root.transform.position = transform.position;
        //Set enemy object as child of root
        transform.SetParent(root.transform);
        //Create waypoints object
        GameObject waypoints = new GameObject("Waypoints");
        //Reset waypoints position to root
        //Make waypoints object child of root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //Create two points (gameobject) and reset their position to waypoints object
        //Make the points children of waypoints object
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform); p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point1"); p2.transform.SetParent(waypoints.transform); p2.transform.position = root.transform.position;

        //Init points list then add the points to it
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    private void MoveToNextPoint()
    {
        //Get the next point transform
        Transform goalPoint = points[NextID];
        //Flip the enemy transform to look into the point's direction
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-7.826081f, 7.826081f, 7.826081f);
        }
        else
        {
            transform.localScale = new Vector3(7.826081f, 7.826081f, 7.826081f);

        }
        //Move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //Check the distance between enemy and goal point to trigger next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            //Check if we are at the end of the line (make the change -1)
            if (NextID == points.Count - 1)
            {
                _idChangeValue = -1;
            }
            //Check if we are at the start of the line (make the change +1)
            if (NextID == 0)
            {
                _idChangeValue = 1;
            }
            //Apply the change on the nextID
            NextID += _idChangeValue;
        }
    }
}
