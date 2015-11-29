﻿using UnityEngine;
using System.Collections.Generic;

public class EgoSystem<C1, C2, C3, C4> : IEgoSystem 
    where C1 : Component
    where C2 : Component
    where C3 : Component
    where C4 : Component
{
    protected BitMask _mask = new BitMask( ComponentIDs.GetCount() );

    protected Dictionary<EgoComponent, EgoBundle<C1, C2, C3, C4>> _bundles = new Dictionary<EgoComponent, EgoBundle<C1, C2, C3, C4>>();
    public Dictionary<EgoComponent, EgoBundle<C1, C2, C3, C4>>.ValueCollection bundles { get { return _bundles.Values; } }

    public EgoSystem()
    {
        _mask[ComponentIDs.Get( typeof( C1 ) )] = true;
        _mask[ComponentIDs.Get( typeof( C2 ) )] = true;
        _mask[ComponentIDs.Get( typeof( C3 ) )] = true;
        _mask[ComponentIDs.Get( typeof( C4 ) )] = true;
        _mask[ComponentIDs.Get( typeof( EgoComponent ) )] = true;
        _mask[ComponentIDs.Get( typeof( Transform ) )] = true;

        // Attach built-in Event Handlers
        EgoEvents<AddedGameObject>.AddHandler( Handle );
        EgoEvents<DestroyedGameObject>.AddHandler( Handle );
        EgoEvents<AddedComponent<C1>>.AddHandler( Handle );
        EgoEvents<AddedComponent<C2>>.AddHandler( Handle );
        EgoEvents<AddedComponent<C3>>.AddHandler( Handle );
        EgoEvents<AddedComponent<C4>>.AddHandler( Handle );
        EgoEvents<DestroyedComponent<C1>>.AddHandler( Handle );
        EgoEvents<DestroyedComponent<C2>>.AddHandler( Handle );
        EgoEvents<DestroyedComponent<C3>>.AddHandler( Handle );
        EgoEvents<DestroyedComponent<C4>>.AddHandler( Handle );
    }

    public void CreateBundles( EgoComponent[] egoComponents )
    {
        foreach( var egoComponent in egoComponents )
        {
            CreateBundle( egoComponent );
        }
    }

    protected void CreateBundle( EgoComponent egoComponent )
    {
        var andMask = new BitMask( egoComponent.mask ).And( _mask );
        if( andMask == _mask )
        {
            var component1 = egoComponent.GetComponent<C1>();
            var component2 = egoComponent.GetComponent<C2>();
            var component3 = egoComponent.GetComponent<C3>();
            var component4 = egoComponent.GetComponent<C4>();
            CreateBundle( egoComponent, component1, component2, component3, component4 );
        }
    }

    protected void CreateBundle( EgoComponent egoComponent, C1 component1, C2 component2, C3 component3, C4 component4 )
    {
        var bundle = new EgoBundle<C1, C2, C3, C4>( egoComponent.transform, component1, component2, component3, component4 );
        _bundles[egoComponent] = bundle;
    }

    protected void RemoveBundle( EgoComponent egoComponent )
    {
        var andMask = new BitMask( egoComponent.mask ).And( _mask );
        if( andMask != _mask )
        {
            _bundles.Remove( egoComponent );
        }
    }

    public virtual void Start() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }

    //
    // Event Handlers
    //

    void Handle( AddedGameObject e )
    {
        CreateBundle( e.egoComponent );
    }

    void Handle( DestroyedGameObject e )
    {
        _bundles.Remove( e.egoComponent );
    }

    void Handle( AddedComponent<C1> e )
    {
        CreateBundle( e.egoComponent );
    }

    void Handle( AddedComponent<C2> e )
    {
        CreateBundle( e.egoComponent );
    }

    void Handle( AddedComponent<C3> e )
    {
        CreateBundle( e.egoComponent );
    }

    void Handle( AddedComponent<C4> e )
    {
        CreateBundle( e.egoComponent );
    }

    void Handle( DestroyedComponent<C1> e )
    {
        // Remove the component from the EgoComponent's mask
        e.egoComponent.mask[ComponentIDs.Get( typeof( C1 ) )] = false;
        RemoveBundle( e.egoComponent );
    }

    void Handle( DestroyedComponent<C2> e )
    {
        // Remove the component from the EgoComponent's mask
        e.egoComponent.mask[ComponentIDs.Get( typeof( C2 ) )] = false;
        RemoveBundle( e.egoComponent );
    }

    void Handle( DestroyedComponent<C3> e )
    {
        // Remove the component from the EgoComponent's mask
        e.egoComponent.mask[ComponentIDs.Get( typeof( C4 ) )] = false;
        RemoveBundle( e.egoComponent );
    }

    void Handle( DestroyedComponent<C4> e )
    {
        // Remove the component from the EgoComponent's mask
        e.egoComponent.mask[ComponentIDs.Get( typeof( C4 ) )] = false;
        RemoveBundle( e.egoComponent );
    }
}
