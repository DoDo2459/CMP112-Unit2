using UnityEngine;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour
{
    public GameObject winMenu;
    public GameManager manager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
            manager.Finished = true;
        }
        
    }
}
