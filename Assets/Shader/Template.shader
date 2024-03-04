// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Template"
{
   Properties{
		_Color("Color", Color) = (1, 1, 1, 0.5)
		// user-specified RGBA color including opacity
	}
		SubShader{
		Tags{ "Queue" = "Transparent" }
		// draw after all opaque geometry has been drawn
		Pass{
		ZWrite Off // don't occlude other objects
		Blend SrcAlpha OneMinusSrcAlpha // standard alpha blending
		//==float4 result = fragment_output.aaaa * fragment_output + (float4(1.0, 1.0, 1.0, 1.0) - fragment_output.aaaa) * pixel_color;
 
		CGPROGRAM
 
#pragma vertex vert  
#pragma fragment frag 
 
#include "UnityCG.cginc"
 
		uniform float4 _Color; // define shader property for shaders
 
	struct vertexInput {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};
	struct vertexOutput {
		float4 pos : SV_POSITION;
		float3 normal : TEXCOORD;
		float3 viewDir : TEXCOORD1;
	};
 
	vertexOutput vert(vertexInput input)
	{
		vertexOutput output;
 
		float4x4 modelMatrix = unity_ObjectToWorld;//ģ�;���
		float4x4 modelMatrixInverse = unity_WorldToObject;//ģ�͵������
 
		output.normal = normalize(
			mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
		output.viewDir = normalize(_WorldSpaceCameraPos
			- mul(modelMatrix, input.vertex).xyz);
 
		output.pos = UnityObjectToClipPos(input.vertex);
		return output;
	}
 
	float4 frag(vertexOutput input) : COLOR
	{
		//Ϊʲô�ڶ�����ɫ���������Ѿ���������������һ���ˣ��ڴ�Ϊʲô��Ҫ��һ����
		//1>���ȣ��ڶ�������й�һ������ΪҪ���κ�����֮��ķ����Ͻ��л����ٵĲ�ֵ
		//2>�ڴ˴��ֽ���һ�β�ֵ����Ϊ������Ĳ�ֵ���̻Ὣ��һ����ֵŤ��
		float3 normalDirection = normalize(input.normal);
		float3 viewDirection = normalize(input.viewDir);
 
		float newOpacity = min(1.0, _Color.a
			/ abs(dot(viewDirection, normalDirection)));
		return float4(_Color.rgb, newOpacity);
	}
 
		ENDCG
	}
	}
}
