/**
 * Wong Lok
 * @wonglok831
 * Particle Simulate Vertex Shader - GPU Simulation
 */


attribute vec2 aVertexPosition;
attribute vec2 aTextureCoord;

varying vec2 vTextureCoord;

void main() {
    vTextureCoord = vec2(aTextureCoord.x, 1.0 - aTextureCoord.y);
    gl_Position = vec4(aVertexPosition, 0.0, 1.0);
}



