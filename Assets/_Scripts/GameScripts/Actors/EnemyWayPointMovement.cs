//////////////////////////////////////////////////////
// Patrol2D Implementation 
//////////////////////////////////////////////////////
// Created: 2015-05-28 9:15 AM (EST)
// Updated: 2015-05-28 11:12 AM (EST)
// Revision: 5
// Version: 1.0.4
//////////////////////////////////////////////////////
// v1.0.4 - Defined new prrivate behavior 'HasReachedDestination(float)' which is
// responsible for checking to see if a waypoint destination has been reached, if 
// it has the next waypoint is assigned and movement for this frame is applied. 
//
// v1.0.4 - Created new enum 'PatrolType' and publicly exposed 'PatrolType patrolType'
// to allow designers to easily specify whether the object is moveing on the X or Y
// or both axises (XAxisPatrol, YAxisPatrol & MultiAxisPatrol)
//--------------------------------------------------------------------------------
// v1.0.3 - Created 'bool is_facing_right_' and a setup a standard boolean switch
// inside the scope of 'Flip()' to track the current facing direction of object. 
//
// v1.0.3 - DESIGN FLAW #0 has been been FIXED. A quick check is preformed within
// 'Start()'. Using the distanceX between the start position of the object and 
// the first waypoint. If value is negative, object will need to move and face LEFT
// else RIGHT is the way to go. 
//--------------------------------------------------------------------------------
// v1.0.2 - Created and Exposed 'float withinRangeThreshold' to allow designers to
// specify how close the object this script is attached to must be to it's target
// waypoint before it is considered to have reached it's destination. This is useful
// for supporting a variety of proportions. (Tiny to Huge sized enemies)
//--------------------------------------------------------------------------------
// v1.0.1 - Added the ability to loop the patrol cycle and exposed a bool publicly
// to allow designers to easily set or unset this behavoir (default val: true)
//--------------------------------------------------------------------------------
// v1.0.0 - Created and Exposed 'Transform[] waypoints' to allow waypoints to be
// defined in Unity Editor (using empty GameObject's transform values). 
//
// v1.0.0 - Replicated functionality of CrappyPatrolAI.cs but using
// Waypoints (Transforms) to define start and end positions. 
//
// v1.0.0 DESIGN FLAW #0: Script currently ASSUMES that all objects this script is 
// attached to are facing rightwards. 97% to 99% of the time, in a platformer this 
// is the case anyway BUT it's never smart to limit the functionality of any behavior
// unnessecarrily. 


using UnityEngine;
using System.Collections.Generic;

// The underrlying datatype for this enum is a byte (8 bits) which will 
// allow for upto 255 unique values. More than enough for what is needed. 
public enum PatrolType : byte
{
	XAxisPatrol = 0,
	YAxisPatrol,
	MultiAxisPatrol
}

public enum MovementType{
    NONLOOP,
    LOOPED
}

public enum GameType{
    ARCADE,
    SURVIVAL,
	CAMPAIGN,
    BOSS

}

public class EnemyWayPointMovement : MonoBehaviour{
	public CampaignModeManager CMM;
	//////////////////// PUBLIC PROPERTIES ////////////////////
	[Header("Patrol Configuration")]
	public float moveSpeed = 2f;
	public PatrolType patrolType = PatrolType.XAxisPatrol;
    public MovementType movementType = MovementType.NONLOOP;
	public bool isPathLooped = true;

    public GameType currentGameType = GameType.ARCADE;

	[Header("Waypoint Configuration")]
    public List <Transform> waypoints = new List<Transform>();
	public float withinRangeThreshold = 1.0f;
    public bool isActive;

	//////////////////// PRIVATE PROPERTIES ////////////////////
	private int waypointIndex = 0;
	private bool is_facing_right_ = true;
	private bool is_completed_path = false;

