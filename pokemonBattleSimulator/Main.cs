using System;
using System.Collections.Generic;
using System.Text;

namespace pokemonBattleSimulator
{
	class MainClass
	{
		
		
		//We might use it to determine the game phases
		public enum gamePhase{	
			init,
			battle,
			gameover
		}
		
	
		
		//public gamePhase currentGamePhase = gamePhase.init;
		
		
		
		//gamePhase.init;
		//currentGamePhase
		
		//Will define the turn of the Pokemons/Trainers 
		public static List<pokemon> battleFlow = new List<pokemon>();
		
		//Let us know which pokemon will fight 
		public static List<pokemon> participants = new List<pokemon>();
		
		
		
		public static void Main (string[] args)
		{	
			////////////////////
			//Simple FSM
			gamePhase currPhase = gamePhase.init; 
			
			switch(currPhase){
				case gamePhase.init:
					Console.WriteLine("GAME PHASE: INIT");
				break;
				
				case gamePhase.battle:
					Console.WriteLine("GAME PHASE: BATTLE");
				break;
				
				case gamePhase.gameover:
					Console.WriteLine("GAME PHASE: GAME OVER");
				break;
			}
			
			
			
			
			
			
			//////////////////////////////
			//We Init the Game
			//////////////////
			Console.WriteLine ("Pokemon Battle Simulator 2013");
			
			//We Create a new pokemon ID, Name, HP, Atk, Def
			pokemon Charmander = new pokemon(4,"Charmander",39,53,43,65);
			//We show Charmander' stats	
			//Charmander.showPkmnStats();
			
			
			
			//We add Charmander to the flow
			//battleFlow.Add(Charmander);
			
			//We add Charmander as a participant
			participants.Add(Charmander);
			
			
			//We Create a new pokemon ID, Name, HP, Atk, Def
			pokemon Pikachu = new pokemon(25,"Pikachu",35,55,30,90);
			//We show Pikachu's stats	
			//Pikachu.showPkmnStats();
			//We add Pikachu to the flow
			//battleFlow.Add(Pikachu);
			//We add Pikachu as a participant
			participants.Add(Pikachu);
			
			//We set the pokemon battleflow
			calculate calPkmnOrder = new calculate();
			battleFlow = calPkmnOrder.setBattleFlow(Charmander, Pikachu);
			
			
			
			//∑We check the order the pokemon will battle.
			foreach(pokemon things in battleFlow){
				
				//Console.WriteLine("The PKMN: " + things.name);
			}
			
			
			//////////////////////////////
			//We Enter Battle
			//////////////////
			Console.WriteLine("BATTLE START");
			
			//Calculate the number of turns passed
			int turns = 0;
			
			//As long that the pokemon can fight we keep going on.
			while(participants[0].pkmnStatus == pokemon.status.canBattle || participants[1].pkmnStatus == pokemon.status.canBattle ){	
				
				//calculatePkmn.pokemonAttack(Charmander, Pikachu);
				calculate calculatePkmn = new calculate();
				Console.WriteLine( "");
				Console.WriteLine("====TURN===="+ turns);
			
				Console.WriteLine("Pkmn Name: " + Charmander.name + "  Pkmn Hp: " + Charmander.hp + "  Status " + Charmander.pkmnStatus);
				Console.WriteLine("Pkmn Name: " + Pikachu.name + "  Pkmn Hp: " + Pikachu.hp + "  Status " + Pikachu.pkmnStatus);
				Console.WriteLine(" ");
				calculatePkmn.pokemonAttack(battleFlow[turns], battleFlow[turns+1]);
				//The pkmn that just attacked  is been moved at the end of the battleflow but  [pkmn1, pkmn2, pkmn1, here we will move pkmn2]
				battleFlow.Add(battleFlow[turns]);
				
				Console.WriteLine("Pkmn Name: " + Charmander.name + "  Pkmn Hp: " + Charmander.hp + "  Status " + Charmander.pkmnStatus);
				Console.WriteLine("Pkmn Name: " + Pikachu.name + "  Pkmn Hp: " + Pikachu.hp + "  Status " + Pikachu.pkmnStatus);
				
				//We increment the turns
				turns ++;
				//If a pokemon Faints we end the Battle
				if(battleFlow[turns].pkmnStatus == pokemon.status.fainted || battleFlow[turns+1].pkmnStatus == pokemon.status.fainted ){
					Console.WriteLine("GAME OVER!!!");
					break;
				}
				
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
		public int speed;
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
		public pokemon(int pkmnId, string pkmnName, int pkmnHp, int pkmnAttack,  int pkmnDefense, int pkmnSpeed){
			id = pkmnId;
			name = pkmnName;
			hp = pkmnHp;
			attack = pkmnAttack;
			defense = pkmnDefense;
			speed = pkmnSpeed;
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
			Console.WriteLine("SPD: " + speed);
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
		
		
		public List<pokemon> setBattleFlow(pokemon pkmnSpd1, pokemon pkmnSpd2){
			List<pokemon> theOrder = new List<pokemon>();
			
			if(pkmnSpd1.speed > pkmnSpd2.speed){	
				//We put the first pkmn first
				theOrder.Add(pkmnSpd1);
				theOrder.Add(pkmnSpd2);
			}else{
				//We put the second pkmn first
				theOrder.Add(pkmnSpd2);
				theOrder.Add(pkmnSpd1);
			}
			
			return theOrder;
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
