using EgoCS.Events.MonobehaviorMessages;
using UnityEngine;

namespace EgoCS.Components.MonobehaviorMessages
{
    [RequireComponent( typeof( EgoComponent ) ) ]
    public class OnTriggerExit2DComponent : MonoBehaviour
    {
        EgoComponent egoComponent;

        void Awake()
        {
            egoComponent = GetComponent<EgoComponent>();
        }

        void OnTriggerExit2D( Collider2D collider2d )
        {
            var e = new TriggerExit2DEvent( egoComponent, collider2d.gameObject.GetComponent<EgoComponent>(), collider2d );
            EgoEvents<TriggerExit2DEvent>.AddEvent( e );
        }
    }
}
