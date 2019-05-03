namespace Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class HeroRepository
    {
        public Dictionary<int, Hero> heroes;
        private int id;

        public HeroRepository()
        {
            this.heroes = new Dictionary<int, Hero>();
            this.id = 0;
        }

        public void Add(Hero hero)
        {
            this.heroes.Add(id++, hero);
        }

        public void Remove(string name)
        {
            foreach (var hero in heroes)
            {
                if (hero.Value.Name == name)
                {
                    int keyToRemove = hero.Key;
                    heroes.Remove(keyToRemove);
                    break;
                }
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            int id = -1;
            int maxStrenght = -1;

            foreach (var hero in heroes)
            {
                if (hero.Value.Item.Strength > maxStrenght)
                {
                    id = hero.Key;
                    maxStrenght = hero.Value.Item.Strength;
                }
            }
            var heroWithMaxStrenght = heroes[id];
            return heroWithMaxStrenght;
        }

        public Hero GetHeroWithHighestAbility()
        {
            int id = -1;
            int maxAbility = -1;

            foreach (var hero in heroes)
            {
                if (hero.Value.Item.Ability > maxAbility)
                {
                    id = hero.Key;
                    maxAbility = hero.Value.Item.Ability;
                }
            }
            var heroWithMaxStrenght = heroes[id];
            return heroWithMaxStrenght;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            int id = -1;
            int maxIntelligence = -1;

            foreach (var hero in heroes)
            {
                if (hero.Value.Item.Intelligence > maxIntelligence)
                {
                    id = hero.Key;
                    maxIntelligence = hero.Value.Item.Intelligence;
                }
            }
            var heroWithMaxStrenght = heroes[id];
            return heroWithMaxStrenght;
        }

        public int Count => this.heroes.Count;


        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var hero in heroes)
            {
                result.AppendLine(hero.Value.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
