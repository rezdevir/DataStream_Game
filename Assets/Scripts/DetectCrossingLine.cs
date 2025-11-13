using UnityEngine;

public class DetectCrossingLine : MonoBehaviour
{
    [SerializeField] GameObject cross_section_obj;
    [SerializeField] Transform offset_positon;
    [SerializeField] Vector2 offset = new Vector2(0.1f, 0.1f);
    [SerializeField] float RottationSpeed=100;
    [SerializeField] DrawLineHandler LineHandler;
    InputHandler input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = InputHandler.Instance;
        // StartCoroutine
    }

    void FixedUpdate()
    {
            
        float target = LineHandler.GetMovementAngle();

        if (!float.IsNaN(target))
        {        float current = transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(current, target, RottationSpeed * Time.fixedDeltaTime);
      
              transform.rotation = Quaternion.Euler(0, 0, newAngle);
            // transform.eulerAngles = new Vector3(0, 0, angle);
            RaycastHit2D hit = Physics2D.Raycast(offset_positon.position, Vector2.zero, 0f, LayerMask.GetMask("line"));

        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);
            Instantiate(cross_section_obj, offset_positon.position , transform.rotation);

        }
        }
    }
    
   
}
