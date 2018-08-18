using EgoCS.Events.MonobehaviorMessages;
using UnityEngine;

namespace EgoCS.Components.MonobehaviorMessages
{
    [DisallowMultipleComponent]
    public class OnMouseDragComponent : MonoBehaviour
    {
        EgoComponent egoComponent;

        void Awake()
        {
            egoComponent = GetComponent<EgoComponent>();
        }

        void OnMouseDrag()
        {
            var onMouseDownEvent = new MouseDragEvent(egoComponent);
            EgoEvents<MouseDragEvent>.AddEvent(onMouseDownEvent);
        }
    }
}