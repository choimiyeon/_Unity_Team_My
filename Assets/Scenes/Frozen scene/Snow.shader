Shader "Custom/Snow"
{
    Properties
    {

        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _SnowHeight("눈이 쌓이는 정도",range(0,0.1)) = 0 //range값은 자신의 모델 스케일에 따라서 적절하게 조절합시다.
        _SnowAngle("눈이 쌓이는 방향",vector) = (0,1,0,0)
        _SnowSize("눈이 쌓이는 범위",range(-1.1,1.1)) = 0


    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        float _SnowHeight;
        float _SnowSize;
        float4 _SnowAngle;
       
        void vert(inout appdata_full v)
        {
            float4 snowA = mul(normalize(_SnowAngle), unity_ObjectToWorld); //눈의 벡터를 월드기준으로 만들어줍니다.

            //눈이 쌓이는 범위와 크기를 조절해줍니다.
            if (dot(v.normal, snowA.xyz) >= _SnowSize)
            {
                v.vertex.xyz += v.normal.xyz * _SnowHeight;
            }
        }
      


        struct Input
        {
            float2 uv_MainTex;
        };


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
         
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;

            float4 snowA = mul(normalize(_SnowAngle), unity_ObjectToWorld);
            if (dot(mul(o.Normal, unity_ObjectToWorld), snowA.xyz) >= _SnowSize - 0.1)
            {
                o.Albedo = 1;//이 부분이 '눈'에 들어갈 부분입니다. 이 부분을 수정하면 본인만의 새로운 눈을 만들 수 있습니다!
            }
           

        }
        ENDCG
    }
    FallBack "Diffuse"
}
