using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public PhysicsMaterial pushMaterial;
    public GameObject Cube;
    public GameObject Sphere;
    private Collider colliderCube;
    private Collider colliderSphere;
    private Rigidbody rbSphere;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colliderCube = Cube.GetComponent<CapsuleCollider>();
        colliderSphere = Sphere.GetComponent<Collider>();
        rbSphere = Sphere.GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSwitch();
    }

    void PlayerSwitch()
    {
        if (Input.GetButtonDown("Switch"))
        {
            //cube switching
            if (Cube.CompareTag("Player"))
            {
                Cube.tag = "NullPlayer";
                colliderCube.material = pushMaterial;
            }
            else
            {
                Cube.tag = "Player";
                Cube.transform.position = new Vector3(0, 1.211794f, 0);
                colliderCube.material = null;
            }
            //sphere switching
            if (Sphere.CompareTag("Player"))
            {
                Sphere.tag = "NullPlayer";
                colliderSphere.material = pushMaterial;
            }
            else
            {
                rbSphere.useGravity=true;
                Sphere.tag = "Player";
                Sphere.transform.position = new Vector3(0, 1.211794f, 0);
                colliderSphere.material = null;
            }
        }
    }
}
