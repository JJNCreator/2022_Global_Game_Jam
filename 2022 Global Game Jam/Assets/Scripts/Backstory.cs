using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backstory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimationSequence());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator AnimationSequence()
    {
        yield return new WaitForSeconds(13f);

        AsyncOperation aOperation = SceneManager.LoadSceneAsync(2);

        while(!aOperation.isDone)
        {
            yield return null;
        }
    }
}
