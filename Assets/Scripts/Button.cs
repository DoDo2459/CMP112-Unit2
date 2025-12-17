using UnityEngine;

public class Button : MonoBehaviour
{
    //variable creation
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
        //play audio
        random = Random.Range(0, press.Length);
        AudioClip clip = press[random];
        source.clip = clip;
        source.PlayOneShot(clip, volume);
        Debug.Log(clip.name);
        //change button material colour to red
        buttonMaterial.material.color = Color.red;
        //turn laser on if connected
        if (Laser != null)
        { 
            Laser.laserOn = true;
        }
        //open door if connected
        if (door != null)
        {
            door.transform.Translate(Vector3.down * 1.211794f, Space.Self);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //play audio
        AudioClip clip = release[random];
        source.clip = clip;
        source.PlayOneShot(clip, volume);
        Debug.Log(clip.name);
        //change button material colour to green
        buttonMaterial.material.color = Color.green;
        //toggle laser off when connected
        if (Laser != null)
        {
            Laser.laserOn = false;
        }
        //close door if connected
        if (door != null)
        {
            
            door.transform.Translate(Vector3.up * 1.211794f, Space.Self);
            
        }
    }
}
