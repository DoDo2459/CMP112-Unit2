using UnityEngine;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour
{
    //variable creation
    public GameObject winMenu;
    public GameManager manager;
    private void OnTriggerEnter(Collider other)
    {
        //checks if is player triggering end and activates end level screen
        if(other.CompareTag("Player"))
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
            manager.Finished = true;
        }
        
    }
}
