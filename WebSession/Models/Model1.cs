namespace WebSession.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1") {}

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Personne> Personnes { get; set; }
    }
    public class Personne
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Login { get; set; }
        [Required]
        [MinLength(2)]
        public string Password { get; set; }
    }
    public class Item
    {
        public Item(){}
        public Item(string nom, int prix, string detail)
        {
            Nom = nom;
            Prix = prix;
            Detail = detail;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public int Prix { get; set; }
        public string Detail { get; set; }
    }
}