using Demo.Data.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data.Data
{
    public class ClientDbDataProvider : IClientDataProvider
    {

        private readonly DemoDbContext _context;

        public ClientDbDataProvider(DemoDbContext context)
        {
            _context = context;
        }

        public void AjouterClient(Client client)
        {
            // prend les donnee de la base de donnee
            _context.Clients.Add(client);
            // sauvegardes les changements 
            _context.SaveChanges();
        }

        public List<Client> GetClients()
        {
            return _context.Clients.OrderBy(c => c.Nom).
                ThenByDescending(c => c.Prenom).ToList();
        }

        public void ModifierClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void SupprimerClient(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
