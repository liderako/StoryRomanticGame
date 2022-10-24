using System;

namespace RPGBatler.Player
{
    public class CombatAvatar : ACombatAvatar
    {
        private void Awake()
        {
            base.HealthSystem = base.GetComponent<Game.Scripts.HealthSystem.HealthSystem>();
        }

        public override void Death()
        {
        }
    }
}