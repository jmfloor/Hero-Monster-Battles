using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeroMonsterBattles
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            character Hero = new character("Hero",100,50,false);
            character Monster = new character("Monster", 100,50,false);

            Dice dice = new Dice();

            DisplayStats(Hero);
            DisplayStats(Monster);
            resultLabel.Text += "<br /> ========= <br />";


            Monster.Defend(Hero.Attack(dice));
            Hero.Defend(Monster.Attack(dice));


            DisplayStats(Hero);
            DisplayStats(Monster);
        }

        private void DisplayStats(character character)
        {
            string result = resultLabel.Text + "<br />";

            result += character.Name + "<br />" +
                "Health: " + character.Health + "<br />" +
                "Damage Maximum: " + character.DamageMaximum + "<br />" +
                "Attach Bonus: " + character.AttackBonus + "<br />";

            resultLabel.Text = result;
        }
    }

    class character
    {
        public string Name { get; set; }
        public int Health  { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public character(string name, int health, int damageMaximum, bool attackBonus)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Health = health;
            DamageMaximum = damageMaximum;
            AttackBonus = attackBonus;
        }

        public int Attack(Dice dice)
        {
            return dice.Roll(this.DamageMaximum);
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
        
    }

    class Dice
    {
        public int Sides { get; set; }

        Random random = new Random();

        public int Roll(int sides)
        {
            return random.Next(sides);
        }
    }
}