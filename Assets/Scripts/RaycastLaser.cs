using UnityEngine;

public class RaycastLaser : MonoBehaviour
{
    //variable creation
    [SerializeField] public Transform laserstart;
    [SerializeField] public float RayDistance;
    [SerializeField] private LineRenderer Laser;

    public bool laserOn;
    private RaycastHit hitInfo;
    private bool doorState = false;
    private bool triggerRay = false;
    private Vector3 hitpoint = Vector3.zero;
    

    public GameObject door;

    
    // Update is called once per frame
    void Update()
    {
        DoRaycast();
    }

    void DoRaycast()
    {

        if (laserOn == true)
        {
            //setup raycast
            Ray ray = new Ray(laserstart.transform.position, -transform.forward);
            triggerRay = Physics.Raycast(ray, out hitInfo, RayDistance);
            hitpoint = hitInfo.point;
            //make raycast visable
            Laser.enabled = true;
            Laser.SetPosition(0, laserstart.transform.position);
            Laser.SetPosition(1, hitpoint);

            if (triggerRay)
            {
                //shuts door when raycast hits correct object with tag
                if (hitInfo.transform.tag == "RaycastDetect")
                {
                    if (doorState == true)
                    {
                        door.transform.Translate(Vector3.up * 1.211794f, Space.Self);
                        doorState = false;
                    }
                }
                //otherwise opens door
                else
                {
                    if (doorState == false)
                    {
                        door.transform.Translate(Vector3.down * 1.211794f, Space.Self);
                        doorState = true;
                    }
                }
            }
        }
        else
        //makes sure connected door is open when off
        {
            if (doorState == false)
            {
                door.transform.Translate(Vector3.down * 1.211794f, Space.Self);
                doorState = true;
            }
            Laser.enabled = false;
        }
       
        
    }
   
}
        
