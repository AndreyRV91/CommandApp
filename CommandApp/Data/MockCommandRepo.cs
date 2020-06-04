using CommandApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandApp.Data
{
    public class MockCommandRepo : ICommandRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>()
            {
                 new Command() { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle and pan" },
                 new Command() { Id = 0, HowTo = "Cut a bread", Line = "Boil water", Platform = "Kettle and pan" },
                 new Command() { Id = 0, HowTo = "Make cup of tea", Line = "Boil water", Platform = "Kettle and pan" }
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command() { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle and pan" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
