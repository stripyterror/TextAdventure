using System;
using System.Dynamic;

namespace Zuul
{

	public class Player
	{
        public Inventory inventory = new Inventory(20);
        public Boolean alive;
		public float health;
		public Room currentRoom;

		public Player()
		{
			health = 5f;
			alive = true;
		}

		public void damage(float  _damage) {
			health -= _damage;
		}
		public void heal(float _heal) { 
		
		}
		public void isAlive() {
			if (health <= 0) {
				alive = false;
			}
		
		}
	}
}
