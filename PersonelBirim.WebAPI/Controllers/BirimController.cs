using Microsoft.AspNetCore.Mvc;
using PersonelBirim.DAL.DataTransferObject.Birim;
using PersonelBirimBusiness.Abstract;
using System;
using System.Collections.Generic;

namespace PersonelBirim.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirimController : ControllerBase
    {
        private readonly  IBirimService _birimService;

        public BirimController(IBirimService birimService)
        {
            _birimService = birimService;
        }

        [HttpGet("GetBirimList")]
        public ActionResult<List<GetBirimListDto>> GetBirimList()
        {
            try
            {
                var birimList = _birimService.GetBirimList();
                return birimList;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBirimById/{id}")]

        public ActionResult<GetBirimDto> GetBirimById(int id)
        {
            var list = new List<string>();
            try
            {
                var birim = _birimService.GetBirimById(id);
                if (birim == null)
                {
                    list.Add("Birim bulunamadı.");
                    return BadRequest(new { code = StatusCode(1001), message = list, type = "error" });
                }
                return birim;

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddBirim")]
        public ActionResult<string> AddBirim(AddBirimDto birimDto)
        {
            var list = new List<string>();
            try
            {
                var result = _birimService.AddBirim(birimDto);
                if (result > 0)
                {
                    list.Add("Ekleme işlemi başarılı");
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

        [HttpPut("UpdateBirim")]
        public ActionResult<string> UpdateBirim(UpdateBirimDto birimDto)
        {
            var list = new List<string>();
            try
            {
                var result = _birimService.UpdateBirim(birimDto);
                if(result == -1)
                {
                    list.Add("Birim Bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else if(result > 0)
                {
                    list.Add("Güncelleme işlemi başarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "Sucsess" });
                }

                list.Add("Güncelleme başarısız.");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("BirimDelete/{id}")]
        public ActionResult<string> DeleteBirim(int id)
        {
            var list = new List<string>();
            try
            {
                var result = _birimService.DeletedBirim(id);
                if(result == -1)
                {
                    list.Add("Birim bulunamadı");
                    return Ok(new { code = StatusCode(10001), message = list, type = "error" });
                }
                else if(result > 0)
                {
                    list.Add("Silme işlemi başarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }

                list.Add("Silme işlemi başarısız.");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
