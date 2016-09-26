using UnityEngine;
using System.Collections;

namespace Original.Util{

	public class AudioManager : MonoBehaviour {

		public static void Play(AudioSource source, AudioClip clip){

			if (source.isPlaying) {
				source.Stop ();
			}
			source.clip = clip;
			source.Play ();

		}

		public static void Stop(AudioSource source, AudioClip clip){

			if (source.isPlaying && source.clip == clip) {
				source.Stop ();
			}

		}

		public static bool isPlaying(AudioSource source, AudioClip clip){

			if (source.isPlaying && source.clip == clip) {
				return true;
			}

			return false;
		}


	}

}