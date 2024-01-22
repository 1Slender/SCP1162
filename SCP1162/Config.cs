using Exiled.API.Interfaces;
using System.Collections.Generic;

namespace SCP1162
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public float RandomnessMultiplier { get; set; } = 0.1f; // от 0 до 1
        public float GrenadeSurprise { get; set; } = 0.2f; // 0 отключает гранаты
        public int MaxQuantityPomegranate { get; set; } = 30; // 0 отключает гранаты
        public Dictionary<ItemType, float> ItemСhances { get; set; } = new Dictionary<ItemType, float>()
        {
            { ItemType.MicroHID, 0.01f },
            { ItemType.ParticleDisruptor, 0.01f },
            { ItemType.Jailbird, 0.05f },
            { ItemType.AntiSCP207, 0.05f },
            { ItemType.GunFRMG0, 0.05f },
            { ItemType.SCP268, 0.05f },
            { ItemType.GunRevolver, 0.1f },
            { ItemType.SCP018, 0.1f },
            { ItemType.KeycardChaosInsurgency, 0.2f },
            { ItemType.SCP207, 0.2f },
            { ItemType.GunCOM15, 0.25f },
            { ItemType.GunCom45, 0.25f },
            { ItemType.GrenadeFlash, 0.3f },
            { ItemType.SCP500, 0.3f },
            { ItemType.KeycardZoneManager, 0.3f },
            { ItemType.KeycardJanitor, 0.5f},
            { ItemType.Medkit, 0.5f},
            { ItemType.Adrenaline, 0.6f },
            { ItemType.Radio, 0.65f },
            { ItemType.Coin, 0.7f },
            { ItemType.Flashlight, 0.7f },
        };
    }
}
