using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject door;
    private MeshRenderer buttonMaterial;
    void Start()
    {
        buttonMaterial = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
    
        buttonMaterial.material.color = Color.red;
        Debug.Log("Col");
        door.transform.Translate(Vector3.down * 1.211794f, Space.Self);
    }

    private void OnTriggerExit(Collider other)
    {
        buttonMaterial.material.color = Color.green;
        door.transform.Translate(Vector3.up * 1.211794f, Space.Self);
    }
}
