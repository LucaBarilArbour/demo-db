using Demo.Data.Models;
using Demo.Data.Models.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data
{
    public class DataSeeder
    {
        private readonly DemoDbContext _context;

        public DataSeeder(DemoDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // S'il y'a déjà des données dans la table Clients
            if (_context.Clients.Any())
                return;

            // Créer les données initiales 
            List<Client> clients = new List<Client>
            {
                new Client("Jean", "Dupont", true, gateauPreferee: TypeGateau.Tarte),
                new Client("Marie", "Martin", false, gateauPreferee: TypeGateau.Entremet),
                new Client("Pierre", "Bernard", true, gateauPreferee: TypeGateau.Etages),
                new Client("Sophie", "Petit", false, gateauPreferee: TypeGateau.Tarte),
                new Client("Luc", "Moreau", true, gateauPreferee: TypeGateau.Design)
            };

            // Ajouter les données initiales au contexte de base de données.
            _context.AddRange(clients);
            _context.SaveChanges();

        }
    }
}
