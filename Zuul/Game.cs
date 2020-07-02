using System;
using System.Media;

namespace Zuul
{
	public class Game
	{
		private Parser parser;
		private Player player;
        public Hammer hammer;
        public Potion potion;

		public Game ()
		{
			player = new Player();
			createRooms();
			parser = new Parser();
			
		}

		private void createRooms()
		{
			Room outside, theatre, pub, lab, office, labSecondStory;


            //create items
            hammer = new Hammer("hammer", 5);
            potion = new Potion("BrokenBottle", 1);

			// create the rooms
			outside = new Room("outside the main entrance of the university");
			theatre = new Room("in a lecture theatre");
			pub = new Room("in the campus pub");
			lab = new Room("in a computing lab");
			office = new Room("in the computing5 admin office");
			labSecondStory = new Room("at the second story of the computing lab");

			// initialise room exits
			outside.setExit("east", theatre);
			outside.setExit("south", lab);
			outside.setExit("west", pub);

			theatre.setExit("west", outside);

			pub.setExit("east", outside);
			 
			lab.setExit("north", outside);
			lab.setExit("east", office);
			lab.setExit("up", labSecondStory);

			labSecondStory.setExit("down", lab);

			office.setExit("west", lab);

			player.currentRoom = outside;  // start game outside

			//add inventories to rooms

			outside.inventory.Put(hammer);
            outside.inventory.Put(potion);
		}


		/**
	     *  Main play routine.  Loops until end of play.
	     */
		public void play()
		{
			printWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the game is over.
			bool finished = false;
			while (! finished) {
				Command command = parser.getCommand();
				finished = processCommand(command);
			}
			if (player.alive == false)
			{
				Console.WriteLine("The player died");
			}
			else { 
				Console.WriteLine("Thank you for playing."); 
			}
		}

		/**
	     * Print out the opening message for the player.
	     */
		private void printWelcome()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Zuul!");
			Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
			Console.WriteLine("Type 'help' if you need help.");
			Console.WriteLine();
			Console.WriteLine(player.currentRoom.getLongDescription());
            Console.WriteLine("your life total is" + " " + player.health);
        }

		/**
	     * Given a command, process (that is: execute) the command.
	     * If this command ends the game, true is returned, otherwise false is
	     * returned.
	     */
		private bool processCommand(Command command)
		{
			bool wantToQuit = false;

			if(command.isUnknown()) {
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.getCommandWord();
			switch (commandWord) {
				case "help":
					printHelp();
					break;
				case "go":
					player.damage(1);
                    Console.WriteLine("your life total is" + " " + player.health);
                    player.isAlive();
					if (player.alive == false) {
						wantToQuit = true;
					}
					goRoom(command);
					//Console.WriteLine(player.health);
					break;
				case "quit":
					wantToQuit = true;
					break;
				case "look":
					goLook();
					break;
                case "take":
                    goTake(command);
                    break;
                case "drop":
                    goDrop(command);
                    break;
			}

			return wantToQuit;
		}

        // implementations of user commands:

        /**
	     * Print out some help information.
	     * Here we print some stupid, cryptic message and a list of the
	     * command words.
	     */

        private void goTake(Command command)
        {
            string itemToPickup = command.getSecondWord();
        }

        private void goDrop(Command command)
        {

        }

        private void goLook() 
		{
			Console.WriteLine(player.currentRoom.getLongDescription());
		
		}
		
		
		
		private void printHelp()
		{
			Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine("You wander around at the university.");
			Console.WriteLine();
			Console.WriteLine("Your command words are:");
			parser.showCommands();
		}

		/**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */
		private void goRoom(Command command)
		{
			if(!command.hasSecondWord()) {
				// if there is no second word, we don't know where to go...
				Console.WriteLine("Go where?");
				return;
			}

			string direction = command.getSecondWord();

			// Try to leave current room.
			Room nextRoom = player.currentRoom.getExit(direction);

			if (nextRoom == null) {
				Console.WriteLine("There is no door to "+direction+"!");
			} else {
				player.currentRoom = nextRoom;
				Console.WriteLine(player.currentRoom.getLongDescription());
			}
		}

	}
}
