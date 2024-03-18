using Dapper;
using Ecomm_practice01.DataAccess.Repository.IRepository;
using Ecomm_practice01.Model;
using Ecomm_practice01.utility;
using Microsoft.AspNetCore.Mvc;

namespace Ecomm_practice01.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;
        public CategoryController(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null) return View(category);
            //category = _unitOfwork.category.Get(id.GetValueOrDefault());
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id.GetValueOrDefault());
            category = _unitOfwork.SPCalls.OneRecord<Category>(SD.Proc_GetCategory, param);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Upsert(Category category) { 
          if(category == null) return NotFound();
          if (!ModelState.IsValid) return View(category);
          DynamicParameters parameters= new DynamicParameters();
            parameters.Add("name", category.Name);
            if (category.Id == 0)
            {  //_unitOfwork.category.Add(category);
                _unitOfwork.SPCalls.Execute(SD.Proc_CreateCategory, parameters);
                TempData["message"] = "Added";
            }
            else
            //_unitOfwork.category.Update(category);
            {
                TempData["message"] = "Updated";
                parameters.Add("id", category.Id);
                _unitOfwork.SPCalls.Execute(SD.Proc_UpdateCategory, parameters);
            }
            //string storedProcedure = category.Id == 0 ? SD.Proc_CreateCategory : SD.Proc_UpdateCategory;

            //if (category.Id != 0)
            //    parameters.Add("id", category.Id);
            //TempData["message"] = "Added";
            ////ViewData["Message"] = "0";
            //_unitOfwork.SPCalls.Execute(storedProcedure, parameters);
            _unitOfwork.Save();
            
            return RedirectToAction("Index");
        }

        #region APIs
        [HttpGet]
         public IActionResult GetAll()
         {
            //var categlist = _unitOfwork.category.GetAll();
            //return Json(new { data = categlist });
            return Json(new { data = _unitOfwork.SPCalls.List<Category>(SD.Proc_GetCategories) });
         }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var categindb = _unitOfwork.category.Get(id);
            DynamicParameters param = new DynamicParameters();
            param.Add("id", categindb.Id);
            if (categindb == null)
                return Json(new { success = false, message = "%Some Error Occured%" });
            else
                //_unitOfwork.category.Remove(categindb);
                _unitOfwork.SPCalls.Execute(SD.Proc_DeleteCategory,param);
            _unitOfwork.Save();
            return Json(new { success = true, message = "Deleted SuccessFully!" });
        }
        #endregion
    }
}
