﻿using EgoCS.Components;
using UnityEngine;

namespace EgoCS.Events.MonobehaviorMessages
{
    public class TriggerEnter2DEvent : EgoEvent
    {
        public readonly EgoComponent egoComponent1;
        public readonly EgoComponent egoComponent2;
        public readonly Collider2D collider;

        public TriggerEnter2DEvent(EgoComponent egoComponent1, EgoComponent egoComponent2, Collider2D collider)
        {
            this.egoComponent1 = egoComponent1;
            this.egoComponent2 = egoComponent2;
            this.collider = collider;
        }
    }
}