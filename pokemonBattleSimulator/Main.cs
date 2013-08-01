using System;
using System.Collections.Generic;
using System.Text;

namespace pokemonBattleSimulator
{
	class MainClass
	{
		//We might use it to determine the game phases
		enum gamePhase{
			
			init,
			battle,
			gameover
			
		}
		
		//Will define the turn of the Pokemons/Events 
		public List<string> theTurns = new List<string>();
		
		
		
		
		
		public static void Main (string[] args)
		{
			Console.WriteLine ("Pokemon Battle Simulator 2013");
			
			//We Create a new pokemon ID, Name, HP, Atk, Def
			pokemon Charmander = new pokemon(4,"Charmander",39,53,43);
			//We show Charmander' stats	
			Charmander.showPkmnStats();
			
			
			//We Create a new pokemon ID, Name, HP, Atk, Def
			pokemon Pikachu = new pokemon(25,"Pikachu",35,55,30);
			//We show Pikachu's stats	
			Pikachu.showPkmnStats();
			
			//TEST 1 attack Charmander -> Pikachu
			
			//We atk pikachu
			//Pikachu.hp -= ( Charmander.attack - Pikachu.defense);
			
			//We atk pikachu
			//Pikachu.hp -= ( Charmander.attack - Pikachu.defense);
			//Console.WriteLine("The Damage: " + (Charmander.attack - Pikachu.defense));
			/*Pikachu.checkFaints();
			Pikachu.showPkmnStats();*/
			
			calculate calculatePkmn = new calculate();
			calculatePkmn.pokemonAttack(Charmander, Pikachu);
			/////////////////////////////////////////////////////

		}
		
		
		
		
		
	}
	
	
	
	
	
	
	
	
	///////////////////
	/// Class Pokemon.
	///////////////////
	//Our Pokemon Class, we call it when we create a new pokemon
	class pokemon{
		  
		//The info Concerning the Pokemon goes here
		public int id;
		public string name;
		public int hp;
		public int attack;
		public int defense;
		public status pkmnStatus = status.canBattle;
		//public string[,,,,] theMovesList;
		
		
		public enum status{
			canBattle,
			fainted,
			poisoned,
			confused,
			paralysed,
			burned
		}
		
		
		//We make a constructor to set it
		public pokemon(int pkmnId, string pkmnName, int pkmnHp, int pkmnAttack,  int pkmnDefense){
			id = pkmnId;
			name = pkmnName;
			hp = pkmnHp;
			attack = pkmnAttack;
			defense = pkmnDefense;
		}
		
		public void showPkmnStats(){
			Console.WriteLine("");
			Console.WriteLine("[Viewing " + name + " stats]");
			Console.WriteLine("");
			Console.WriteLine("ID: " + id);
			Console.WriteLine("Name: " + name);
			Console.WriteLine("HP: " + hp);
			Console.WriteLine("ATK: " + attack);
			Console.WriteLine("DEF: " + attack);
		}
		
		//The pokemon checks if he faints
		public void checkFaints(){
			if(hp <= 0){
				//If the hp goes below 0  we set it back to 0
				hp = 0;
				
				//The pokemon has fainted
				Console.Write(name+" has fainted!");
				pkmnStatus = status.fainted;
			}	
		}
		
		
		
	}
	
	
	///////////////////
	/// Class Calculate.
	///////////////////
	//Might not use it
	class calculate{
		
		public void pokemonAttack(pokemon atkPkmn, pokemon defPkmn){
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine("POKEMON ATTACK");
			//Console.WriteLine("TestPkmn####: " + defPkmn.hp);
			//Console.WriteLine("We" + );
			
			//We atk pikachu and change it Hp.
			defPkmn.hp -= ( atkPkmn.attack - defPkmn.defense);
			//Console.WriteLine("the Hp" + defPkmn.hp);
			defPkmn.checkFaints();
			defPkmn.showPkmnStats();
		}
		
	}
	
	
	///////////////////
	/// Class Movelist.
	///////////////////
	//Might not use it
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
