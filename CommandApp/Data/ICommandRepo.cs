using CommandApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandApp.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);

        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}
