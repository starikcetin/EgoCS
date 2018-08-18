using EgoCS.Events.MonobehaviorMessages;
using UnityEngine;

namespace EgoCS.Components.MonobehaviorMessages
{
    [RequireComponent(typeof(EgoComponent))]
    public class OnCollisionStayComponent : MonoBehaviour
    {
        EgoComponent egoComponent;

        void Awake()
        {
            egoComponent = GetComponent<EgoComponent>();
        }

        void OnCollisionStay(Collision collision)
        {
            var e = new CollisionStayEvent(egoComponent, collision.gameObject.GetComponent<EgoComponent>(), collision);
            EgoEvents<CollisionStayEvent>.AddEvent(e);
        }
    }
}