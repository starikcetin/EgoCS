﻿using EgoCS.Bundle;
using EgoCS.Components;
using EgoCS.Events;
using EgoCS.Util;
using UnityEngine;

namespace EgoCS.Constraints
{
    public class EgoParentConstraint<C1, C2, CS1> : EgoParentConstraint
        where C1 : Component
        where C2 : Component
        where CS1 : EgoConstraint, new()
    {
        public EgoParentConstraint()
        {
            childConstraint = new CS1();
            childConstraint.parentConstraint = this;

            _mask[ComponentIDs.Get(typeof(C1))] = true;
            _mask[ComponentIDs.Get(typeof(C2))] = true;
            _mask[ComponentIDs.Get(typeof(EgoComponent))] = true;

            EgoEvents<AddedComponent<C1>>.AddHandler(e => CreateBundles(e.egoComponent));
            EgoEvents<DestroyedComponent<C1>>.AddHandler(e => RemoveBundles(e.egoComponent));

            EgoEvents<AddedComponent<C2>>.AddHandler(e => CreateBundles(e.egoComponent));
            EgoEvents<DestroyedComponent<C2>>.AddHandler(e => RemoveBundles(e.egoComponent));

            EgoEvents<SetParent>.AddHandler(e => SetParent(e.parent, e.child, e.worldPositionStays));
        }

        protected override EgoBundle CreateBundle(EgoComponent egoComponent)
        {
            return new EgoBundle<C1, C2>(
                egoComponent.GetComponent<C1>(),
                egoComponent.GetComponent<C2>()
            );
        }

        public delegate void ForEachGameObjectWithChildrentDelegate(
            EgoComponent egoComponent,
            C1 component1,
            C2 component2,
            CS1 childConstraint
        );

        public void ForEachGameObject(ForEachGameObjectWithChildrentDelegate callback)
        {
            var lookup = GetLookup(rootBundles);
            foreach (var kvp in lookup)
            {
                currentEgoComponent = kvp.Key;
                var bundle = kvp.Value as EgoBundle<C1, C2>;
                callback(
                    currentEgoComponent,
                    bundle.component1,
                    bundle.component2,
                    childConstraint as CS1
                );
            }
        }
    }
}