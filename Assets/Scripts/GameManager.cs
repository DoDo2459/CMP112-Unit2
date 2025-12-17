using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public PhysicsMaterial pushMaterial;
    public GameObject Cube;
    public GameObject Sphere;
    public bool Finished;
    private bool escapeStatus = true;
    private Collider colliderCube;
    private Collider colliderSphere;
    private Rigidbody rbSphere;
    private bool spawnFree = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        if (Cube != null && Sphere != null)
        {
            colliderCube = Cube.GetComponent<CapsuleCollider>();
            colliderSphere = Sphere.GetComponent<Collider>();
            rbSphere = Sphere.GetComponent<Rigidbody>();  
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSwitch();
        PauseMenuOn();
    }

    void PlayerSwitch()
    {
        if (Input.GetButtonDown("Switch") && spawnFree && Cube != null && Sphere != null)
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

    void PauseMenuOn()
    {
        if(Input.GetButtonDown("Pause") && escapeStatus == true && Finished == false && pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            escapeStatus = false;
        }
        else if (Input.GetButtonDown("Pause") && escapeStatus == false && pauseMenu != null)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            escapeStatus = true;
        }
    }

    public void PauseMenuOff()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    void OnTriggerEnter(Collider other)
    {
        spawnFree = false;
    }

    void OnTriggerExit(Collider other)
    {
        spawnFree = true;
    }

    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void loadscene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

