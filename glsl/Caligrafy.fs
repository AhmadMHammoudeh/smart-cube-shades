#version 410 core
in vec2 uv;
out vec4 fragColor;

uniform sampler2D extraTexture0;
uniform float iTime; 

float PI = 3.14159265359;

float luminance(vec3 rgb)
{
    // luminance is not just r+g+b... go check it out.
    const vec3 W = vec3(0.5067, 0.7734, 0.4169);
    return dot(rgb, W);
}


void main()
{
    float col = cos(((uv.x * 2.0 * PI) + iTime * 0.1) * 2.) * 1.5f ;

    col = clamp(col, 0.0f,1.0f);

    // sample the texture
    vec4 color = texture(extraTexture0 , uv ) ;

    // mix the colour over it
    color.rgb = mix(vec3(luminance(color.rgb)), color.rgb, col);

    fragColor =  color;
}
 
