using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Sphere;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch"))
        {
            if(Cube.CompareTag("Player"))
            {
                Cube.tag = "NullPlayer";
            }
            else
            {
                Cube.tag = "Player";
                Cube.transform.position = new Vector3(0, 1.211794f, 0);
            }
            if (Sphere.CompareTag("Player"))
            {
                Sphere.tag = "NullPlayer";
            }
            else
            {
                Sphere.tag = "Player";
                Sphere.transform.position = new Vector3(0, 1.211794f, 0);
            }
        }
    }
}
