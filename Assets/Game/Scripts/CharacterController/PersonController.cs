namespace Invector.vCharacterController
{
    public class PersonController : vThirdPersonController
    {
        private const string attackAnimation = "Attack";
        
        public void ControllAttack()
        {
            animator.SetTrigger(attackAnimation);
        }
    }
}