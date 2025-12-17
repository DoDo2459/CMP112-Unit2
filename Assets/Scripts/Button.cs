using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject door;
    public float volume;
    public AudioClip[] press;
    public AudioClip[] release;
    public RaycastLaser Laser;
    private MeshRenderer buttonMaterial;
    private AudioSource source;
    private int random;

    void Start()
    {
        buttonMaterial = GetComponent<MeshRenderer>();
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (Laser != null)
        {
            Laser.laserOn = true;
        }
        if (door != null)
        {
            buttonMaterial.material.color = Color.red;
            door.transform.Translate(Vector3.down * 1.211794f, Space.Self);
            //play audio
            random = Random.Range(0, press.Length);
            AudioClip clip = press[random];
            source.clip = clip;
            source.PlayOneShot(clip, volume);
            Debug.Log(clip.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (Laser != null)
        {
            Laser.laserOn = false;
        }
        if (door != null)
        {
            buttonMaterial.material.color = Color.green;
            door.transform.Translate(Vector3.up * 1.211794f, Space.Self);
            //play audio
            AudioClip clip = release[random];
            source.clip = clip;
            source.PlayOneShot(clip, volume);
            Debug.Log(clip.name);
        }
    }
}
