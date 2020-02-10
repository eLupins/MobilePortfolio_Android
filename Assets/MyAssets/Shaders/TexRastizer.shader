Shader "Custom/TexRastizer"
{
Properties{
		_Color ("Color", Color) = (0, 0, 0, 1)
		_MainTex("Texture", 2D) = "white" {}
	}

	SubShader{
		//the material is completely non-transparent and is rendered at the same time as the other opaque geometry
		Tags{ "RenderType"="Opaque" "Queue"="Geometry"}

		Pass{
			CGPROGRAM
			#include "UnityCG.cginc"

			#pragma vertex vert
			#pragma fragment frag

			fixed4 _Color;
			sampler2D _MainTex;

			//object thats put into the vertex shader
			struct appdata{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			//data thats used to genereate fragments and is readable by frag shader
			struct v2f{
				float4 position : SV_POSITION;
				float2 uv :TEXCOORD0;
			};

			//vert shader
			v2f vert(appdata v){
				v2f o;
				//convert the vertex positions from obj space to clip space so they can be rendered
				o.position = UnityObjectToClipPos(v.vertex);
				//o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag(v2f i) : SV_TARGET{
				//return fixed4(i.uv.x, i.uv.y, 0, 1);
				//fixed4 ras = fixed4(i.uv.x, i.uv.y, 0, 1);
				//col *= ras;
				
				fixed4 col = tex2D(_MainTex, i.uv);
				col += _Color;

				return col;
			}

			ENDCG
		}
	}
}