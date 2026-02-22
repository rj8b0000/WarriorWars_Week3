using WarriorWars.Enum;
using WarriorWars.Equipment;
namespace WarriorWars
{
    public class Warrior
    {
        private const int  GOOD_GUY_STARTING_HEALTH = 100;
        private const int  BAD_GUY_STARTING_HEALTH = 100;
        
        private Faction FACTION;

        private int health;
        private string name;
        private bool isAlive;
        public bool IsAlive { get; }

        private Weapon weapon;
        private Armor armor;

        public Warrior(string name, Faction faction)
        {
            this.name = name;
            this.FACTION = faction;
            this.isAlive = true;

            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
                default:
                    break;
            }
        }

        public void Attack(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;
            enemy.health -= damage;

            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                System.Console.WriteLine($"{enemy.name} is dead! {name} is victorious!");
            }
            else
            {
                System.Console.WriteLine($"{name} attacked {enemy.name}. {damage} was inflicted, remaining health is {enemy.health}!");
            }
            
        }
    
    }
}
