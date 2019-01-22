# WindowsMRLinearToGamma
Windows Mixed Reality & HoloLens (UWP) don't support the Linear Color Space. If you enable it, you'll see that the image in your HMD is darker than the preview on the screen. This is because **the gamma correction is not applied**.

This image effect adds the gamma correction, allowing you to use the Linear color space with your Windows Mixed Reality headset or the HoloLens. The project contains **a single script** or **an extension for the PostProcess Stack V2**.

![Preview](https://github.com/demonixis/WindowsMRLinearToGamma/blob/master/Images/preview.jpg)

You can take a look at the shader, it's very simple, basically it's "just" one line. If you want to learn more about the Linear/Gamma Color Spaces, [please take a look at this link](https://docs.unity3d.com/Manual/LinearLighting.html) and [especially this one](http://filmicworlds.com/blog/linear-space-lighting-i-e-gamma/). 


Be careful to use this image effect have to be the **last** on your camera to work correctly.
Oh and of course it works with Single Pass Stereo Rendering! (Instanced not supported sorry).

## License
This project is licensed under the MIT license.
