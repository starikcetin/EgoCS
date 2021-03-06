﻿using EgoCS.Events.MonobehaviorMessages;
using UnityEngine;

namespace EgoCS.Components.MonobehaviorMessages
{
    [RequireComponent(typeof(EgoComponent))]
    public class OnTriggerExitComponent : MonoBehaviour
    {
        EgoComponent egoComponent;

        void Awake()
        {
            egoComponent = GetComponent<EgoComponent>();
        }

        void OnTriggerExit(Collider collider)
        {
            var e = new TriggerExitEvent(egoComponent, collider.gameObject.GetComponent<EgoComponent>(), collider);
            EgoEvents<TriggerExitEvent>.AddEvent(e);
        }
    }
}