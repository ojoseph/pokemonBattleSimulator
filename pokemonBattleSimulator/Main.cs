using System;

namespace pokemonBattleSimulator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Pokemon Battle Simulator 2013");
			
			//We Create a new pokemon
			pokemon Charmander = new pokemon();
			//We set the pkmn with these values: ID, Name,Hp
			Console.Write (Charmander.setPkmn(6, "Charmander", 39));
			Console.WriteLine(Charmander);
			// DIsplays the pokemon's Stats
			//Charmander.showPkmnStats();
		}
	}
	
	
	
	//Our Pokemon Class, we call it when we create a new pokemon
	class pokemon{
		
		struct pkmnInfo{
			public  int id;
			public string name;
			public int hp;
			//public int attack;
			//public string[,,,,] theMovesList;
		}
		
		public string setPkmn(int theId, string theName, int theHp){
			//Console.WriteLine("LOLz");
			pkmnInfo setPkmnInfo = new pkmnInfo();
			setPkmnInfo.id = theId;
			setPkmnInfo.name = theName;
			setPkmnInfo.hp = theHp;
			
			//Console.WriteLine(setPkmnInfo.name);
			
			string simpleStr = setPkmnInfo.name;
			//Console.WriteLine(simpleStr);
			return simpleStr; 
			//Console.WriteLine("pkmn is now Set");
		}
		
		
		
		public void showPkmnStats(){
			Console.WriteLine("Viewing pkmn stats");
			//We create an instance of the stats.
			pkmnInfo getPkmnStats = new pkmnInfo();
			Console.WriteLine(getPkmnStats.id);
			Console.WriteLine(getPkmnStats.name);
			Console.WriteLine(getPkmnStats.hp);
		}
		
		/*public void showPkmnStats(){
			Console.WriteLine("Viewing pkmn stats");
			//We create an instance of the stats.
			pkmnInfo getPkmnStats = new pkmnInfo();
			Console.WriteLine(getPkmnStats.id);
			Console.WriteLine(getPkmnStats.name);
			Console.WriteLine(getPkmnStats.hp);
		}*/
		
	}
	
	class movelist{
		enum moves{
			scratch,
			quickAttack,
			ember,
			vineWhip,
			tackle,
			bite,
			bubble,
			thundershock,
			watergun,
			gust
		}
		
	}
}
