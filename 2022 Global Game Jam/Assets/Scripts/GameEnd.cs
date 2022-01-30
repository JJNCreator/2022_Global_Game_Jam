using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;
    public Health healthScript;

    private bool isLoadingMainMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        win.SetActive(false);
        lose.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
       if (GameManager.Instance.cagesFreedCount >= GameManager.Instance.cagesToBeFreed)
       {
            win.SetActive(true);
            if(!isLoadingMainMenu)
            {
                StartCoroutine(LoadMainMenu());
            }
       }

        if (healthScript.Dead)
        {
            lose.SetActive(true);
            Time.timeScale = 0;
            if (!isLoadingMainMenu)
            {
                StartCoroutine(LoadMainMenu());
            }
        }
    }
    private IEnumerator LoadMainMenu()
    {
        isLoadingMainMenu = true;
        yield return new WaitForSecondsRealtime(4f);

        AsyncOperation aOperation = SceneManager.LoadSceneAsync(0);

        while(!aOperation.isDone)
        {
            yield return null;
        }
    }
}
