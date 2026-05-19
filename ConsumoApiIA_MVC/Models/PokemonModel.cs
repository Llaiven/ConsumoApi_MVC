using System.Collections.Generic;

namespace ConsumoApiIA_MVC.Models
{
    public class PokemonModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<TypeSlot> Types { get; set; }
        public Sprites Sprites { get; set; }
        public List<StatSlot> Stats { get; set; }
    }

    public class TypeSlot
    {
        public TypeInfo Type { get; set; }
    }

    public class TypeInfo
    {
        public string Name { get; set; }
    }

    public class Sprites
    {
        public string Front_Default { get; set; }
    }

    public class StatSlot
    {
        public int Base_Stat { get; set; }
        public StatInfo Stat { get; set; }
    }

    public class StatInfo
    {
        public string Name { get; set; }
    }
}