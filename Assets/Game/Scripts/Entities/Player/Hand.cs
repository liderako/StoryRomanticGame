namespace RPGBatler.Player
{
    using UnityEngine;

    public class Hand : Weapon
    {
        public override ResultAttack Attack()
        {
            foreach (Collider collider in Physics.OverlapSphere(base.weaponGameObject.transform.position, base.weaponGameObject.GetComponent<SphereCollider>().radius))
            {
                ACombatAvatar avatar;
                if (collider.TryGetComponent<ACombatAvatar>(out avatar) && (collider.gameObject.layer != base.gameObject.layer))
                {
                    avatar.ReceiveHit(base.Damage);
                    return new ResultAttack { 
                        isHit = true,
                        isEnemyDead = avatar.IsDead(),
                        typeEnemy = collider.GetComponent<ACombatAvatar>().typeUnit
                    };
                }
            }
            return new ResultAttack
            {
                isHit = false
            };
        }

        public override AudioClip GetAudioClip(ResultAttack result) => 
            !result.isHit ? base.MissAudioClips[Random.Range(0, base.MissAudioClips.Count)] : base.HitsAudioClips[Random.Range(0, base.HitsAudioClips.Count)];
    }
}