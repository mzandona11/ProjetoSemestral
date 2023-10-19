using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

}
