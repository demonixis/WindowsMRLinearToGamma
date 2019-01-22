﻿using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.XR;

namespace Demonixis.Toolbox.Graphics
{
	[Serializable]
	[PostProcess(typeof(GammaCorrectionRenderer), PostProcessEvent.AfterStack, "Demonixis/GammaCorrection")]
	public class GammaCorrection : PostProcessEffectSettings
	{
		public BoolParameter previewCorrection = new BoolParameter() { value = false };

		public override bool IsEnabledAndSupported(PostProcessRenderContext context)
		{
			var result = base.IsEnabledAndSupported(context);
			result = XRSettings.enabled;

	#if UNITY_WSA
			result = XRSettings.enabled;
	#endif

	#if UNITY_EDITOR
			if (!UnityEditor.EditorApplication.isPlaying)
				result = false;

			result |= previewCorrection;
	#endif
			return result;
		}
	}

	public sealed class GammaCorrectionRenderer : PostProcessEffectRenderer<GammaCorrection>
	{
		public override void Render(PostProcessRenderContext context)
		{
			var sheet = context.propertySheets.Get(Shader.Find("Hidden/PostProcessing/Extensions/GammaCorrection"));
			context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
		}
	}
}