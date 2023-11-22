using PersonelBirim.DAL.DataTransferObject.Birim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBirimBusiness.Abstract
{
    public interface IBirimService
    {
        GetBirimDto GetBirimById(int birimId);

        List<GetBirimListDto> GetBirimList();

        int AddBirim(AddBirimDto birim);

        int UpdateBirim(UpdateBirimDto birim);

        int DeletedBirim(int birimId);
    }
}
