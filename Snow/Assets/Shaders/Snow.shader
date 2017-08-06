Shader "Custom/Snow" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Normal("Normal Texture",2D)="bump"{}
		_SnowRank("SnowRank",range(0,1))=0
		_SnowColor ("SnowColor", Color) = (1,1,1,1)
		_SnowDir("SnowDirection",Vector)=(0,1,0)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf SnowDiffuse
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _Normal;
		float _SnowRank;
		float4 _SnowColor;
		float4 _SnowDir;

		struct Input {
			float2 uv_MainTex;
			float2 uv_Normal;
			float3 worldNormal; 
			INTERNAL_DATA
		};

		fixed4 _Color;

		inline float4 LightingSnowDiffuse(SurfaceOutput s, fixed3 lightDir, fixed atten){
			//这里暂时用 half lambert
			half NdotL = dot (s.Normal, lightDir);
			half diff = NdotL * 0.5 + 0.5;
			//普通颜色
			//half diff = max(0,dot (s.Normal, lightDir));
			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * (diff * atten);
			c.a = s.Alpha;
			return c;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Normal=UnpackNormal(tex2D (_Normal, IN.uv_Normal));
			if(dot(WorldNormalVector(IN,o.Normal),_SnowDir.xyz)>lerp(1,-1,_SnowRank))
			{
				o.Albedo = _SnowColor.rgb;
			}
			else
			{
				o.Albedo = c.rgb;
			}
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
