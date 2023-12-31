using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public partial class CameraRenderer
{
    static ShaderTagId unlidShaderTagId = new ShaderTagId("SRPDefaultUnlit");
    CullingResults cullingResults;
    ScriptableRenderContext context;
    Camera camera;
    const string bufferName = "Render Camera";
    CommandBuffer buffer = new CommandBuffer
    {
        name = bufferName
    };
    public void Render(ScriptableRenderContext context, Camera camera)
    {
        this.context = context;
        this.camera = camera;
        PrepareBuffer();
        PrepareForSceneWindow();
        if (!Cull())
        {
            return;
        }
        Setup();
        DrawVisibleGeometry();
        DrawUnsupportedShaders();
        DrawGizmos();
        Submit();
    }
    void Setup()
    {
        context.SetupCameraProperties(camera);
        CameraClearFlags flags = camera.clearFlags;
        buffer.ClearRenderTarget(
            flags<=CameraClearFlags.Depth,
            flags == CameraClearFlags.Color,
            flags == CameraClearFlags.Color?
            camera.backgroundColor.linear:Color.clear
            );
        buffer.ClearRenderTarget(true, true, Color.clear);
        buffer.BeginSample(SampleName);
        ExecuteBuffer();
    }
    void Submit()
    {
        buffer.EndSample(SampleName);
        ExecuteBuffer();
        context.Submit();
    }
    void DrawVisibleGeometry()
    {
        var sortingSettings = new SortingSettings(camera)
        {
            criteria = SortingCriteria.CommonOpaque
        };
        var drawingSettings = new DrawingSettings(
            unlidShaderTagId, sortingSettings
            );
        var filteringSettings = new FilteringSettings(RenderQueueRange.opaque);
        context.DrawRenderers(
            cullingResults, ref drawingSettings, ref filteringSettings
            );

        context.DrawSkybox(camera);

        sortingSettings.criteria = SortingCriteria.CommonTransparent;
        drawingSettings.sortingSettings = sortingSettings;
        filteringSettings.renderQueueRange = RenderQueueRange.transparent;
        context.DrawRenderers(
            cullingResults, ref drawingSettings, ref filteringSettings
            );
    }
    void ExecuteBuffer()
    {
        context.ExecuteCommandBuffer(buffer);
        buffer.Clear();
    }
    bool Cull()
    {
        ScriptableCullingParameters p;
        if(camera.TryGetCullingParameters(out p))
        {
            cullingResults = context.Cull(ref p);
            return true;
        }
        return false;
    }
}
