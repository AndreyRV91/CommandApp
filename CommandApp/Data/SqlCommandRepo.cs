
using CommandApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandApp.Data
{
    public class SqlCommandRepo : ICommandRepo
    {
        private readonly CommandContext _context;

        public SqlCommandRepo(CommandContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException();
            }

            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAppCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }
    }
}
