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
            character Hero = new character("Hero",100,50,10);
            character Monster = new character("Monster", 100,50,10);

            DisplayStats(Hero);
            DisplayStats(Monster);
            resultLabel.Text += "<br /> ========= <br />";


            Monster.defend(Hero.attack());
            Hero.defend(Monster.attack());


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
        public int AttackBonus { get; set; }

        public character(string name, int health, int damageMaximum, int attackBonus)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Health = health;
            DamageMaximum = damageMaximum;
            AttackBonus = attackBonus;
        }

        public int attack()
        {
            Random random = new Random();
            
            return random.Next(this.DamageMaximum);

        }

        public int defend(int damage)
        {
            this.Health -= damage;
            return this.Health;

        }
        public string showCharacterStats()
        {
            string result = "";
            result += this.Name + "<br />" +
                "Health: " + this.Health + "<br />" +
                "Damage Maximum: " + this.DamageMaximum + "<br />" +
                "Attach Bonus: " + this.AttackBonus + "<br />";

            return result;
        }

        public string showAttack(int attackValue)
        {
            return "";   
        }
    }
}