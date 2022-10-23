Shader "Custom/agua" {
	Properties {
		_Color("Main Color", Color)=(0,0,0,1)
        _MainTex ("Base (RGB) Transparency (A)", 2D) = "white" {}
		_QOffset_a1 ("Offset3", Vector) = (0,0,0,0)
		_Dist ("Distance", Float) = 20.0
		_QOffset_a2 ("Offset2", Vector) = (0,0,0,0)
	}
	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		LOD 200
		Alphatest Greater 0
		Lighting off
		//UsePass "Transparent/Diffuse"
		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"
			
			  
            uniform sampler2D _MainTex;
            uniform sampler2D _MainTex2;
                        
			float4 _QOffset_a1;
			float _Dist;
			float4 _QOffset_a2;
			
			struct v2f {
			    float4 pos : POSITION;
			    float2 uv : TEXCOORD0;
			};

			v2f vert (appdata_base v)
			{
			    v2f o;
			    float4 vPos = mul (UNITY_MATRIX_MV, v.vertex);
			    float zOff = vPos.z/_Dist;
			    vPos += _QOffset_a1*zOff*zOff;
			    o.pos = mul (UNITY_MATRIX_P, vPos);
			    o.uv = v.texcoord;
			    o.uv = MultiplyUV (UNITY_MATRIX_TEXTURE0, v.texcoord);
			    o.uv += _QOffset_a2;
			    return o;
			}

			half4 frag (v2f i) : COLOR
			{
			    half4 col = tex2D(_MainTex, i.uv.xy);
			    return col;
			} 
			ENDCG  
		} 
		//UsePass "Transparent/Diffuse"
	}
	FallBack "Diffuse"
}
