using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnding : MonoBehaviour
{
    public static CatEnding instance;

    private void Awake()
    {
        instance = this;
    }
    public IEnumerator MoveRight()
    {
        float startTime = Time.time;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = new Vector3(12, transform.position.y, transform.position.z);

        while (Time.time - startTime < 4f)
        {
            float t = (Time.time - startTime) / 4f;

            transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null;
        }
        transform.position = endPosition;

    }
    public void Update()
    {
        if (CameraMove.instance.canEnd)
        {
            StartCoroutine(MoveRight());
            if(transform.position.x >= 11.5f)
            {
                StartCoroutine(QuitGame());
                CameraMove.instance.canEnd = false;                
            }
        }
    }
    private IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("quitgame");
        Application.Quit();

    }

}
