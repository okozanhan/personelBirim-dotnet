using Microsoft.AspNetCore.Mvc;
using PersonelBirim.DAL.DataTransferObject.Personel;
using PersonelBirimBusiness.Abstract;
using System;
using System.Collections.Generic;

namespace PersonelBirim.WebAPI.Controllers


{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelService _personelService;

        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        [HttpGet("GetPersonelList")]
        public ActionResult<List<GetPersonelListDto>> GetPersonelList()
        {
            try
            {
                var personelList = _personelService.GetPersonelList();
                return personelList;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetPersonelById/{id}")]
        public ActionResult<GetPersonelDto> GetPersonelById(int id)
        {
            var list = new List<string>();
            try
            {
                var personel = _personelService.GetPersonelById(id);
                if(personel == null)
                {
                    list.Add("Personel bulunamadı.");
                    return BadRequest(new { code = StatusCode(1001), message = list, type = "error" });
                }
                return personel;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddPersonel")]
        public ActionResult<string> AddPersonel(AddPersonelDto personelDto)
        {
            var list = new List<string>();
            try
            {
                var result = _personelService.AddPersonel(personelDto);
                if (result > 0)
                {
                    list.Add("Ekleme işlemi başarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                list.Add("Ekleme işlemi başarısız.");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdatePersonel")]
        public ActionResult<string> UpdatePersonel(UpdatePersonelDto personelDto)
        {
            var list = new List<string>();
            try
            {
                var result = _personelService.UpdatePersonel(personelDto);
                if(result == -1)
                {
                    list.Add("Personel bulunamadı");
                    return Ok(new { code = StatusCode(101), message = list, type = "error" });
                }
                else if(result > 0)
                {
                    list.Add("Güncelleme işlemi başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                list.Add("Güncelleme başarısız.");
                return Ok(new { code = StatusCode(1000), message = list, type = "error" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeletePersonel/{id}")]
        public ActionResult<string> DeletePersonel(int id)
        {
            var list = new List<string>();
            try
            {
                var result = _personelService.DeletPersonel(id);
                if(result == -1)
                {
                    list.Add("Personel bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else if(result > 0)
                {
                    list.Add("Silme işlemi başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                list.Add("Silme işlemi başarısız");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        
    }
}
