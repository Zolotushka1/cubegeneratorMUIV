using UnityEngine;

public class EnablePlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject exitUi;
    public void PlayerOn()
    {
        this.gameObject.SetActive(false);
        exitUi.SetActive(true);
        player.GetComponent<CharController>().enabled = true;
        player.GetComponent<MouseMove>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
