using PersonelBirim.DAL.Context;
using PersonelBirim.DAL.DataTransferObject.Birim;
using PersonelBirim.DAL.Entity;
using PersonelBirimBusiness.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace PersonelBirimBusiness.Concrete
{
    public class BirimService : IBirimService
    {
        private readonly PersonelBirimDbContext _personelBirimDbContext;

        public BirimService(PersonelBirimDbContext personelBirimDbContext)
        {
            _personelBirimDbContext = personelBirimDbContext;
        }

        public GetBirimDto GetBirimById(int birimId)
        {
            var birim = _personelBirimDbContext.Birimler.Where(p => !p.IsDeleted && p.Id == birimId)
                 .Select(p => new GetBirimDto
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Mail = p.Mail
                 })
                .FirstOrDefault();
            return birim;
        }

        public List<GetBirimListDto> GetBirimList()
        {
            var birim = _personelBirimDbContext.Birimler.Where(p => !p.IsDeleted )
                .Select(p => new GetBirimListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    PhoneNumber = p.PhoneNumber,
                    Mail = p.Mail
                }).ToList();

            return birim;
                
        }

        public int AddBirim(AddBirimDto birim)
        {
            var newbirim = new Birim
            {
                Name = birim.Name,
                PhoneNumber = birim.PhoneNumber,
                Mail = birim.Mail
            };

            _personelBirimDbContext.Birimler.Add(newbirim);


            return _personelBirimDbContext.SaveChanges();
        }

        public int UpdateBirim(UpdateBirimDto birimDto)
        {
            var currentBirim = _personelBirimDbContext.Birimler
                .Where(birim => birim.Id == birimDto.Id).FirstOrDefault();

            if (currentBirim == null)
            {
                return -1;
            }
            currentBirim.Id = birimDto.Id;
            currentBirim.Name = birimDto.Name;
            currentBirim.PhoneNumber = birimDto.PhoneNumber;
            currentBirim.Mail = birimDto.Mail;

            _personelBirimDbContext.Update(currentBirim);
            return _personelBirimDbContext.SaveChanges();
        }

        public int DeletedBirim(int birimId)
        {
            var currentBirim = _personelBirimDbContext.Birimler
                .Where(birim => birim.Id == birimId)
                .FirstOrDefault();
            if (currentBirim == null)
            {
                return -1;
            }

            currentBirim.IsDeleted = true;
            _personelBirimDbContext.Update(currentBirim);
            return _personelBirimDbContext.SaveChanges();
        }

           
    }
}
