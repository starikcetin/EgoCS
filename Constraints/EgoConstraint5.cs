﻿using EgoCS.Bundle;
using EgoCS.Components;
using EgoCS.Events;
using EgoCS.Util;
using UnityEngine;

namespace EgoCS.Constraints
{
    public class EgoConstraint<C1, C2, C3, C4, C5> : EgoConstraint
        where C1 : Component
        where C2 : Component
        where C3 : Component
        where C4 : Component
        where C5 : Component
    {
        public EgoConstraint()
        {
            _mask[ComponentIDs.Get(typeof(C1))] = true;
            _mask[ComponentIDs.Get(typeof(C2))] = true;
            _mask[ComponentIDs.Get(typeof(C3))] = true;
            _mask[ComponentIDs.Get(typeof(C4))] = true;
            _mask[ComponentIDs.Get(typeof(C5))] = true;
            _mask[ComponentIDs.Get(typeof(EgoComponent))] = true;

            EgoEvents<AddedComponent<C1>>.AddHandler(e => CreateBundles(e.egoComponent));
            EgoEvents<DestroyedComponent<C1>>.AddHandler(e => RemoveBundles(e.egoComponent));

            EgoEvents<AddedComponent<C2>>.AddHandler(e => CreateBundles(e.egoComponent));
            EgoEvents<DestroyedComponent<C2>>.AddHandler(e => RemoveBundles(e.egoComponent));

            EgoEvents<AddedComponent<C3>>.AddHandler(e => CreateBundles(e.egoComponent));
            EgoEvents<DestroyedComponent<C3>>.AddHandler(e => RemoveBundles(e.egoComponent));

            EgoEvents<AddedComponent<C4>>.AddHandler(e => CreateBundles(e.egoComponent));
            EgoEvents<DestroyedComponent<C4>>.AddHandler(e => RemoveBundles(e.egoComponent));

            EgoEvents<AddedComponent<C5>>.AddHandler(e => CreateBundles(e.egoComponent));
            EgoEvents<DestroyedComponent<C5>>.AddHandler(e => RemoveBundles(e.egoComponent));
        }

        protected override EgoBundle CreateBundle(EgoComponent egoComponent)
        {
            return new EgoBundle<C1, C2, C3, C4, C5>(
                egoComponent.GetComponent<C1>(),
                egoComponent.GetComponent<C2>(),
                egoComponent.GetComponent<C3>(),
                egoComponent.GetComponent<C4>(),
                egoComponent.GetComponent<C5>()
            );
        }

        public delegate void ForEachGameObjectDelegate(
            EgoComponent egoComponent,
            C1 component1,
            C2 component2,
            C3 component3,
            C4 component4,
            C5 component5
        );

        public void ForEachGameObject(ForEachGameObjectDelegate callback)
        {
            var lookup = GetLookup(rootBundles);
            foreach (var kvp in lookup)
            {
                currentEgoComponent = kvp.Key;
                var bundle = kvp.Value as EgoBundle<C1, C2, C3, C4, C5>;
                callback(
                    currentEgoComponent,
                    bundle.component1,
                    bundle.component2,
                    bundle.component3,
                    bundle.component4,
                    bundle.component5
                );
            }
        }
    }
}