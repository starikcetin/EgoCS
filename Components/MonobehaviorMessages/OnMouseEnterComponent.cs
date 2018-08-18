using EgoCS.Events.MonobehaviorMessages;
using UnityEngine;

namespace EgoCS.Components.MonobehaviorMessages
{
    [DisallowMultipleComponent]
    public class OnMouseEnterComponent : MonoBehaviour
    {
        EgoComponent egoComponent;

        void Awake()
        {
            egoComponent = GetComponent<EgoComponent>();
        }

        void OnMouseEnter()
        {
            var onMouseDownEvent = new MouseEnterEvent(egoComponent);
            EgoEvents<MouseEnterEvent>.AddEvent(onMouseDownEvent);
        }
    }
}