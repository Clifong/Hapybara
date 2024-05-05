using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationHelper : MonoBehaviour
{
    public UnityEvent OnAnimationStartEvent;
    public UnityEvent OnAnimationEndEvent; 
    
    public void OnAnimationStart() {
        OnAnimationStartEvent?.Invoke();
    }

    public void OnAnimationEnd() {
        OnAnimationEndEvent?.Invoke();
    }
}
