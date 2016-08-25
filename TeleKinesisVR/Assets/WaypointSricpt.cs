//using UnityEngine;
//using System.Collections;

//public class WaypointSricpt : MonoBehaviour {
//    Transform Waypoint;
//    Transform[] Waypoints;
//    Transform[] Parents;
//    private float SpeedMarch = 10.0f;
//    public float Stopping = 1.0f;
//   private float FunctionState = 0.0f;
//   public bool UnitRotation = true;
//   private int WPIndexPointer;
//    public float Move;
//    public float RotationDamping = 6.0f;
//    // Use this for initialization
//    void Start () {
//        FunctionState = 0;
//    }
	
//    // Update is called once per frame
//    void Update () {

//        Waypoint = Waypoints[WPIndexPointer];
//    }
//   void Accel()
//    {
//       if(Waypoint)
//       {
//           if(UnitRotation)
//           {
//               var rotation = Quaternion.LookRotation(Waypoint.position - transform.position);
           
//               transform.rotation=Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime *RotationDamping);
//           }
//       }
//    }
//    void OnTriggerEnter()
//   {
//       FunctionState = 1;

//       WPIndexPointer++;
       
//        if(WPIndexPointer >=Waypoints.Length)
//        {
//            WPIndexPointer = 0;
//        }
//   }

//}