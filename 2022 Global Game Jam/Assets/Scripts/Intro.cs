using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject art;
    public GameObject story;


    // Start is called before the first frame update
    void Start()
    {
        StoryStarts();
    }


    public void StoryStarts()
    {
       // story.SetActive(true);
    }

    public void StoryEnds()
    {
        story.SetActive(false);
    }

}
