using UnityEngine;
using DG;
using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
public class PointerClickAnimation : MonoBehaviour
{
    [SerializeField] float duration=0.4f;
    [SerializeField] float scale_ratio = 0.5f;
    Vector3 def_scale;
    ParticleSystem Peffect;
    InputHandler input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        def_scale = transform.localScale;
        Peffect = transform.GetChild(0).GetComponent<ParticleSystem>();
        input = InputHandler.Instance;
        input.OnClickHandler += Click;
    }
    bool IsPressedState = false;
    void Click(PressData data)
    {
      IsPressedState=  data.IsPressed ;         
    }
    bool Flag_Normal = true;
    void GoShrink()
    {
        if (Flag_Normal)
        {
            Peffect.Play();
            transform.DOScale(def_scale * scale_ratio, duration).OnComplete(

                () =>
                {
                    Flag_Normal = false;
                }
            );
        }
    }
    void GoNormal()
    {
        // Debug.Log("Normal");
        if (!Flag_Normal)
        {
            transform.DOScale(def_scale, duration / 2).OnComplete(

                () =>
                {
                    Flag_Normal = true;
                }
            ); ;
        }
    }

    void Update()
    {
        if (input.mouse_position != null) transform.position = input.mouse_position;
        if(IsPressedState) 
          {GoShrink(); } else {GoNormal();}
    }
}
