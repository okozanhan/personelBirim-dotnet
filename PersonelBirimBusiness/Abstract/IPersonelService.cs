using PersonelBirim.DAL.DataTransferObject.Personel;
using System.Collections.Generic;

namespace PersonelBirimBusiness.Abstract
{
    public interface IPersonelService
    {
        GetPersonelDto GetPersonelById(int personelId);

        List <GetPersonelListDto> GetPersonelList();

        int AddPersonel(AddPersonelDto personel);

        int UpdatePersonel(UpdatePersonelDto personel);

        int DeletPersonel(int personelId);
    }
}
