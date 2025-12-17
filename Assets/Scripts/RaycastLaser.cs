using UnityEngine;

public class RaycastLaser : MonoBehaviour
{
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
            
            Ray ray = new Ray(laserstart.transform.position, -transform.forward);
            triggerRay = Physics.Raycast(ray, out hitInfo, RayDistance);
            hitpoint = hitInfo.point;

            Laser.enabled = true;
            Laser.SetPosition(0, laserstart.transform.position);
            Laser.SetPosition(1, hitpoint);

            if (triggerRay)
            {
                if (hitInfo.transform.tag == "RaycastDetect")
                {
                    if (doorState == true)
                    {
                        Debug.Log("hit");
                        door.transform.Translate(Vector3.up * 1.211794f, Space.Self);
                        doorState = false;
                    }


                }
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
        
