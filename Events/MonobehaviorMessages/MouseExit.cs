using EgoCS.Components;

namespace EgoCS.Events.MonobehaviorMessages
{
    public class MouseExitEvent : EgoEvent
    {
        public readonly EgoComponent egoComponent;

        public MouseExitEvent(EgoComponent egoComponent)
        {
            this.egoComponent = egoComponent;
        }
    }
}