using System.Collections;

Player player = new Player();




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
}

class EnemyHealer : Enemy{
    public void recover(){
        
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

    public void equipWeapon(Weapon weapon){

    }

    public void equipArmour(Armour armour){

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