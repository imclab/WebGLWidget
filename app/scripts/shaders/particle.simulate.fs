/**
 * Wong Lok
 * @wonglok831
 * Particle Simulate Fragment Shader - GPU Simulation
 */

precision highp float;
// precision lowp float;

uniform sampler2D uSampler;
varying vec2 vTextureCoord;


uniform float uTimer;

float rand(vec2 co){
	return fract(sin(
		dot(
			co.xy,
			vec2(
				59.454233,
				72.223432
			)
		) * 0.32457
	) * 2342.0);
}

uniform int uMode;

void main() {

	int mode;

	if (uMode != 0){
		mode = uMode;
	}else{
		mode = 1;
	}


	float opacity = 0.05;
	vec4 nextPos = vec4(opacity);

	vec4 lastPos = texture2D(uSampler, vTextureCoord);


	float rVal = rand(vec2(
		vTextureCoord.x,
		vTextureCoord.y
	 ));

	float sinTime = sin(uTimer / 500.0);
	float cosTime = cos(uTimer / 500.0);
	float tanTime = tan(uTimer / 500.0);


	vec4 fSpace = vec4(
		sinTime * sin(uTimer * rVal + vTextureCoord.s),
		cosTime * cos(uTimer * rVal + vTextureCoord.t),
		cosTime * sinTime * tan(uTimer * rVal),
		opacity
	);

	// mode = 5;

	if (mode == 1){
		nextPos = fSpace;
	} else if (mode == 2) {
		vec4 fEdge = vec4(
			sinTime * sin(uTimer * vTextureCoord.s / 1000.0),
			cosTime * cos(uTimer * vTextureCoord.t / 1000.0),
			sinTime * sin(uTimer * 1.0 / rVal),
			opacity
		);

		nextPos = fSpace;
		nextPos += fEdge;
	} else if (mode == 3){

		nextPos = vec4(
			sinTime * sin(uTimer * rVal + vTextureCoord.s),
			cosTime * cos(uTimer * rVal + vTextureCoord.t),
			tanTime * sinTime * sin(uTimer * rVal),
			opacity
		);

	} else if (mode == 4){

		vec4 sEdge = vec4(
			sinTime * sin(uTimer * rVal + vTextureCoord.s),
			cosTime * sin(uTimer * rVal + vTextureCoord.t),
			cosTime * sin(uTimer * rVal),
			opacity
		);

		nextPos = sEdge;
	} else if (mode == 5){

		vec4 eSignal = vec4(
			tanTime * sin(uTimer * rVal * cosTime * vTextureCoord.s),
			tanTime * sin(uTimer * rVal * sinTime * vTextureCoord.t),
			tanTime * sin(uTimer * rVal * cosTime),
			opacity
		);

		nextPos = eSignal;
	}





	nextPos += lastPos;
	gl_FragColor = nextPos;

}




