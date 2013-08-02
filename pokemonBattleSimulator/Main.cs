using System;
using System.Collections.Generic;
using System.Text;

namespace pokemonBattleSimulator
{
	class MainClass{
		
		//We might use it to determine the game phases
		public enum gamePhase{	
			init,
			battle,
			gameover,
			credits,
			quit
		}
		
		public static gamePhase currPhase;
		
		//Will define the turn of the Pokemons/Trainers 
		public static List<pokemon> battleFlow = new List<pokemon>();
		
		//Let us know which pokemon will fight 
		public static List<pokemon> participants = new List<pokemon>();
		
		
		public static void Main (string[] args){	
			
			////////////////////
			//Simple FSM
			gamePhase currPhase = gamePhase.init; 
			
			while(currPhase != gamePhase.quit){
		
				switch(currPhase){
					case gamePhase.init:
						Console.WriteLine(" ");
						Console.WriteLine("GAME PHASE: INIT");
						currPhase = phaseInit();
					break;
					case gamePhase.battle:
						Console.WriteLine(" ");
						Console.WriteLine("GAME PHASE: BATTLE");
						//Console.WriteLine(participants);
						currPhase = phaseBattle(participants);
					break;
					case gamePhase.gameover:
						Console.WriteLine(" ");
						Console.WriteLine("GAME PHASE: GAME OVER");
						//phaseGameover();
						currPhase = phaseGameover();
					break;
					case gamePhase.credits:
						Console.WriteLine(" ");
						Console.WriteLine("CREDITS");
						//phaseGameover();
						currPhase = phaseCredits();
					break;
				}//End Switch
				
			}//End While
			

		}//End Main Fct
		
		
		
		
		
		
		//-------------------------------------------------------------------------------------------------------------------------
		//-----------------------------------------------------FSM--------------------------------------------------------------------
		//-------------------------------------------------------------------------------------------------------------------------
		
		//=======================
		//<!>Phase: INIT
		public static gamePhase phaseInit(){
			Console.WriteLine("ENTER - INIT");
			
			
			
			//////////////////////////////
			//We Init the Game
			//////////////////
			

			Console.WriteLine ("    ,                           .::.");
			Console.WriteLine ("                              .;:**'            AMC");
			Console.WriteLine ("                              `                  0");
			Console.WriteLine ("  .:XHHHHk.              db.   .;;.     dH  MX   0");
			Console.WriteLine ("oMMMMMMMMMMM       ~MM  dMMP :MMMMMR   MMM  MR      ~MRMN");
			Console.WriteLine ("QMMMMMb  :MMX       MMMMMMP !MX: :M~   MMM MMM  .oo. XMMM :MMM");
			Console.WriteLine ("  `MMMM.  )M> :X!Hk. MMMM   XMM.o:  .  MMMMMMM X?XMMM MMM>!MMP");
			Console.WriteLine ("   'MMMb.dM! XM M'?M MMMMMX.`MMMMMMMM~ MM MMM XM `: MX MMXXMM");
			Console.WriteLine ("    ~MMMMM~ XMM. .XM XM`:MMMb.~*?**~ .MMX M t MMbooMM XMMMMMP");
			Console.WriteLine ("     ?MMM>  YMMMMMM! MM   `?MMRb.    `***   !L:MMMMM XM IMMM");
			Console.WriteLine ("      MMMX   *MMMM*  MM       ~%:           !Mh.*** dMI IMMP");
			Console.WriteLine ("      'MMM.                                             IMX");
			Console.WriteLine ("       ~M!M                                             IMP");
			Console.WriteLine ("                                                            ");
			Console.WriteLine ("                ===========================                 ");
			Console.WriteLine ("                [THE BATTLE SIMULATOR 2013]                 ");
			Console.WriteLine ("                ===========================                 ");
			Console.WriteLine ("                                                            ");
			Console.WriteLine ("                                                            ");
			
			
			//We Create a new pokemon ID, Name, HP, Atk, Def
			/*movelist someTemp = new movelist();
			movelist[] tempArray = new movelist[movelist.moves.ember];*/
			
			//someback someTest = new someback();
			
			pokemon Charmander = new pokemon(4,"Charmander",39,53,43,65,pokemon.theType.fire);
			//We show Charmander' stats	
			Charmander.showPkmnStats();
			
			
			
			//We add Charmander to the flow
			//battleFlow.Add(Charmander);
			
			//We add Charmander as a participant
			participants.Add(Charmander);
			
			
			//We Create a new pokemon ID, Name, HP, Atk, Def
			pokemon Pikachu = new pokemon(25,"Pikachu",35,55,30,90,pokemon.theType.electric);
			//We show Pikachu's stats	
			Pikachu.showPkmnStats();
			//We add Pikachu to the flow
			//battleFlow.Add(Pikachu);
			//We add Pikachu as a participant
			participants.Add(Pikachu);
			
			//We set the pokemon battleflow
			calculate calPkmnOrder = new calculate();
			battleFlow = calPkmnOrder.setBattleFlow(Charmander, Pikachu);
			
			
			
			//We check the order the pokemon will battle.
			foreach(pokemon things in battleFlow){
				
				//Console.WriteLine("The PKMN: " + things.name);
			}
			
	
			//<Change Phase>When the initalization is done we move to the next phase; Battle
			return gamePhase.battle;
		}
		
		
		
		
		
		
		//=======================
		//<!>Phase: BATTLE
		public static gamePhase phaseBattle(List<pokemon> someImportedArray){
			
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
			
				Console.WriteLine("Pkmn Name: " + participants[0].name + "  Pkmn Hp: " + participants[0].hp + "  Status " + participants[0].pkmnStatus);
				Console.WriteLine("Pkmn Name: " + participants[1].name + "  Pkmn Hp: " + participants[1].hp + "  Status " + participants[1].pkmnStatus);
				Console.WriteLine(" ");
				calculatePkmn.pokemonAttack(battleFlow[turns], battleFlow[turns+1]);
				//The pkmn that just attacked  is been moved at the end of the battleflow but  [pkmn1, pkmn2, pkmn1, here we will move pkmn2]
				battleFlow.Add(battleFlow[turns]);
				
				Console.WriteLine("Pkmn Name: " + participants[0].name + "  Pkmn Hp: " + participants[0].hp + "  Status " + participants[0].pkmnStatus);
				Console.WriteLine("Pkmn Name: " + participants[1].name + "  Pkmn Hp: " + participants[1].hp + "  Status " + participants[1].pkmnStatus);
				
				//We increment the turns
				turns ++;
				
				//If a pokemon Faints we end the Battle
				if(battleFlow[turns].pkmnStatus == pokemon.status.fainted || battleFlow[turns+1].pkmnStatus == pokemon.status.fainted ){
					//If a pokemon Faints we break from this loop and read the code that follows
					break;
				}
				
			}

			
			//<Change Phase> The battle is over so we show the game over
			return gamePhase.gameover;
		}
		
		
		
