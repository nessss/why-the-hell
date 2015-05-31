using UnityEngine;
using System.Collections;

public class RingPattern : BulletPattern{
	
	private int nBullets = 24;
	private float mag = 1.0f;
	//private float offset = 0.075f;
	private float angleWidth = 1.0f;
	private const float TAU = Mathf.PI * 2f;
	
	public float fireRate = 0.6f;
	
	public override IEnumerator Fire(){
		//if(reversed){
		//	offset += 0.5f;
		//}
		while(true){
			for(int i=0;i<nBullets;i++){
				float phase = (float)i/nBullets;
				float theta = (phase * TAU * angleWidth) + TAU;  //*offset;
				Vector3 bulletPosition = new Vector3(
						Mathf.Sin(theta)*mag, Mathf.Cos(theta)*mag, 0);

				Bullet thisBullet = GameObject.Instantiate(
						bullet,
						(bulletPosition + transform.position),
						Quaternion.identity) as Bullet;

				thisBullet.velocity = bulletPosition.normalized * bulletSpeed;
			}
			//offset += 0.01625f;
			yield return new WaitForSeconds(fireRate);
		}
	}
}
