Shader "Custom/Rim Light VF" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
	_Color("Main Color", Color) = (1,1,1,1)
		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimWidth("Rim Width", float) = 0.9
	}
		SubShader{
		Pass{
		Lighting Off
		CGPROGRAM
#pragma vertex vert  
#pragma fragment frag  
#include "UnityCG.cginc"  

		struct appdata
	{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f
	{
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
		fixed3 color : COLOR;
	};

	uniform float4 _MainTex_ST;
	uniform fixed4 _RimColor;
	float _RimWidth;

	v2f vert(appdata_base v) {
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);

		float3 viewDir = normalize(ObjSpaceViewDir(v.vertex));
		float dotProduct = 1 - dot(v.normal, viewDir);

		o.color = smoothstep(1 - _RimWidth, 1.0, dotProduct);
		o.color *= _RimColor;

		o.uv = v.texcoord.xy;
		return o;
	}

	uniform sampler2D _MainTex;
	uniform fixed4 _Color;

	fixed4 frag(v2f i) : COLOR{
		fixed4 texcol = tex2D(_MainTex, i.uv);
	texcol *= _Color;
	texcol.rgb += i.color;
	return texcol;
	}
		ENDCG
	}
	}
}