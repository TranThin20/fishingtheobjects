using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public static WinManager instance;
    [SerializeField] private GameObject winBackground;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (AddComponents.instance.win && !winBackground.activeInHierarchy)
        {
            StartCoroutine(SetWinGame(2f));
        }
    }

    public IEnumerator SetWinGame(float Delaytime)
    {
        yield return new WaitForSeconds(Delaytime);
        HookControll.instance.DestroyHook();
        winBackground.SetActive(true);

    }
}
