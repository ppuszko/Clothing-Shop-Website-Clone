using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NikeClone.Application.Interfaces;
using NikeClone.Domain.Entities;
using NikeClone.Domain.ViewModels;
using NikeClone.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NikeClone.Controllers {
    public class CategoryController : Controller {
        
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController( IUnitOfWork unitOfWork) {
           
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index() {
            var obj = _unitOfWork.Category.GetAll();
            return View(obj);
        }

        public IActionResult Create() {
            CategoryVM categoryVM = new() {
                TypeList = _unitOfWork.Types.GetAll().Select(u => new SelectListItem {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            return View(categoryVM);
        }
        [HttpPost]
        public IActionResult Create(CategoryVM obj) {
            if (ModelState.IsValid) {
                _unitOfWork.Category.Add(obj.Category);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            obj.TypeList = _unitOfWork.Types.GetAll().Select(u => new SelectListItem {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        public IActionResult Edit(int id) {
            if (id==0 || id == null) {
                return RedirectToAction(nameof(Index));
            }
            CategoryVM obj = new() {
                TypeList = _unitOfWork.Types.GetAll().Select(u => new SelectListItem {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Category = _unitOfWork.Category.Get(u => u.Id == id)
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(CategoryVM obj) {
            if (ModelState.IsValid) {
                _unitOfWork.Category.Update(obj.Category);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            obj.TypeList = _unitOfWork.Types.GetAll().Select(u => new SelectListItem {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        public IActionResult Delete(int id) {
            if (id == 0 || id == null) {
                return RedirectToAction(nameof(Index));
            }
            CategoryVM obj = new() {
                TypeList = _unitOfWork.Types.GetAll().Select(u => new SelectListItem {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Category = _unitOfWork.Category.Get(u => u.Id == id)
            };
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id) {
            Category obj = _unitOfWork.Category.Get(u => u.Id == id);
            if(obj is not null) {
                _unitOfWork.Category.Remove(obj);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
    }
}
