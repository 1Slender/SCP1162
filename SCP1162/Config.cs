using Exiled.API.Interfaces;
using System.Collections.Generic;

namespace SCP1162
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public Scp1162 scp1162 { get; set; } = null;
        public float RandomnessMultiplier { get; set; } = 0.05f; // от 0 до 1
        public float GrenadeSurprise { get; set; } = 0.2f; // 0 отключает гранаты
        public int MaxQuantityPomegranate { get; set; } = 30; // 0 отключает гранаты
        public Dictionary<ItemType, float> ItemСhances { get; set; } = new Dictionary<ItemType, float>()
        {
            { ItemType.MicroHID, 0.005f },
            { ItemType.ParticleDisruptor, 0.005f },
            { ItemType.Jailbird, 0.01f },
            { ItemType.AntiSCP207, 0.02f },
            { ItemType.GunFRMG0, 0.02f },
            { ItemType.SCP268, 0.05f },
            { ItemType.GunRevolver, 0.05f },
            { ItemType.SCP018, 0.08f },
            { ItemType.KeycardChaosInsurgency, 0.08f },
            { ItemType.SCP207, 0.08f },
            { ItemType.GunCom45, 0.1f },
            { ItemType.GrenadeFlash, 0.1f },
            { ItemType.SCP500, 0.1f },
            { ItemType.KeycardZoneManager, 0.2f },
            { ItemType.GunCOM15, 0.2f },
            { ItemType.KeycardJanitor, 0.4f},
            { ItemType.Medkit, 0.4f},
            { ItemType.Adrenaline, 0.5f },
            { ItemType.Radio, 0.5f },
            { ItemType.Coin, 0.5f },
            { ItemType.Flashlight, 0.5f },
        };
    }
}
