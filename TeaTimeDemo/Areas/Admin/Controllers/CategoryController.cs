using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDemo.DataAccess.Repository.IRepository;
using TeaTimeDemo.Models;
using TeaTimeDemo.Utility;

namespace TeaTimeDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Manager)]
    public class CategoryController : Controller
    {
        



        //private readonly ICategoryRepository _categoryRepo;

        //public CategoryController(ICategoryRepository db)
        //{
        //    _categoryRepo = db;
        //}

        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult Index()
        {
            //List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "類別名稱不能和顯示順序一致");
            }


            if (ModelState.IsValid)
            {
                //_categoryRepo.Add(obj);
                //_categoryRepo.Save();

                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();

                TempData["success"] = "類別新增成功!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "類別新增失敗!";
            }

            return View();


        }



        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }


        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                //_categoryRepo.Update(obj);
                //_categoryRepo.Save();

                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "類別編輯成功!";
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            //_categoryRepo.Remove(categoryFromDb);
            //_categoryRepo.Save();

            _unitOfWork.Category.Remove(categoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "類別刪除成功!";
            return RedirectToAction("Index");
        }




    }
}
