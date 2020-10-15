// Upgrade NOTE: replaced '_Projector' with 'unity_Projector'
// Upgrade NOTE: replaced '_ProjectorClip' with 'unity_ProjectorClip'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Projector/Multiply" {
	Properties{
		_ShadowTex("Cookie", 2D) = "gray" {}
		_FalloffTex("FallOff", 2D) = "white" {}

		_SpecColor("Specular Material Color", Color) = (1,1,1,1)
		


	}
		Subshader{
			Tags {"Queue" = "Transparent"}
			
			Pass {

			ColorMask RGB
			Blend DstColor Zero
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
	
			#include "UnityCG.cginc"

			#pragma multi_compile_fog

			struct v2f {
				float4 pos : SV_POSITION;
				float4 uvShadow : TEXCOORD0;
				float4 uvFalloff : TEXCOORD1;

				UNITY_FOG_COORDS(3)
			};

			float4x4 unity_Projector;
			float4x4 unity_ProjectorClip;
			float4 _ShadowTex_ST;
			sampler2D _ShadowTex;
			sampler2D _FalloffTex;
			
			float4 unity_fogParams;

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uvShadow = mul(unity_Projector, v.vertex);
				o.uvFalloff = mul(unity_ProjectorClip, v.vertex);

				UNITY_TRANSFER_FOG(o, o.pos);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 texS = tex2Dproj(_ShadowTex, UNITY_PROJ_COORD(i.uvShadow));
				fixed4 texF = tex2Dproj(_FalloffTex, UNITY_PROJ_COORD(i.uvFalloff));
				
				fixed4 res = lerp(fixed4(1, 1, 1, 0), texS, texF.a);

				return res;
			}
			ENDCG
		}
	}
}