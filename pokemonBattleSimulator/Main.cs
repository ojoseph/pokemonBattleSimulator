using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;


namespace pokemonBattleSimulator
{
	public class MainClass{
	
		//We might use it to determine the game phases
		public enum gamePhase{	
			init,
			battle,
			gameover,
			credits,
			quit
		}
		
		//Will define the turn of the Pokemons/Trainers 
		public static List<pokemon> battleFlow = new List<pokemon>();
		//Let us know which pokemon will fight 
		public static List<pokemon> participants = new List<pokemon>();
		//Let us know which Trainers will  be in the game 
		public static List<trainer> participatingTrainers = new List<trainer>();
		
		public static void Main (string[] args){	

			
			////////////////////
			//Simple FSM
			gamePhase currPhase = gamePhase.init; 
			
			while(currPhase != gamePhase.quit){
		
				switch(currPhase){
					case gamePhase.init:
						Console.WriteLine(" ");
						//Console.WriteLine("GAME PHASE: INIT");
						currPhase = phaseInit();
					break;
					case gamePhase.battle:
						Console.WriteLine(" ");
						Console.WriteLine("GAME PHASE: BATTLE");
						//Console.WriteLine(participants);
						currPhase = phaseBattle(participants, participatingTrainers);
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
			//Console.WriteLine("ENTER - INIT");
			
			
			
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
			
			
			
			
			
			
			
			
			
			
			
			
			/*movelist someTemp = new movelist();
			movelist[] tempArray = new movelist[movelist.moves.ember];*/
			
			//We set the move list for the first Pokemon
			List<pokemon.moves> SquirtleMVList = new List<pokemon.moves>();
			SquirtleMVList.Add(pokemon.moves.bite);
			SquirtleMVList.Add(pokemon.moves.watergun);
			SquirtleMVList.Add(pokemon.moves.tackle);
			SquirtleMVList.Add(pokemon.moves.surf);
			Console.WriteLine("##################");
			
			
			//We Create a new pokemon ID, Name, HP, Atk, Def, Speed
			pokemon Squirtle = new pokemon(7,"Squirtle",44,48,65,43,pokemon.theType.water, SquirtleMVList);
			//We show Squirtle' stats	
			Squirtle.showPkmnStats();
			
			
			
			//We space the info out a bit.
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			
			
			
			
			/*movelist someTemp = new movelist();
			movelist[] tempArray = new movelist[movelist.moves.ember];*/
			
			//We set the move list for the first Pokemon
			List<pokemon.moves> CharmanderMVList = new List<pokemon.moves>();
			CharmanderMVList.Add(pokemon.moves.bite);
			CharmanderMVList.Add(pokemon.moves.ember);
			CharmanderMVList.Add(pokemon.moves.slash);
			CharmanderMVList.Add(pokemon.moves.fireSpin);
			Console.WriteLine("##################");
			
			//We check the moves that charmander holds
			foreach(pokemon.moves things in CharmanderMVList){
				
			//	Console.WriteLine("Moves: " + things);
			}
			
			//We Create a new pokemon ID, Name, HP, Atk, Def
			pokemon Charmander = new pokemon(4,"Charmander",39,53,43,65,pokemon.theType.fire, CharmanderMVList);
			//We show Charmander' stats	
			Charmander.showPkmnStats();
			
			
			//<DEBUG> Charmander.testMovesArray[pokemon.moves.bite, pokemon.moves.bite,pokemon.moves.bite,pokemon.moves.bite];
			/*Charmander.testMovesArray[0,0,0,0] = pokemon.moves.ember;
			
			Charmander.testMovesArray tails = new Charmander.testMovesArray();*/
			
			
			
			//We space the info out a bit.
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			
			
			//We set the move list for the first Pokemon
			List<pokemon.moves> PikachuMVList = new List<pokemon.moves>();
			PikachuMVList.Add(pokemon.moves.thundershock);
			PikachuMVList.Add(pokemon.moves.quickAttack);
			PikachuMVList.Add(pokemon.moves.voltTackle);
			PikachuMVList.Add(pokemon.moves.surf);
			
			//<DEBUG>We check the moves that pikachu holds
			foreach(pokemon.moves somethings in PikachuMVList){
				
			//	Console.WriteLine("Moves: " + somethings);
			}
			
			//We Create a new pokemon ID, Name, HP, Atk, Def
			pokemon Pikachu = new pokemon(25,"Pikachu",35,55,30,90,pokemon.theType.electric, PikachuMVList);
			//We show Pikachu's stats	
			Pikachu.showPkmnStats();
			//We add Pikachu to the flow
			//battleFlow.Add(Pikachu);
			
			
			//We set the pokemon battleflow
			/*calculate calPkmnOrder = new calculate();
			battleFlow = calPkmnOrder.setBattleFlow(Charmander, Pikachu);*/
			
			
			//We space this out a bit, gotta keep it clean
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			
			
			
			
			
			
			
			
			//////////////////////////
			//////////////////////////
			//CREATE PKMN TRAINER
			//////////////////////////
			//////////////////////////
			
			//We set the move list for the first Pokemon
			List<pokemon> pkmnTeamListTrainer1 = new List<pokemon>();
			
			trainer trainerLass = new trainer("Anna", trainer.e_classType.lass, pkmnTeamListTrainer1);
			Console.WriteLine("Trainer: " + trainerLass.name + " " + trainerLass.trainerClass + " " + trainerLass.team.Count);
			
			//We assign pikachu to a trainer
			Pikachu.trainerName = trainerLass.name;
			//We add pikachu to the trainer's team.
			pkmnTeamListTrainer1.Add(Pikachu);
			
			
			
			
			
			//##### SQUIRTLE #########
			//We assign squirtle to a trainer
			Squirtle.trainerName = trainerLass.name;
			//We add the pokemon to trainer1's team
			pkmnTeamListTrainer1.Add(Squirtle);
			
			
			Console.WriteLine("Trainer: " + trainerLass.name + " " + trainerLass.trainerClass + " " + trainerLass.team.Count + " Pkmn in the Team");
			
			//Console.WriteLine("Trainer: " + trainerLass.name + " " + trainerLass.trainerClass + " " + trainerLass.team.Count + " " + trainerLass.team[0].name);
			//We show the trainer's Stats
			trainerLass.showTrainerStats();
			
			//We add Pikachu as a participant
			participants.Add(trainerLass.team[0]);
			//Lass joins the fight
			participatingTrainers.Add(trainerLass);
			trainerLass.showTrainerStats();
			
			//We clear the table and get it ready for the next trainer
			//pkmnTeamList.Clear();
			
			
			
			
			
			
			
			//We set the move list for the first Pokemon
			List<pokemon> pkmnTeamListTrainer2 = new List<pokemon>();
			
			//We create a new trainer.
			trainer trainerCoolgtrainer = new trainer("Amaya", trainer.e_classType.coolTrainer, pkmnTeamListTrainer2);
			//Console.WriteLine("Trainer: " + trainerCoolgtrainer.name + " " + trainerCoolgtrainer.trainerClass + " " + trainerCoolgtrainer.team.Count + " " + trainerCoolgtrainer.team[0].name);
			
			
			//We assign charmander to a trainer
			Charmander.trainerName = trainerCoolgtrainer.name;
			//We put charmander in the list we want to add to the trainer
			pkmnTeamListTrainer2.Add(Charmander);
			//Cool trainer joins the fight
			participatingTrainers.Add(trainerCoolgtrainer);
			
			Charmander.showPkmnStats();
			
			//We show the trainer's Stats
			trainerCoolgtrainer.showTrainerStats();
			
			//We add Charmander as a participant
			participants.Add(trainerCoolgtrainer.team[0]);
			
			
			//Show trainer Lass's stats
			trainerLass.showTrainerStats();
			
			
			
			
			
			
			
			//Add the trainer's pokemon in the battleflow
			//We set the pokemon battleflow
			calculate calPkmnOrder = new calculate();
			battleFlow = calPkmnOrder.setBattleFlow(trainerCoolgtrainer.team[0], trainerLass.team[0]);
			
			
			
			
			
			
			
			// <DEBUG> We check the order the pokemon will battle.
			foreach(pokemon thingddddds in battleFlow){
				
				//Console.WriteLine("The PKMN: " + things.name);
			}
			
	
			//<Change Phase>When the initalization is done we move to the next phase; Battle
			return gamePhase.battle;
		}
		
		
		
		
		
		
		//=======================
		//<!>Phase: BATTLE
		public static gamePhase phaseBattle(List<pokemon> someImportedArray, List<trainer> someImportedTrainersArray){
			
			//////////////////////////////
			//We Enter Battle
			//////////////////
			Console.WriteLine("BATTLE START");
			
			//Calculate the number of turns passed
			int turns = 0;
			
			//As long that the pokemon can fight we keep going on.
			//while(participants[0].pkmnStatus == pokemon.status.canBattle || participants[1].pkmnStatus == pokemon.status.canBattle ){	
			
			//We changed the condition so that the game ends if the trainer has no more pokemon to send out.
			while(someImportedTrainersArray[0].hasPkmnToBattle == true || someImportedTrainersArray[1].hasPkmnToBattle == true ){		
				
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
					
					
					
					if(participants[0].pkmnStatus == pokemon.status.fainted){
						//Console.WriteLine("FIRST pokemon has fainted");
							
						trainerCanBattle(someImportedArray,0, someImportedTrainersArray);
						
						
						//Before we Start anything we check the train can fight, if no we swtich its status to false. and it ends the battle
						
						//Checks out how many pkmn fainted
						int faintedPkmnCounter = 0;
						//We go through the whole pokemon team and check if the trainer can still fight
						for(int y = 0; y < someImportedTrainersArray[0].team.Count; y++ ){
							if(someImportedTrainersArray[0].team[y].pkmnStatus == pokemon.status.fainted ){
								faintedPkmnCounter++;
								if(faintedPkmnCounter == someImportedTrainersArray[0].team.Count){
									
									//The trainer is unable to battle so we end this.
									someImportedTrainersArray[0].hasPkmnToBattle = false;
								}
							}
						}
						
						
						//The trainer has still some pokemon left and send it to battle.
						if(someImportedTrainersArray[0].hasPkmnToBattle == true){
								Console.WriteLine("     ");
								Console.WriteLine("     ");
								Console.WriteLine("     ");
								Console.WriteLine("TRAINER SENDS ANOTHER POKEMON OUT!!!!!!!!!");
								Console.WriteLine("TRAINER SENDS ANOTHER POKEMON OUT!!!!!!!!!");
								Console.WriteLine("TRAINER SENDS ANOTHER POKEMON OUT!!!!!!!!!");
								Console.WriteLine("TRAINER SENDS ANOTHER POKEMON OUT!!!!!!!!!");
						
								
							
								for(int y = 0; y < someImportedTrainersArray[0].team.Count; y++ ){

									if(someImportedTrainersArray[0].team[y].pkmnStatus == pokemon.status.canBattle){
										Console.WriteLine("We have another pokemon that we can send out");
										//Once we found the new target we break from the loop.
										participants[0] = someImportedTrainersArray[0].team[y];
										//battleFlow = calPkmnOrder.setBattleFlow(trainerCoolgtrainer.team[0], trainerLass.team[y]);
										
									
										//  We update the battle flow to determine the turns.
										foreach(pokemon currFigthing in battleFlow){
											
											
											if(currFigthing.pkmnStatus == pokemon.status.fainted){
												Console.WriteLine("The PKMN: " + currFigthing.name + " HAS FAINTED AND WILL BE REMOVED");
												
											//We update the battle flow by switching the fainted pokemon for one that can battle,
												battleFlow[turns] = someImportedTrainersArray[0].team[y];
											}
										}
									
										break;
										// <!> We need to  put that pokemon in a var that we can lated assign below for the switch
									}
								}
							
								//We make the pkmn switch here
								//participants[0] = someImportedTrainersArray[0].team[1];
							
							
						}else{
							Console.WriteLine("Trainer Lass: Oh no! I have lost >_<  ");	
							break;
						}
						
					}//End if  First Active  PKMN faints
					
					
					
					if(participants[1].pkmnStatus == pokemon.status.fainted){
							//Console.WriteLine("SECOND pokemon has fainted");
							trainerCanBattle(someImportedArray,1, someImportedTrainersArray);
							
						
						
							//Before we Start anything we check the train can fight, if no we swtich its status to false. and it ends the battle
							
							//Checks out how many pkmn fainted
							int faintedPkmnCounter = 0;
							//We go through the whole pokemon team and check if the trainer can still fight
							for(int y = 0; y < someImportedTrainersArray[0].team.Count; y++ ){
								if(someImportedTrainersArray[0].team[y].pkmnStatus == pokemon.status.fainted ){
									faintedPkmnCounter++;
									if(faintedPkmnCounter == someImportedTrainersArray[0].team.Count){
										
										//The trainer is unable to battle so we end this.
										someImportedTrainersArray[0].hasPkmnToBattle = false;
									}
								}
							}
						
						
							if(someImportedTrainersArray[1].hasPkmnToBattle == true){
								//If the trainer has another pkmn we send it out asap	
									for(int y = 0; y < someImportedTrainersArray[0].team.Count; y++ ){
										if(someImportedTrainersArray[0].team[y].pkmnStatus == pokemon.status.canBattle){
											reSlctPkmn(someImportedTrainersArray[1].team[y],battleFlow,someImportedTrainersArray,1,turns);
										}
									}
								
							
								//reSlctPkmn(pokemon willBeFigthing, List<pokemon>battleFlow, List<trainer> someImportedTrainersArray, int indexTrainer, int currTurn ){
							
							}else{
								Console.WriteLine("Cool Trainer: Darn! My pokemon, oh well good fight!");	
								break;
							}
					}
					
					
					//<OLD>If a pokemon Faints we break from this loop and read the code that follows
					//If trainer 1  has no more pokemon to send , than we break the loop. 
					//break;
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
		
		
		
		//Check if the trainer can still battle
		public static  void trainerCanBattle(List<pokemon>  participantPkmn,int indexParticipating, List<trainer>  trainerArray){
		
			
			for(int u = 0; u< trainerArray.Count; u++){
								//Console.WriteLine(someImportedTrainersArray[u].name);
								if(participantPkmn[indexParticipating].trainerName == trainerArray[u].name){
								
									Console.WriteLine(trainerArray[u].name +"'s "+ participantPkmn[indexParticipating].name + " has fainted");
									
									//We check each pokemon that the trainer owns.
									for(int incre = 0; incre < trainerArray[u].team.Count; incre++){
									
										//We reset the counter before use.
										int faintedPkmn = 0;
									
										//We check the number of fainted pokemon
										if(trainerArray[u].team[incre].pkmnStatus == pokemon.status.fainted){
											Console.WriteLine("the pokemon has fainted");
										
											//We mark each fainted pokemon with an increment
											faintedPkmn += 1;
										
											//We check if the trainer's whole team has fainted
											if(faintedPkmn == trainerArray[u].team.Count){
												Console.WriteLine("Trainer "+ trainerArray[u].name +" has no more Pokemon!");
											
												//If there is no more pokemon than the game is over. We change the trainer's status "hasPkmnToBattle" to false. 
												trainerArray[u].hasPkmnToBattle = false;
											}//End faintedPkmn
										
										}//End Check num fainted pkmn
									}//End For loop
								
								}//End if Participant trainer name = trainer name
							}//For loop for the trainer's pokemon team
			

			
		}
		
		
		public static pokemon reSlctPkmn(pokemon willBeFigthing, List<pokemon>battleFlow, List<trainer> someImportedTrainersArray, int indexTrainer, int currTurn ){
			pokemon tempReturnValue = null;
			
			for( int y = 0; y < someImportedTrainersArray[indexTrainer].team.Count; y++ ){
				if(someImportedTrainersArray[0].team[y].pkmnStatus == pokemon.status.canBattle){
					Console.WriteLine("We have another pokemon that we can send out");
					//Once we found the new target we break from the loop.
					participants[0] = someImportedTrainersArray[0].team[y];
					//battleFlow = calPkmnOrder.setBattleFlow(trainerCoolgtrainer.team[0], trainerLass.team[y]);
					
				
					//  We update the battle flow to determine the turns.
					foreach(pokemon currFigthing in battleFlow){
						if(currFigthing.pkmnStatus == pokemon.status.fainted){
							Console.WriteLine("The PKMN: " + currFigthing.name + " HAS FAINTED AND WILL BE REMOVED");
							
						//We update the battle flow by switching the fainted pokemon for one that can battle,
							//battleFlow[currTurn] = someImportedTrainersArray[0].team[y];
							//return someImportedTrainersArray[0].team[y];
							tempReturnValue = someImportedTrainersArray[0].team[y];
						}
					}
					
					break;
					// <!> We need to  put that pokemon in a var that we can lated assign below for the switch
				}
			}
			
				return tempReturnValue;
		}
		
		
	}//End MainClass
	
	
	
	
	
	///////////////////
	/// Class Pokemon.
	///////////////////
	//Our Pokemon Class, we call it when we create a new pokemon
	public class pokemon{
		  
		//The info Concerning the Pokemon goes here
		public int id;
		public string name;
		public int hp;
		public int attack;
		public int defense;
		public int speed;
		public status pkmnStatus = status.canBattle;
		public theType assignType;
		public  List<moves> moveArray = new List<moves>();
		public string trainerName = "none";
		
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
		
		public enum moves{
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
			gust,
			cut,
			fireSpin,
			overheat,
			thunderPunch,
			slash,
			ironTail,
			slam,
			voltTackle,
			surf
		}
		
		
		//We make a constructor to set it
		public pokemon(int pkmnId, string pkmnName, int pkmnHp, int pkmnAttack,  int pkmnDefense, int pkmnSpeed, theType pkmnType, List<moves> pkmnMoveSet){
			id = pkmnId;
			name = pkmnName;
			hp = pkmnHp;
			attack = pkmnAttack;
			defense = pkmnDefense;
			speed = pkmnSpeed;
			assignType = pkmnType;
			moveArray = pkmnMoveSet;
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
			Console.WriteLine("Move1: " + moveArray[0]);
			Console.WriteLine("Move2: " + moveArray[1]);
			Console.WriteLine("Move3: " + moveArray[2]);
			Console.WriteLine("Move4: " + moveArray[3]);
			Console.WriteLine("Belongs to: " + trainerName);
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
	
	class calculate{
		
		
		//We declare the switch in here	
		public	static string updateBattleInfo = "notUpdated";
		
		//Function called through the timer
		public static void DisplayTimeEvent( object source, ElapsedEventArgs e ){
			//Console.Write("\r{0}", DateTime.Now);
			updateBattleInfo = "updateDone";
		}
		
		
		
		
		
		public void pokemonAttack(pokemon atkPkmn, pokemon defPkmn){
			
			//We set a timer in order to update the infos every 3 seconds
			Timer myTimer = new Timer();
			myTimer.Elapsed += new ElapsedEventHandler( DisplayTimeEvent );
			myTimer.Interval = 3000;
			myTimer.Start();
			
			//We use this ftc a switch in order to know  if the infos are updated or not.
			updateBattleInfo = "notUpdated";
			
			//We choose a random move from the pkmn's moveList and display it.
			Random theMvRnd = new Random();
			Console.WriteLine(atkPkmn.name + " USES " + atkPkmn.moveArray[theMvRnd.Next(0,4)]);
			
			//We wait for the updateBattleInfo to be clear in order to  update the infos.
			while(updateBattleInfo != "updateDone"){
				; // do nothing...
			}
			
			//We skip a line to make it clean, you know!
			Console.WriteLine(" ");
			//We atk pikachu and change it Hp.
			defPkmn.hp -= Math.Abs( atkPkmn.attack - defPkmn.defense);
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
/*	class movelist{
		enum moveasdsdasds{
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
		
	}*///End Movelis Class
	
	
	
	
	
	///////////////////
	/// Class Trainer
	///////////////////
	public class trainer{
		//public int id;
		public string name;
		public e_classType trainerClass;
		//public int teamNum;
		/*public int items;
		public int speed;
		public status pkmnStatus = status.canBattle;
		public theType assignType;*/
		public List<pokemon> team = new List<pokemon>();
		public bool hasPkmnToBattle = true;
		
		
		public enum e_classType{
			lass,
			bugCatchter,
			rocketGrunt,
			biker,
			burglar,
			schoolKid,
			coolTrainer
		}
		
		
		
		
		//We make a constructor to set the trainer
		public trainer(string trainerName, e_classType trainerClassType, List<pokemon> trainerTeam){
			name = trainerName;
			//classType = trainerClassType;
			trainerClass = trainerClassType;
			team = trainerTeam;
		}
		
		
		public void showTrainerStats(){
			Console.WriteLine("");
			Console.WriteLine("[Viewing " + trainerClass + "  " + name + " stats]");
			Console.WriteLine("");
			Console.WriteLine("Class: " + trainerClass);
			Console.WriteLine("Name: " + name);
			Console.WriteLine("#Pkmn: " + team.Count);
			Console.WriteLine("Active Pkmn: " + team[0].name);
			Console.WriteLine("Benched Pkmn: " + "None");
		}
		
		
	}//End trainer Class
	
	
}
