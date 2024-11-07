SAMPLER(sampler_point_clamp);

void GetDepth_float(float2 uv, out float Depth)
{
    Depth = SHADERGRAPH_SAMPLE_SCENE_DEPTH(uv);
}


void GetNormal_float(float2 uv, out float3 Normal)
{
    Normal = SAMPLE_TEXTURE2D(_NormalsBuffer, sampler_point_clamp, uv).rgb;
}

static float2 sobelSamplePoints[9] = {
	float2(-1, 1), float2(0, 1), float2(1, 1),
	float2(-1, 0), float2(0, 0), float2(1, 1),
	float2(-1, -1), float2(0, -1), float2(1, -1)
};

static float sobelKernelX[9] = {
	1, 0, -1,
	2, 0, -2,
	1, 0, -1
};

static float sobelKernelY[9] = {
	1, 2, 1,
	0, 0, 0,
	-1, -2, -1
};

void sobel_find_edges_float(float2 uv, float Thickness, out float Out)
{
    float2 sobelDepth = 0;
    float2 sobelNormal = 0;

    float3 centerNormal;
    GetNormal_float(uv, centerNormal);

    [unroll] for (int i = 0; i < 9; i++) {
        // Depth-based Sobel filter
        float depth;
        GetDepth_float(uv + sobelSamplePoints[i]* Thickness, depth); //SHADERGRAPH_SAMPLE_SCENE_DEPTH(uv + sobelSamplePoints[i] * Thickness);
        sobelDepth += depth * float2(sobelKernelX[i], sobelKernelY[i]);

        // Normal-based Sobel filter
        float3 sampleNormal;
        GetNormal_float(uv + sobelSamplePoints[i] * Thickness, sampleNormal);
        float3 normalDifference = centerNormal - sampleNormal;
        float normalMagnitude = length(normalDifference);
        sobelNormal += normalMagnitude * float2(sobelKernelX[i], sobelKernelY[i]);
    }

    // Combine depth and normal-based edge detection
    float edgeStrengthDepth = length(sobelDepth);
    float edgeStrengthNormal = length(sobelNormal);
    Out = edgeStrengthDepth + edgeStrengthNormal; // Combine strengths
}