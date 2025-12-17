using UnityEngine;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour
{
    public GameObject winMenu;
    private void OnTriggerEnter(Collider other)
    {
        winMenu.SetActive(true);
    }
}
