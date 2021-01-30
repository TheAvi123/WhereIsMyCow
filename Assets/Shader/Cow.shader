Shader "Custom/Cow"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

		_ColorFirst("ColorFirst", Color) = (1,1,1,1)
		_TexFirst("TexFirst (RGB)", 2D) = "white" {}
		
		_ColorSecond("colorSecond", Color) = (1,1,1,1)
		_TexSecond("TexSecond (RGB)", 2D) = "white" {}

		_ColorThird("ColorThird", Color) = (1,1,1,1)
		_TexThird("TexThird (RGB)", 2D) = "white" {}


    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		sampler2D _TexFirst;
		sampler2D _TexSecond;
		sampler2D _TexThird;

        struct Input
        {
            float2 uv_MainTex;
			float2 uv_TexFirst;
			float2 uv_TexSecond;
			float2 uv_TexThird;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
		fixed4 _ColorFirst;
		fixed4 _ColorSecond;
		fixed4 _ColorThird;


        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here

        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

			

			fixed4 c1 = tex2D(_TexFirst, IN.uv_TexFirst) * _ColorFirst * c.r * c.a;
			fixed4 c2 = tex2D(_TexSecond, IN.uv_TexSecond) * _ColorSecond  * c.g * c.a;
			fixed4 c3 = tex2D(_TexThird, IN.uv_TexThird) * _ColorThird  * c.b * c.a;
			

			fixed4 color = c1 + c2 + c3 + (c * (1-c.a));



            o.Albedo = color.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            //o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
