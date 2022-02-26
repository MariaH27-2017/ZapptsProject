using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using FluentValidation.Results;
using Zappts.Domain.Interfaces;
using Zappts.Domain.Entities;
using Zappts.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Zappts.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {

        private readonly IBaseRepository<TEntity> _baseRepository;
        private DbSet<TEntity> tableDb;
        private ApplicationDbContext _context { get; }

        public static bool success;
        List<string> erros = new List<string>();

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {

            _baseRepository = baseRepository;

            _context = new ApplicationDbContext();
            tableDb = _context.Set<TEntity>();
            success = true;

        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null) throw new Exception("Parametro nullo");

            //validator.ValidateAndThrow(obj);
            ValidationResult results = validator.Validate(obj);

            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {

                    erros.Add(item.ErrorMessage.ToString());
                }

                success = false;
            }
        }
        private void ValidateUpdate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null) throw new Exception("Parametro nullo");

            if (!tableDb.Any(i => i.Id == obj.Id)) throw new Exception("Registro não encontrado");
            var r = validator.Validate(obj).Errors;
            validator.ValidateAndThrow(obj);
        }
        public object Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
             obj.CriadoEm = DateTime.Now.ToString("yyyyMMddHHmmss");
          
            Validate(obj, Activator.CreateInstance<TValidator>());

            if (success == false) return erros.ToArray();


            _baseRepository.Insert(obj);
            return obj;
        }

        public async  void ExecuteChangeLog(TEntity record, string process) 
        {
            var name = record.GetType().Name;

            Changelog c = new Changelog();
            c.Data = DateTime.Now.ToString("yyyyMMddHHmmss");

            if (process == "update")
            {

                var previousRecord = tableDb.Find(record.Id);
                
                var previousJson = JsonConvert.SerializeObject(previousRecord);

                var currentRecord = JsonConvert.SerializeObject(record);

                
                c.RegistroAnterior = previousJson;
                c.RegistroAtual = currentRecord;
                c.Processo = $"Tabela {name}: Registro Alterado";
                
            }

            if(process == "add")
            {
                var newRecord = JsonConvert.SerializeObject(record);
                c.NovoRegistro = newRecord;
                c.Processo = $"Tabela {name}: Registro Adicionado";
            }

            _context.Changelog.Add(c);

            await _context.SaveChangesAsync();

        }

        public void Delete(Guid id) => _baseRepository.Delete(id);

        public IList<TEntity> Get() => _baseRepository.Select();
        public  TEntity  GetById(Guid id) =>  _baseRepository.Select(id);


        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            ValidateUpdate(obj, Activator.CreateInstance<TValidator>());
             ExecuteChangeLog(obj, "update");
            _baseRepository.Update(obj);
            return obj;
        }
    }
}
