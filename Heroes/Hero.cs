namespace Heroes
{
    using System.Text;

    public class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Hero: {this.Name} – {this.Level}lvl");
            result.AppendLine($"Item:");
            result.AppendLine($"  * Strength: {this.Item.Strength}");
            result.AppendLine($"  * Ability: {this.Item.Ability}");
            result.AppendLine($"  * Intelligence: {this.Item.Intelligence}");

            return result.ToString().TrimEnd();
        }
    }
}