	// Auto-Invoked by Unity Once per object's lifetime; this makes it ideal 
	// for setting up our references. 
	public void Awake()
	{
		CMM = FindObjectOfType<CampaignModeManager>();
		if(CMM != null){
			currentGameType = GameType.CAMPAIGN;
		}
		// DESIGN FLAW #0 FIX: Detects direction object should be 'facing' based
		// on it's current destination and it's first waypoint. 
		//if (waypoints[waypointIndex].position.x - transform.position.x < 0)
		//{
		//	is_facing_right_ = false;
		//}
	}
    public void OnEnable()
    {
        waypointIndex = 0;
        switch (currentGameType)
        {
            case GameType.SURVIVAL:
               switch (movementType)
                {
                    case MovementType.NONLOOP:
                        waypoints = new List<Transform>(FindObjectOfType<SurvivalModeManager>().enemyRoute);
                        break;
                    case MovementType.LOOPED:
                        waypoints = new List<Transform>(FindObjectOfType<SurvivalModeManager>().enemyRouteLoop);
                        break;
                }
                //waypoints = new List<Transform>(FindObjectOfType<SurvivalModeManager>().enemyRouteLoop);
                break;

            case GameType.ARCADE:
                waypoints = new List<Transform>(FindObjectOfType<ArcadeModeManager>().currentRoute);
                break;

			case GameType.CAMPAIGN:
                waypoints = new List<Transform>(FindObjectOfType<CampaignModeManager>().currentRoute);
                break;

            case GameType.BOSS:
                waypoints = new List<Transform>(FindObjectOfType<ArcadeModeManager>().bossRoute);
                break;
        }
    }

    public void FixedUpdate()
	{
        if (isActive)
        {
            // If 'isPathLooped' is false and the object has reached the final waypoint 
            // within it's path then the object stops. 
            if (!is_completed_path)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, step);

                // Scope: Need to give a value to distance1D_to_waypoint since it's value is assigned
                // inside the scope of the switch statement but distance1D_to_waypoint is passed into
                // 'HasReachedDestination' outside the scope of the switch statement. This results in
                // the compiler thinking we're tying to pass a variable with no value (compiler error)
                // If the above explaination dosen't make sense, comment out the '= -1.0f;' assigment 
                // below and see what happens in Unity Editor. 
                float distance1D_to_waypoint = -1.0f;   // XAxisPatrol || YAxisPatrol
                                                        //Vector3 distance2D_to_waypoint = new Vector3();   // MultiAxisPatrol

                //  Distance between current waypoint and this object; how this is calculated is 
                //  dependent on the value of patrolType. 

                distance1D_to_waypoint = Vector3.Distance(waypoints[waypointIndex].position, transform.position);
                       

                // Check to see if the object has reached it's current waypoint target.
                HasReachedDestination(distance1D_to_waypoint);

            }
        }
	}

	private void HasReachedDestination(float distance1D)
	{
		// check if checkpoint has been reached
		// Math Usage: Mathf.Abs(value) obtains the 'Absolute Value' which simply 
		// referes to the distance a number is away from 0. Such that Mathf.Abs(42)
		// and Mathf.Abs(-42) both return 42. 
		if (Mathf.Abs(distance1D) <= withinRangeThreshold)
		{
			waypointIndex++;

            if (waypointIndex >= waypoints.Count){
				if (isPathLooped){
					waypointIndex = 0;
				}else{
                    waypoints.Clear();
                    waypointIndex = 0;
                    GetComponent<Enemy>().Disable();
				}

			}

			//if (!is_completed_path)
			//{
				//// New waypoint so recalc distance between this object and new waypoint
				//// so we can determine if we need to flip the sprite.  
				//distance1D = waypoints[waypointIndex].position.x - transform.position.x;
				//if (distance1D > 0 && !is_facing_right_)
				//{
				//	Flip();
				//}
				//else if (distance1D < 0 && is_facing_right_)
				//{
				//	Flip();
				//}
			//}
		}
	}

	private void Flip()
	{
		// Boolean Switch
		// The syntax may seem odd at first glance but if you keep mind that
		// is_facing_right_ is a boolean variable (true or false) and the ! operator
		// is the logical NOT. Such that (NOT)true is false and (NOT)false is true. 
		// Assuming is_facing_right_ is true to begin with then the line below could
		// be restated in english as "is_facing_right_ is equal to !true (false)" This
		// works the same for when is_facing_right_ is false; the below line will then
		// set it to true. 
		is_facing_right_ = !is_facing_right_;

		// The alternitive method to acheive the above line of code would be as follows:
		// In this programmer's opinon the below contains too many damn lines of code for
		// the simple task of flipping between binary values. 
		//    if(is_facing_right_)
		//    {
		//        is_facing_right_ = false;
		//    }
		//    else
		//    {
		//        is_facing_right_ = true;
		//    }


		// Scale the sprite along the X-axis
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}