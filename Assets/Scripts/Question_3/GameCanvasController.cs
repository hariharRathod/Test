using UnityEngine;
using TMPro;

public class GameCanvasController : MonoBehaviour
{

    public static GameCanvasController Instance;

    [SerializeField] private GameObject shootTextGameObject;


    private void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(this.gameObject);
    }

    public void EnableShoot()
    {
        shootTextGameObject.SetActive(true);
    }

    public void DisableShoot()
    {
        shootTextGameObject.SetActive(false);
    }
}
