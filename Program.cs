using System.Collections;


Player player = new Player();
Random random = new Random();



class Character{
    public int health;
    public int maxHealth;
    public int shield;
    public int strength;

    public void attack(Character target){
    }
}

class Enemy : Character{
    public int weaponDamage;

    public Enemy(Player player){
        Random random = new Random();

        health = random.Next(5,9);
        maxHealth = health;
        shield = random.Next(3);
        weaponDamage = random.Next(2,4);
        Battle battle = new Battle(player,this);
    }
}
/*
class EnemyHealer : Enemy{
    public void recover(){
        
    }

    public EnemyHealer(Player player){

    }
}
*/
class Battle{
    public Battle(Player player, Character target){
        bool battleActive = true;
        while(battleActive){
            printBattleMenu(player,target);
            enemyTurn(player,target);
            checkForEnd(player,target);
        }
    }

    public void printBattleMenu(Player player, Character target){
        bool inputCorrect = false;
        while(!inputCorrect){
            int inputInt = 0;
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Open inventory");
            Console.WriteLine("3. Flee");
            string input = Console.ReadLine();
            bool inputIsInt = int.TryParse(input, out inputInt);
            if(!inputIsInt){
                Console.WriteLine("Please input a number between 1 and 3");
                Console.WriteLine("Press [Enter] to try again");
                Console.ReadLine();
            }
            else if(inputInt == 1){
                inputCorrect = true;
                player.attack(target);
            }
            else if(inputInt == 2){
                inputCorrect = true;
                /*
                inventory
                */
            }
            else if(inputInt == 3){
                inputCorrect = true;
                /*
                flee
                */
            }
        }
    }

    public void enemyTurn(Player player, Character enemy){
        enemy.attack(player);
    }

    public void checkForEnd(Player player, Character target){
        if(player.health <= 0){
            Console.WriteLine("You have died");
            Console.WriteLine("Press [Enter] to continue");
            Console.ReadLine();
            playerDeath(player);
        }
        else if (target.health <= 0){
            Console.WriteLine("Enemy killed");
            Console.WriteLine("Press [Enter] to continue");
            Console.ReadLine();
            enemyDeath(target);
        }
    }

    public void playerDeath(Player player){
    }

    public void enemyDeath(Character enemy){
    }
}

class Player : Character{
    public Inventory inventory = new Inventory();
    public Weapon activeWeapon;
    public Map map = new Map();

    public void move(int direction){

    }

    public void openInventory(){

    }

    public Player(){
        Weapon activeWeapon = new Weapon(1,"Wooden Stick");
        inventory.items.Add(activeWeapon);
        maxHealth = 20;
        health = maxHealth;
    }
}

class Map{
    public int roomsCleared;
    public int playerX;
    public int playerY;

    
    private string[] emptyRoom = {
        "____    ____",
        "|          |",
        "|          |",
        "|          |",
        "|          |",
        "|          |",
        "----    ----"
    };
    private string[] clearedRoom = {
        "____    ____",
        "|          |",
        "|       /  |",
        "|   \\  /   |",
        "|    \\/    |",
        "|          |",
        "----    ----"
    };
    private string[] enemyRoom = {
        "____    ____",
        "|    ___   |",
        "|   (* *)  |",
        "|   __|__  |",
        "|     |    |",
        "|    / \\   |",
        "------------"
    };
    private string[] corridorDown = {
        "   |    |   ",
        "   |    |   ",
        "   |    |   ",
        "   |    |   ",
    };
    private string[] corridorSide = {
        "          ",
        "          ",
        "----------",
        "          ",
        "----------",
        "          ",
        "          ",
    };


    private void printRoom(string[] room){
        for(int i = 0; i < room.Length; i++){
            Console.WriteLine(room[i]);
        }
    }
    
    private void printColumn(string[] room1, string[] room2, string[] room3){
        for(int i = 0; i < room1.Length;i++){
            Console.Write(room1[i]);
            Console.Write(room2[i]);
            Console.WriteLine(room3[i]);
        }
    }

    public void printMap(){

    }

    public Map(){
        playerX = 0;
        playerY = 0;
        roomsCleared = 0;
        printRoom(clearedRoom);
        printRoom(corridorDown);
        printColumn(clearedRoom, corridorSide, clearedRoom);
    }
}

class Inventory{
    public ArrayList items = new ArrayList();

    public Weapon equipWeapon(Weapon weapon){
        return weapon;
    }

    public Armour equipArmour(Armour armour){
        return armour;
    }
}

class Item{
    public string name;
}

class Weapon : Item{
    public int damage;

    public Weapon(int damage, string nameInput){
        name = nameInput;
    }
}

class Armour : Item{
    public int defence;
}

class Consumable : Item{
    public int usesLeft;
    public int healthRestored;

    public void use(Player target){

    }
}