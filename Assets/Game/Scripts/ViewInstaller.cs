using Game.Scripts.UI.Interface;
using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    public class ViewInstaller : MonoInstaller<ViewInstaller>
    {
        public IInteractableDialogView dialogView;
        
        public override void InstallBindings()
        {
            Container.BindInstance(dialogView).AsSingle();
        }
    }
}