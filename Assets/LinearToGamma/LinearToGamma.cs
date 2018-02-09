using UnityEngine;
using UnityEngine.XR;

namespace Demonixis.Effects
{
    [ExecuteInEditMode]
    public class LinearToGamma : MonoBehaviour
    {
        private Material m_Material = null;
        private bool m_Supported = false;

        [SerializeField]
        private Shader m_Shader = null;

#if UNITY_EDITOR
        [SerializeField]
        private bool m_PreviewCorrection = false;
#endif

        private void Start()
        {
#if UNITY_WSA
            if (!XRSettings.enabled)
                enabled = false;
#else
            enabled = false;
#endif
        }

        private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
        {
            if (m_Material == null)
            {
                m_Material = new Material(m_Shader);
                m_Supported = m_Shader.isSupported;
            }

            if (m_Material != null && m_Supported)
            {
#if UNITY_EDITOR
                if (!UnityEditor.EditorApplication.isPlaying && !m_PreviewCorrection)
                {
                    Graphics.Blit(sourceTexture, destTexture);
                    return;
                }
#endif
                Graphics.Blit(sourceTexture, destTexture, m_Material);
            }
            else
                Graphics.Blit(sourceTexture, destTexture);
        }
    }
}