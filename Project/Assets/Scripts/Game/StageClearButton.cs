using UnityEngine;
using System.Collections;

public class StageClearButton : SceneChangeButton {

	public override void Push(){
		base.Push ();
		NumStage.numberOfStage++;
	}

}
