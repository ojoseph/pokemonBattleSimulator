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
		
		//Will define the turn of the Pokemons/Trainers 
		public static List<pokemon> battleFlow = new List<pokemon>();
		
		
		
		
		
		public static void Main (string[] args)
		{
			//////////////////////////////
			//We Init the Game
			//////////////////
			Console.WriteLine ("Pokemon Battle Simulator 2013");
			
			//We Create a new pokemon ID, Name, HP, Atk, Def
			pokemon Charmander = new pokemon(4,"Charmander",39,53,43);
			//We show Charmander' stats	
			//Charmander.showPkmnStats();
			//We add Charmander to the flow
			battleFlow.Add(Charmander);
			
			
			//We Create a new pokemon ID, Name, HP, Atk, Def
			pokemon Pikachu = new pokemon(25,"Pikachu",35,55,30);
			//We show Pikachu's stats	
			//Pikachu.showPkmnStats();
			//We add Pikachu to the flow
			battleFlow.Add(Pikachu);
			
			
			//∑We check the order the pokemon will battle.
			foreach(pokemon things in battleFlow){
				
				//Console.WriteLine("The PKMN: " + things.name);
			}
			
			
			//////////////////////////////
			//We Enter Battle
			//////////////////
			
			//we loop and wait for a pokemon to faint
			/*while(Charmander.pkmnStatus != pokemon.status.fainted || Pikachu.pkmnStatus != pokemon.status.fainted){
				Console.WriteLine("we battle");
				
			}*/
			
			Console.WriteLine("BATTLE START");
			
			//We make a simple test with 2 turns to make sure that the system kinds of works
			for(int turns = 0; turns <= 3; turns++){
				
				//calculatePkmn.pokemonAttack(Charmander, Pikachu);
				calculate calculatePkmn = new calculate();
				Console.WriteLine( "");
				Console.WriteLine("TURN"+ turns);
			
				Console.WriteLine("Pkmn Name: " + Charmander.name + "  Pkmn Hp: " + Charmander.hp + "  Status " + Charmander.pkmnStatus);
				Console.WriteLine("Pkmn Name: " + Pikachu.name + "  Pkmn Hp: " + Pikachu.hp + "  Status " + Pikachu.pkmnStatus);
				Console.WriteLine(" ");
				calculatePkmn.pokemonAttack(battleFlow[turns], battleFlow[turns+1]);
				battleFlow.Add(battleFlow[turns]);
				
				Console.WriteLine("Pkmn Name: " + Charmander.name + "  Pkmn Hp: " + Charmander.hp + "  Status " + Charmander.pkmnStatus);
				Console.WriteLine("Pkmn Name: " + Pikachu.name + "  Pkmn Hp: " + Pikachu.hp + "  Status " + Pikachu.pkmnStatus);
				
				if(battleFlow[turns].pkmnStatus == pokemon.status.fainted || battleFlow[turns+1].pkmnStatus == pokemon.status.fainted ){
					Console.WriteLine("GAME OVER!!!");
					break;
				}
				
				//We show pikachu's current Status
				//Pikachu.showPkmnStats();
			}
			
			
			//TEST 1 attack Charmander -> Pikachu
			
			//We atk pikachu
			//Pikachu.hp -= ( Charmander.attack - Pikachu.defense);
			
			//We atk pikachu
			//Pikachu.hp -= ( Charmander.attack - Pikachu.defense);
			//Console.WriteLine("The Damage: " + (Charmander.attack - Pikachu.defense));
			/*Pikachu.checkFaints();
			Pikachu.showPkmnStats();*/
			
			
			
			
			/////////////////////////////////////////////////////
			//  calculate calculatePkmn = new calculate();
			//  calculatePkmn.pokemonAttack(Charmander, Pikachu);
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
			Console.WriteLine("Status: " + pkmnStatus);
		}
		
		//The pokemon checks if he faints
		public void checkFaints(){
			if(hp <= 0){
				//If the hp goes below 0  we set it back to 0
				hp = 0;
				
				//The pokemon has fainted
				 
				Console.WriteLine("<!>  "+ name + " has fainted! <!>");
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
			/*Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine(" ");*/
			Console.WriteLine(atkPkmn.name + " ATTACKS");
			//Console.WriteLine("TestPkmn####: " + defPkmn.hp);
			//Console.WriteLine("We" + );
			
			//We atk pikachu and change it Hp.
			defPkmn.hp -= ( atkPkmn.attack - defPkmn.defense);
			//Console.WriteLine("the Hp" + defPkmn.hp);
			defPkmn.checkFaints();
			// defPkmn.showPkmnStats();
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
