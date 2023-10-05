using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponents : MonoBehaviour
{
    public string scriptToAdd = "ObjectControll";
    public bool win = false;

    public static AddComponents instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (gameObject != null && scriptToAdd != null)
        {
            Transform[] children = gameObject.GetComponentsInChildren<Transform>(true);
            System.Type scriptType = System.Type.GetType(scriptToAdd);

            foreach (Transform child in children)
            {
                if (child != gameObject.transform) 
                {
                    MonoBehaviour newScript = child.gameObject.AddComponent(scriptType) as MonoBehaviour;

                    Renderer childRenderer = child.gameObject.GetComponent<Renderer>();
                    if (childRenderer != null)
                    {
                        BoxCollider2D collider2D = child.gameObject.AddComponent<BoxCollider2D>();
                        collider2D.size = new Vector2(childRenderer.bounds.size.x, childRenderer.bounds.size.y * 0.9f);
                    }
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (transform.childCount == 0)
        {
            win = true;
            CameraMove.instance.canMoveUp = true;
            DisableScript();
        }
    }

    private void DisableScript()
    {
        enabled = false;
    }
}
