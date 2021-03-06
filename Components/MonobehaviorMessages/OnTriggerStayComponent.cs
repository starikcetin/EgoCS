﻿using EgoCS.Events.MonobehaviorMessages;
using UnityEngine;

namespace EgoCS.Components.MonobehaviorMessages
{
    [RequireComponent(typeof(EgoComponent))]
    public class OnTriggerStayComponent : MonoBehaviour
    {
        EgoComponent egoComponent;

        void Awake()
        {
            egoComponent = GetComponent<EgoComponent>();
        }

        void OnTriggerStay(Collider collider)
        {
            var e = new TriggerStayEvent(egoComponent, collider.gameObject.GetComponent<EgoComponent>(), collider);
            EgoEvents<TriggerStayEvent>.AddEvent(e);
        }
    }
}