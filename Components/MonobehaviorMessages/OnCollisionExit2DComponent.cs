using EgoCS.Events.MonobehaviorMessages;
using UnityEngine;

namespace EgoCS.Components.MonobehaviorMessages
{
    [RequireComponent(typeof(EgoComponent))]
    public class OnCollisionExit2DComponent : MonoBehaviour
    {
        EgoComponent egoComponent;

        void Awake()
        {
            egoComponent = GetComponent<EgoComponent>();
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            var e = new CollisionExit2DEvent(egoComponent, collision.gameObject.GetComponent<EgoComponent>(),
                collision);
            EgoEvents<CollisionExit2DEvent>.AddEvent(e);
        }
    }
}