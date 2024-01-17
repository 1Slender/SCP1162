
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using System;


namespace SCP1162
{
    [CustomItem(ItemType.Medkit)]
    public class Scp1162 : CustomItem
    {
        public override uint Id { get; set; } = 100;
        public override string Name { get; set; } = "Scp1162";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 5;
        public override SpawnProperties SpawnProperties { get; set; }

        private Random random = new Random();

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
        }

        protected override void OnPickingUp(PickingUpItemEventArgs ev)
        {
            if (ev.Player.CurrentItem == null)
            {
                ev.Player.EnableEffect(Exiled.API.Enums.EffectType.SeveredHands);
            }
            else
            {
                ev.Player.CurrentItem.Destroy();
                ev.Player.AddItem((ItemType)random.Next(51));
            }

            ev.IsAllowed = false;
            base.OnPickingUp(ev);
        }
    }
}