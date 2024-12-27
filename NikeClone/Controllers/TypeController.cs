using Microsoft.AspNetCore.Mvc;
using NikeClone.Application.Interfaces;
using NikeClone.Domain.Entities;
using NikeClone.Infrastructure.Data;

namespace NikeClone.Controllers {
    public class TypeController : Controller {
        private readonly IUnitOfWork _unitOfWork;
        public TypeController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index() {
            var type = _unitOfWork.Types.GetAll();
            return View(type);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Types obj) {
            if (ModelState.IsValid) {
                _unitOfWork.Types.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else {
                return View();
            }
            
        }

        public IActionResult Edit(int id) {
            if(id==0 || id == null) {
                return RedirectToAction(nameof(Index));
            }
            var obj = _unitOfWork.Types.Get(u=>u.Id == id);
            
            if(obj is not null) {
                return View(obj);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Types obj) {
            if (ModelState.IsValid) {
                _unitOfWork.Types.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int id) {
            if (id == 0 || id == null) {
                return RedirectToAction(nameof(Index));
            }
            var obj = _unitOfWork.Types.Get(u=>u.Id == id);
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id) {
            var obj = _unitOfWork.Types.Get(u=>u.Id == id);
            if(obj is not null){
                _unitOfWork.Types.Remove(obj);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
