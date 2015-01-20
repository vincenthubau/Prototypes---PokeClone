using UnityEngine;
using System.Collections;

public class AnimateSprite : MonoBehaviour {
	public int uvAnimationTileX = 3;
	public int uvAnimationTileY = 4;
	public float framesPerSecond = 10.0f;

	// Update is called once per frame
	void Update () {
		int index = (int)(Time.time * framesPerSecond);
		index = index % (4 * 4);
		Vector2 size = new Vector2 (1.0f / uvAnimationTileX , 1.0f / uvAnimationTileY);
		float uIndex = index % uvAnimationTileX;
		float vIndex = index / uvAnimationTileX;
		Vector2 offset = new Vector2 (uIndex * size.x , 1.0f - size.y + vIndex * size.y);
		renderer.material.SetTextureOffset("_MainTex", offset);
		renderer.material.SetTextureScale("_MainTex", size);
	}
}
