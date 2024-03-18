using Dapper;
using Ecomm_practice01.DataAccess.Repository;
using Ecomm_practice01.DataAccess.Repository.IRepository;
using Ecomm_practice01.Model;
using Ecomm_practice01.utility;
using Microsoft.AspNetCore.Mvc;

namespace Ecomm_practice01.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public CoverTypeController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Credit(int? id)
        {
            CoverType coverType = new CoverType();
            if (id == null) return View(coverType);
            //coverType = _unitofwork.coverType.Get(id.GetValueOrDefault());
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", id.GetValueOrDefault());
            coverType=_unitofwork.SPCalls.OneRecord<CoverType>(SD.Proc_GetCoverType, parameters);
            if (coverType == null) return NotFound();
            return View(coverType);
        }
        [HttpPost]
        public IActionResult Credit(CoverType coverType)
        {
            if (coverType == null) return NotFound();
            if (!ModelState.IsValid) return View(coverType);
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("name",coverType.Name);
            if (coverType.Id == 0)
                //_unitofwork.coverType.Add(coverType);
                _unitofwork.SPCalls.Execute(SD.Proc_CreateCoverType, parameter);
            else
            {  //_unitofwork.coverType.Update(coverType);
                parameter.Add("id", coverType.Id);
                _unitofwork.SPCalls.Execute(SD.Proc_UpdateCoverType, parameter);
            }
            _unitofwork.Save();
            return RedirectToAction("Index");
        }
        #region MyRegion
        [HttpGet]
        public IActionResult GetAll() {
            //return Json(new { data = _unitofwork.coverType.GetAll() });
            return Json(new { data = _unitofwork.SPCalls.List<CoverType>(SD.Proc_GetCoverTypes) });
            
        }
        [HttpDelete]
        public IActionResult Delete(int id) { 
          var covertypefromdb =_unitofwork.coverType.Get(id);
            DynamicParameters param = new DynamicParameters();
            param.Add("id", covertypefromdb.Id);
            if (covertypefromdb == null) 
                return Json(new {success=false,message="Something Went Wrong"});
          else                      
             _unitofwork.SPCalls.Execute(SD.Proc_DeleteCoverType, param);
            //      _unitofwork.coverType.Remove(covertypefromdb);
            //_unitofwork.Save(); 
            return Json(new { success = true, message = "Delted Successfully" });
        }
        #endregion
    }
}
