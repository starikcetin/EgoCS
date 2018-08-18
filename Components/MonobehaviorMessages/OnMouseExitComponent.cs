using EgoCS.Events.MonobehaviorMessages;
using UnityEngine;

namespace EgoCS.Components.MonobehaviorMessages
{
    [DisallowMultipleComponent]
    public class OnMouseExitComponent : MonoBehaviour
    {
        EgoComponent egoComponent;

        void Awake()
        {
            egoComponent = GetComponent<EgoComponent>();
        }

        void OnMouseExit()
        {
            var onMouseDownEvent = new MouseExitEvent(egoComponent);
            EgoEvents<MouseExitEvent>.AddEvent(onMouseDownEvent);
        }
    }
}