using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP3WSRest.Models.EntityFramework;
using TP3WSRest.Models.Repository;

namespace TP3WSRest.Models.DataManager
{
    public class CompteManager : IDataRepository<Compte>
    {
        readonly WSFilmsContext _wSFilmsContext;
        public CompteManager(WSFilmsContext context)
        {
            _wSFilmsContext = context;
        }
        public async Task<ActionResult<IEnumerable<Compte>>> GetAll()
        {
            return _wSFilmsContext.Comptes.ToList();
        }
        public async Task<ActionResult<Compte>> GetById(int id)
        {
            return await _wSFilmsContext.Comptes
            .FirstOrDefaultAsync(e => e.CompteId == id);
        }
        public async Task<ActionResult<Compte>> GetByString(string mail)
        {
            return await _wSFilmsContext.Comptes
            .FirstOrDefaultAsync(e => e.Mel.ToUpper() == mail.ToUpper());
        }
        public async Task Add(Compte entity)
        {
            _wSFilmsContext.Comptes.Add(entity);
            await _wSFilmsContext.SaveChangesAsync();
        }
        public async Task Update(Compte compte, Compte entity)
        {
            _wSFilmsContext.Entry(compte).State = EntityState.Modified;
            compte.CompteId = entity.CompteId;
            compte.Nom = entity.Nom;
            compte.Prenom = entity.Prenom;
            compte.Mel = entity.Mel;
            compte.Rue = entity.Rue;
            compte.CodePostal = entity.CodePostal;
            compte.Ville = entity.Ville;
            compte.Pays = entity.Pays;
            compte.Latitude = entity.Latitude;
            compte.Longitude = entity.Longitude;
            compte.Pwd = entity.Pwd;
            compte.TelPortable = entity.TelPortable;
            compte.FavorisCompte = entity.FavorisCompte;
            await _wSFilmsContext.SaveChangesAsync();
        }
        public async Task Delete(Compte compte)
        {
            _wSFilmsContext.Comptes.Remove(compte);
            await _wSFilmsContext.SaveChangesAsync();
        }
    }
}
