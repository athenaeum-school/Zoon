﻿using System;
namespace zoon {
	[Serializable]
	public class LifeController  {

		private float InitialLife = 3.0f;
		private float Life = 3.0f;
		public ILifeController ilcon;
		public LifeController(){
			
		}
		public void SetLifeController(ILifeController ilcon) {
			this.ilcon = ilcon;
		}
		// Use this for initialization
		void Start () {
			
			Life = 3.0f;
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		//ライフ回復
		public float AddLife(float LifePoint){
			return Life += LifePoint;
		}
		
		//ライフ減少
		public float ReduceLife(float LifePoint){
			if( Life > 0){
			return Life -= LifePoint;
			}
			return Life;
		}
		
		public float GetLife(){
			return this.Life;
		}
		public string SetLife () {

			return this.Life.ToString();
		}

		public float ResetLife(){
			return Life = InitialLife;
		}
	}
}
