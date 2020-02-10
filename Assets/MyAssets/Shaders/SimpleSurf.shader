Shader "Custom/SimpleSurf"
{
	Properties {
		_Color ("Tint", Color) = (0, 0, 0, 1)
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader {
		Tags{ "RenderType"="Opaque" "Queue"="Geometry"}

		CGPROGRAM

		sampler2D _MainTex;
		fixed4 _Color;

		struct INPUT {
			float2 uv_MainTex;
		};

		void surf(INPUT i, inout SurfaceOutputStandard o) {


		}

		fixed4 frag (v2f) : SV_TARGET {
			fixed4 col = tex2D(_MainTex, i.uv);
			col *= _Color;
			return col;
		}
		ENDCG
	}
	FallBack "Standard"
}