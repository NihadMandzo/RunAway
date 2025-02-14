using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public Animator _animator;
    public int levelNo;

    public GameObject doors;
    // Start is called before the first frame update
    void Start()
    {
        doors.SetActive(false);
        _animator.SetBool("open", false);  
    }

    // Update is called once per frame
    void Update()
    {
    }

    public async void OpenDoor()
    {
        _animator.SetBool("open", true);
        await Task.Delay(100);
        doors.SetActive(true);
        NextLevel();
    }

    async void NextLevel()
    {
        await Task.Delay(4500);
        SceneManager.LoadSceneAsync($"Level{levelNo}");
    }
}
