using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Game.UI
{
    public class BlurControl : MonoBehaviour
    {
        private PostProcessVolume m_Volume;
        private DepthOfField dof;
        public void BlurGameScreen()
        {
            dof =  ScriptableObject.CreateInstance<DepthOfField>();
            dof.enabled.Override(true);
            
            //add dof properties
            dof.focusDistance.Override(0.1f);
            dof.aperture.Override(0.1f);
            dof.focalLength.Override(300);
            dof.kernelSize.Override(KernelSize.VeryLarge);

            m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100, dof);

        }

        private void OnDestroy()
        {
            RuntimeUtilities.DestroyVolume(m_Volume, true, true);
        }
    }
}