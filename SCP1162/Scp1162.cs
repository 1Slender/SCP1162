
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace SCP1162
{
    [CustomItem(ItemType.Coin)]
    public class Scp1162 : CustomItem
    {
        public override uint Id { get; set; } = 200;
        public override string Name { get; set; } = "Scp1162";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 5;
        public override SpawnProperties SpawnProperties { get; set; }

        private System.Random random = new System.Random();

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
            Log.Debug(ev.Player);
            ev.IsAllowed = false;
            Log.Debug(ev.IsAllowed);

            if (ev.Player.CurrentItem == null)
            {
                Log.Debug(ev.Player.CurrentItem);
                ev.Player.EnableEffect(Exiled.API.Enums.EffectType.SeveredHands);
            }
            else
            {
                Dictionary<ItemType, float>.Enumerator listItems = Main.Plugin.Config.ItemСhances.GetEnumerator();
                ev.Player.CurrentItem.Destroy();
                Log.Debug("ev.Player.CurrentItem.Destroy");
                if (Chance(Main.Plugin.Config.RandomnessMultiplier))
                {
                    while (listItems.MoveNext())
                    {
                        if (Chance(listItems.Current.Value))
                        {
                            ev.Player.AddItem(listItems.Current.Key);
                            break;
                        }
                    }
                }
                else if (Chance(Main.Plugin.Config.GrenadeSurprise))
                {
                    Timing.RunCoroutine(SpawnActiveGrenadeHE(position: ev.Pickup.Position, col: random.Next(Main.Plugin.Config.MaxQuantityPomegranate), fuseTime: random.Next(3, 6)));
                }

                Log.Debug($"ev.Player.AddItem: {listItems.Current.Key}");
            }

            base.OnPickingUp(ev);
        }
        private bool Chance(double chan)
        {
            if (random.NextDouble() > chan)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private static IEnumerator<float> SpawnActiveGrenadeHE(Vector3 position, int col = 1, float fuseTime = 5f)
        {
            ExplosiveGrenade grenade;

            yield return Timing.WaitForSeconds(1f);

            for (int i = 0; i < col; i++)
            {
                grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);
                grenade.FuseTime = fuseTime;
                grenade.SpawnActive(position);
                yield return Timing.WaitForSeconds(0.1f);
            }
        }
    }
}