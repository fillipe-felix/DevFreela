using System;
using System.Collections.Generic;
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minhas descrição de projeto 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Minhas descrição de projeto 2", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Minhas descrição de projeto 3", 1, 1, 30000),
            };

            Users = new List<User>
            {
                new User("Fillipe", "fillipe@gmail.com", new DateTime(1993,07,18)),
                new User("João", "joao@gmail.com", new DateTime(2001,07,20)),
                new User("Pedro", "pedro@gmail.com", new DateTime(1996,05,10)),
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core", DateTime.Now),
                new Skill("C#", DateTime.Now),
                new Skill("SQL", DateTime.Now)
            };
        }
        
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}