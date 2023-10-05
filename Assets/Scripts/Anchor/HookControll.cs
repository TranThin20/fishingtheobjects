using Spine;
using Spine.Unity;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class HookControll : MonoBehaviour
{
    private bool isMovingHorizontally = false;
    private bool isMovingVertically = false;
    private Vector2 targetPosition;
    private float moveSpeed = 3f;
    public GameObject hookedObject;
    SkeletonAnimation skeleton;
    private Vector3 centerPosition;
    public static HookControll instance;
    public bool isSelectItem = false;
    private bool isDragg = false;
    [SerializeField] private AudioClip hook;
    [SerializeField] private AudioClip hat;
    [SerializeField] private AudioClip sandal;
    [SerializeField] private AudioClip handbag;
    [SerializeField] private AudioClip watch;
    public TextMeshProUGUI textMeshPro;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        hookedObject = null;
        textMeshPro.text = " ";
        skeleton = GetComponent<SkeletonAnimation>();
        centerPosition = new Vector3( 2, -10, transform.position.z);
    }
    void Update()
    {
        if (isSelectItem) { 
            if (isMovingHorizontally)
            {
                MoveHorizontal();
                skeleton.AnimationState.SetAnimation(0, "Moc gap do Open", true);

            }
            else if (isMovingVertically)
            {
                MoveVertical();
                
            }
            if (hookedObject != null)
            {
                hookedObject.transform.parent = transform;
                isMovingVertically = false;
                //DraggItem();
                if (Mathf.Abs(gameObject.transform.position.y + 10f) < 0.01f)
                {
                    if (!isDragg)
                    {
                        StartCoroutine(DelaytoDragg(0.25f));
                    }
                }
                else
                {
                    DraggItem();
                }
                
                if (transform.position.y >= -2)
                {
                    hookedObject.transform.parent = null;
                    hookedObject.gameObject.SetActive(false);
                    hookedObject = null;
                    isSelectItem = false;
                    textMeshPro.text = " ";
                }
            }
            StartCoroutine(SetHookPosition());
        }
    }
    public void MoveHorizontal()
    {
        Vector2 targetX = new Vector2(targetPosition.x + 2, transform.position.y);
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetX, step);
        SoundManager.instance.PlaySoundLoop(hook, 0.75f);
        if (transform.position.x == targetX.x)
        {
            isMovingHorizontally = false;
            isMovingVertically = true;
        }
    }
    
    public void MoveVertical()
    {
        Vector2 target = new Vector2(transform.position.x, targetPosition.y - 1.75f);
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Draggable") && hookedObject == null)
        {
            isMovingVertically = false;
            skeleton.AnimationState.SetAnimation(0, "Moc gap do Close", false);
            hookedObject = other.gameObject;
            hookedObject.transform.parent = transform;
            SoundManager.instance.StopSound();
            if (hookedObject.name == "hat")
            {
                SoundManager.instance.PlaySoundOnce(hat, 1.0f);
                textMeshPro.text = "Hat";
            }
            else if (hookedObject.name == "sandal")
            {
                SoundManager.instance.PlaySoundOnce(sandal, 1.0f);
                textMeshPro.text = "Sandals";
            }
            else if (hookedObject.name == "watch")
            {
                SoundManager.instance.PlaySoundOnce(watch, 1.0f);
                textMeshPro.text = "Watch";
            }
            else
            {
                SoundManager.instance.PlaySoundOnce(handbag, 1.0f);
                textMeshPro.text = "Handbag";
            }
        }
    }
    private IEnumerator SetHookPosition()
    {
        if(hookedObject == null && !isSelectItem)
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.transform.position = centerPosition;
        }
    }
    private IEnumerator DelaytoDragg(float time)
    {
        isDragg = true;
        yield return new WaitForSeconds(time);
        isDragg = false;
        DraggItem();
    }
    public void DestroyHook()
    {
        gameObject.SetActive(false);
        textMeshPro.text = " ";
    }
    public void DraggItem()
    {
        Vector3 target = new Vector3(transform.position.x, 0, 0);
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
    
    public void MoveToTarget(Vector2 target)
    {
        targetPosition = target;
        isMovingHorizontally = true;
    }
}