		//=======================
		//<!>Phase: GAMEOVER
		public static gamePhase phaseGameover(){
			Console.WriteLine("GAME - OVER");
			
			
			//<Change Phase> Game is over so we quick
			return gamePhase.credits;
		}
		
		
		
		//=======================
		//<!>Phase: CREDITS
		public static gamePhase phaseCredits(){
			Console.WriteLine("THANK YOU FOR PLAYING POKEMON C# Version!");
			Console.WriteLine("@ 2013 Copypasta Rigths None!");
			
			//<Change Phase> Game is over so we quick
			return gamePhase.quit;
		}
		
		//-------------------------------------------------------------------------------------------------------------------------
		//----------------------------------------------------------FSM END---------------------------------------------------------------
		//-------------------------------------------------------------------------------------------------------------------------
		
		
		
	}//End MainClass
	
	
	
	
	
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
		public theType assignType;
		//public movelist[,,,] moveSet; 
		//public string[,,,,] theMovesList;
		
		
		public enum status{
			canBattle,
			fainted,
			poisoned,
			confused,
			paralysed,
			burned
		}
		
		
		public enum theType{
			grass,
			fire,
			water,
			electric,
			rock,
			normal
		}
		
		
		//We make a constructor to set it
		public pokemon(int pkmnId, string pkmnName, int pkmnHp, int pkmnAttack,  int pkmnDefense, int pkmnSpeed, theType pkmnType /*, movelist pkmnMoveSet*/){
			id = pkmnId;
			name = pkmnName;
			hp = pkmnHp;
			attack = pkmnAttack;
			defense = pkmnDefense;
			speed = pkmnSpeed;
			assignType = pkmnType;
		//	moveSet = pkmnMoveSet;
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
			Console.WriteLine("TYPE: " + assignType);
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
		
		
		
	}//End pkmn Class
	
	
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
		
		
	}//End Calculate Class
	
	
	///////////////////
	/// Class Movelist.
	///////////////////
	//Might not use it
	class movelist{
		enum moves{
			none,
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
		
	}//End Movelis Class
}
