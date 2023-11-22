using PersonelBirim.DAL.Context;
using PersonelBirim.DAL.DataTransferObject.Personel;
using PersonelBirim.DAL.Entity;
using PersonelBirimBusiness.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace PersonelBirimBusiness.Concrete
{
    public class PersonelService : IPersonelService
    {

        private readonly PersonelBirimDbContext _personelBirimDbContext;

        public PersonelService(PersonelBirimDbContext personelBirimDbContext)
        {
            _personelBirimDbContext = personelBirimDbContext;
        }
 

        public GetPersonelDto GetPersonelById(int personelId)
        {
            var personel = _personelBirimDbContext.Personeller.Where(p => ! p.IsDeleted && p.Id == personelId)
                .Select(p => new GetPersonelDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    Mail = p.Mail
                }).FirstOrDefault();

            return personel;
        }

        public List<GetPersonelListDto> GetPersonelList()
        {
            var personel = _personelBirimDbContext.Personeller.Where(p => !p.IsDeleted)
                .Select(p => new GetPersonelListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname
                }).ToList();

            return personel;
        }

        public int AddPersonel(AddPersonelDto personel)
        {
            var newPersonel = new Personel
            {
                Name = personel.Name,
                PhoneNumber = personel.PhoneNumber,
                Mail = personel.Mail
            };

            _personelBirimDbContext.Personeller.Add(newPersonel);


            return _personelBirimDbContext.SaveChanges();
        }

        public int UpdatePersonel(UpdatePersonelDto personelDto)
        {
            var currentPersonel = _personelBirimDbContext.Personeller
                .Where(p => ! p.IsDeleted && p.Id == personelDto.Id)
                .FirstOrDefault();

            if (currentPersonel == null)
            {
                return -1;
            }

            currentPersonel.Name = personelDto.Name;
            currentPersonel.Surname = personelDto.Surname;
            currentPersonel.PhoneNumber = personelDto.PhoneNumber;
            currentPersonel.Mail = personelDto.Mail;

            _personelBirimDbContext.Update(currentPersonel);

            return _personelBirimDbContext.SaveChanges();
        }

        public int DeletPersonel(int personelId)
        {
            var currentPersonel = _personelBirimDbContext.Personeller
                .Where(p => !p.IsDeleted && p.Id == personelId)
                .FirstOrDefault();
            if (currentPersonel == null)
            {
                return -1;
            }

            currentPersonel.IsDeleted = true;
            _personelBirimDbContext.Update(currentPersonel);

            return _personelBirimDbContext.SaveChanges();
        }

        
    }
}
