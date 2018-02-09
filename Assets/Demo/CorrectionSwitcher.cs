using Demonixis.Effects;
using UnityEngine;

public sealed class CorrectionSwitcher : MonoBehaviour
{
    private LinearToGamma m_LinearToGamma;

    private void Start()
    {
        m_LinearToGamma = Camera.main.GetComponent<LinearToGamma>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            m_LinearToGamma.enabled = !m_LinearToGamma.enabled;
    }
}
