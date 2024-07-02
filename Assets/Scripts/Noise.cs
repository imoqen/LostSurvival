using UnityEngine;
using System.Collections;

public static class Noise {

	public enum NormalizeMode {Local, Global};

	public static float[,] generateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset, NormalizeMode normalizeMode) {
		float[,] noiseMap = new float[mapWidth,mapHeight];

		System.Random prng = new System.Random (seed); //a system random object has been created called p rng (pseudo-random number generator)
																									 //and is equal to a new system random with the variable seed passed in
		Vector2[] octaveOffsets = new Vector2[octaves]; //each octave is sampled from a different location

		float maxPossibleHeight = 0; //new variables created: frequency, amplitude and maxPossibleHeight. values assigned.
		float amplitude = 1;
		float frequency = 1;

		for (int i = 0; i < octaves; i++) {
			float offsetX = prng.Next (-100000, 100000) + offset.x; //limited to a range of values, this stops a bug where it returns
			float offsetY = prng.Next (-100000, 100000) - offset.y; //the same value over and over
			octaveOffsets [i] = new Vector2 (offsetX, offsetY);

			maxPossibleHeight += amplitude; // assigning a value to the maximum possible height
			amplitude *= persistance;				// assigning a value to the amplitude

		}

		if (scale <= 0) {
			scale = 0.0001f;
		}

		float maxLocalNoiseHeight = float.MinValue; // variables used to normalise the noiseMap value to be
		float minLocalNoiseHeight = float.MaxValue; // within the range of 0-1
		float halfWidth = mapWidth / 2f; // used to zoom into the center instead of the top right when
		float halfHeight = mapHeight / 2f; // manipulating the value of the noiseScale

		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapWidth; x++) {

				amplitude = 1; // variables called for use here
				frequency = 1;
				float noiseHeight = 0; // new variable - keeps track of the current height value

				for (int i = 0; i < octaves; i++) { // iterates through all of the octaves, using combinations of variables
					float sampleX = (x-halfWidth + octaveOffsets[i].x) / scale * frequency; // for fractal brownian motion
					float sampleY = (y-halfHeight + octaveOffsets[i].y) / scale * frequency;

					float perlinValue = Mathf.PerlinNoise (sampleX, sampleY) * 2 - 1; // Mathf.PerlinNoise is always in the range 0-1

					noiseHeight += perlinValue * amplitude;

					amplitude *= persistance; // at the end of each octave, the amplitude gets multiplied by the persistence value,
																		// this is in the range of 0-1 so will decrease each octave

					frequency *= lacunarity; // frequency gets multiplied by the lacunarity so the frequency increases each time.
																	 // the lacunarity value should always in default be greater than 1
				}

				if (noiseHeight > maxLocalNoiseHeight) { // the value of the noise map is normalised so that
					maxLocalNoiseHeight = noiseHeight;		 // it is in the range 0-1 for when it is returned
				}
				else if (noiseHeight < minLocalNoiseHeight) { // this uses an if statement to see that if the minLocalNoiseHeight
																											// is greater than the noiseHeight, the minLocalNoiseHeight
					minLocalNoiseHeight = noiseHeight;          // will be updated to have the same value as the current noiseHeight
				}
				noiseMap [x, y] = noiseHeight;
			}
		}
		for (int y = 0; y < mapHeight; y++) { // noiseHeight value is applied to the noise map
			for (int x = 0; x < mapWidth; x++) {
				if (normalizeMode == NormalizeMode.Local) {
					noiseMap [x, y] = Mathf.InverseLerp (minLocalNoiseHeight, maxLocalNoiseHeight, noiseMap [x, y]); // uses InverseLerp node
				} else {
					float normalizedHeight = (noiseMap [x, y] + 1) / (maxPossibleHeight/1f); // uses the reverse of the calculation on line 49,
																																									 // as it divides by 2 and adds 1, along with the
																																									 // maxLocalNoiseHeight and further values which make
																																									 // the Global Normalize Mode appear better.
					noiseMap [x, y] = Mathf.Clamp(normalizedHeight,0, int.MaxValue); // clamped so that it never goes lower than 0 or
						 																														 	 // higher than the maximum value
				}
			}
		}
		return noiseMap; // the noise map is returned.
	}
}
