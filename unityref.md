# Unity API Quick Reference

| API | Note |
|----------|------|
| Random.Range | Random number between 2 numbers. Make sure to use approproatly typed parameters! (floats or ints) |
| Random.insideUnitCircle | Random Vector2 of unit length |
| Random.insideUnitSphere | Random Vector3 of unit length |
| transform.position | Note position is a *value* type |
| transform.rotation | A quaternion, another value type |
| transform.localScale | Relative to the parent |
| transform.localPosition | |
| transform.localRotation | |
| transform.Translate | Can use local or world space |
| transform.Rotate | Can use local or world space |
| transform.RotateAround | Takes point, axis and angle. This and the subsequent call loose precision after a while |
| transform.RotateAroundLocal | Takes point, axis and angle |
| transform.SetParent | Often used to just keep the scene tidy |
| transform.up | Local up  |
| transform.right |Local right |
| transform.forward | Local forward |
| transform.TransformPoint | Scales, rotates and transforms a point by a transform. Local to world space |
| transform.InverseTransformPoint | Scales, rotates and transforms a point by a transform. World to local space |
| transform.TransformDirection | Not affected by scale or position |
| transform.LookAt | Rotates the quaternion part to look at a point in world space | 
| transform.ChildCount() | returns the number of children transforms parented to this transform |
| transform.GetChild(0) | returns child 0 |
| gameObject.SetActive | Disables and enables a gameobject and any components attached to it will not have the Update method called |
| gameObject.name |  Name in the hierarchy |
| gameObject.Tag | Set up the strings in the Unity editor. Can use with FindGameObjectWithTag |
| gameObject.layer | A number. Set up different layers for different groups of objects like environment, different enemy types. Use with layer masks. Used for raycasting and rendering |
| gameObject.GetComponent<> | To return a component attached to a gameobject. Uses generics. Returns null if there is no component attached |
| gameObject.AddComponent<> | Retuns the new component |
| gameObject.GetComponentInChildren | Recursive search |
| GameObject.FindGameObjectWithTag<> | Returns the first matching object |
| GameObject.FindGameObjectsWithTag<> | Returns a typed array of objects |
| GameObject.CreatePrimitive | Creates cubes, spheres, cylinders etc |
| GameObject.Destroy | Pass in the gameobject or component you want to distroy |
| GameObject.FindObjectOfType |  Searches the memory space for an instance of a class |
| Vector3.Dot | Multiplies 2 vectors returns a scalar. In front/behind or calculating angle between 2 vectors |
| Vector3.Lerp | Interpolates between 2 vectors using t |
| Vector3.Cross | Returns a vector that is mutully perpindicular to the 2 parameters |
| Vector3.Normalize | Makes the vector of length 1 |
| Vector3.Up | The world up vector |
| Vector3.Right | |
| Vector3.Forward | |
| Vector3.Zero | The vector (0,0,0)  |
| Vector3.One | The vector (1,1,1) |
| Vector3.Distance | Distance between 2 position vectors |
| Vector3.Angle | Angle between 2 vectors |
| x, y, z, | Note vectors are value types! (Structs) |
| vector3.normalized | |
| Quaternion.AngleAxis | This is how to make a quaternion! Angle is in degrees |
| Quaternion.Slerp |  Interpolates between 2 quaternions |
| Quaternion.Identity | No rotation |
| Quaternion.Euler | Make a quetarnion from euler angles |
| Quaternion.Inverse | Quaternion in the opposite direction |
| Quaternion.LookRotation | Makes a quaternion from a vector |
| Quaternion * by a Vector3 | Rotates the vector by the quaternion |
| Quaternion * by a Quaternion | Combines 2 quaternion rotations |
| x, y, z, w | Components of the quaternion |
| Input.GetAxis("Vertical") | returns a value between 0 and 1. Used to move things in response to user input |
| Input.GetKey(KeyCode.Escape) | Check if a key is currently being pressed |
| Input.GetButtonDown("Fire1") | Check if a button is pressed this frame |
| OnDrawGizmos | Called by the Unity editor. Allows the game component to draw gizmos to the scene view |
| Gizmos.color | Sets the color of the subsequently drawn gizmos |
| Gizmos.DrawSphere | |
| Gizmos.DrawWireSphere | |
| Gizmos.DrawCube | |
| Gizmos.DrawLine | |
| Gizmos.DrawRay | |