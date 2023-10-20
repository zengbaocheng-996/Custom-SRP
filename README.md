# Custom-SRP
Custom Scriptable Render Pipeline

| Index | Content                | Detail                                                       |
| ----- | ---------------------- | ------------------------------------------------------------ |
| 01    | Custom Render Pipeline | Create a render pipeline asset and instance<br />Render a camera's view<br />Perform culling, filtering, and sorting<br />Separate opaque, transparent, and invalid passes<br />Work with more than one camera |
| 02    | Draw Calls             | Write a HLSL shader<br />Support the SRP batcher, GPU instancing, and dynamic batching<br />Configure material properties per object and draw many at random<br />Create transparent and cutout materials |
| 03    | Directional Lights     | Use normal vectors to calculate lighting<br />Support up to four directional lights<br />Apply a BRDF<br />Make lit transparent materials<br />Create a custom shader GUI with presents |
| 04    | Directional Shadows    | Render and sample shadow maps<br />Support multiple shadowed directional lights<br />Use cascaded shadow maps<br />Blend, fade, and filter shadows |
| 05    | Baked Light            | Bake static global illumination<br />Sample light maps, probes, and LPPVs<br />Create a meta pass<br />Support emissive surfaces |
| 06    | Shadow Masks           | Bake static shadows<br />Combine realtime lighting with baked shadows<br />Mix realtime and baked shadows<br />Support up to four shadow mask lights |
| 07    | LOD and Reflections    | Use LOD Groups<br />Cross-Fade between LOD levels<br />Reflect the environment by sampling a reflection probe<br />Support optional Fresnel reflections |
| 08    | Complex Maps           | Create a circuitry-like material<br />Add support for a MODS mask map<br />Introduce a secondary detail map<br />Perform tangent-space normal mapping |
| 09    | Point and Spot Lights  | Support more light types than only directional<br />Include realtime point and spot lights<br />Bake lighting and shadows for point and spot lights<br />Limit rendering to max 8 other lights per object |
| 10    | Point and Spot Shadows | Mix baked and realtime shadows for point and spot lights<br />Add a second shadow atlas<br />Render and sample shadows with a perspective projection<br />Use custom cube maps |
| 11    | Post Processing        | Create a simple post-FX stack<br />Alter the rendered image<br />Perform post-processing when needed<br />Make an artistic bloom effect |
| 12    | HDR                    | Render to HDR textures<br />Reduce bloom fireflies<br />Add scattering bloom<br />Support multiple tone mapping modes |
| 13    | Color Grading          | Perform color grading<br />Duplicate multiple URP/HDRP color grading tools<br />Use a color LUT |
| 14    | Multiple Cameras       | Render multiple cameras with different post FX settings<br />Layer cameras with custom blending<br />Support rendering layer masks<br />Mask lights per camera |
| 15    | Particles              | Support flipbook, near fade, soft, and distortion particles<br />Determine fragment depth, for orthographic and perspective projections<br />Copy and sample the color and depth buffers |
| 16    | Render Scale           | Adjust the render scale via a slider<br />Support different render scales per camera<br />Rescale to the final target after all post FX |
| 17    | FXAA                   | Calculate and store pixel luma, or fall back to green<br />Find and blend high-contrast pixels<br />Detect and smooth long edges<br />Combine FXAA and render scale |
