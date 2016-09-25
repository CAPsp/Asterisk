using UnityEngine;
using System.Collections;

namespace Original.Util{

	public class Vec3ToVec2{

		// Vector3 → Vector2
		public static Vector2 GenV3ToV2(Vector3 before){
			return new Vector2 (before.x, before.y);
		}

		// Vector3で表される２点を結ぶベクトルを生成
		public static Vector2 GenVecFrom2Points(Vector3 first, Vector3 second){
			Vector3 diff = (first - second);
			return (new Vector2 (diff.x, diff.y));
		}

		// Vector3で表される２点の距離を求める(z軸は無視)
		public static float CalcDistanceOn2D(Vector3 first, Vector3 second){
			return Vector2.Distance (
				new Vector2(first.x,	first.y),
				new Vector2(second.x,	second.y)
			);
		}

	}

}