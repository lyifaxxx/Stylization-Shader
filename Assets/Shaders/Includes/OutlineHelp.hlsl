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
	float2 sobel = 0;
	[unroll] for (int i = 0; i < 9; i++) {
		float depth = SHADERGRAPH_SAMPLE_SCENE_DEPTH(uv + sobelSamplePoints[i] * Thickness);
		sobel += depth * float2(sobelKernelX[i], sobelKernelY[i]);
	}

	Out = length(sobel);
}