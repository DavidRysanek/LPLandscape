Shader "Custom/VertexColorSurfaceShader" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input {
            float2 uv_MainTex;
            float4 color: Color; // Vertex color
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutputStandard OUT) {
            // Albedo comes from a texture tinted by material color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            OUT.Albedo = c.rgb * IN.color.rgb; // Material color * vertex RGB
            OUT.Alpha = c.a * IN.color.a; // Material color * vertex Alpha
            // Metallic and smoothness come from slider variables
            OUT.Metallic = _Metallic;
            OUT.Smoothness = _Glossiness;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
