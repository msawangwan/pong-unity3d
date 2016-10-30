using System;
using mUIFramework.Core;
using mExtensions.Common;

namespace mStateFramework {
	// public class StatePrintText : StateUI {
    //     private readonly string text;
    //     private float startTime;
    //     public StatePrintText(UI context, string text) : base(context) {
    //         this.text = text;
    //     }

	// 	public override void Enter() {
    //         context.controller.PrintCenter(text);
    //         startTime = UI.DisplayInterval;
    //     }

	// 	public override bool Update () {
	// 		if (UnityEngine.Time.time < startTime) {
    //             return false;
    //         }
    //         return true;
    //     }

	// 	public override State<UI> Exit() {
    //         return new StateFadeText(context);
    //     }
	// }
}
