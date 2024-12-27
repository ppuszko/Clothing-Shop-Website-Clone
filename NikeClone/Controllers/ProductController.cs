using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NikeClone.Application.Interfaces;
using NikeClone.Domain.Entities;
using NikeClone.Domain.ViewModels;
using NikeClone.Infrastructure.Repository;

namespace NikeClone.Controllers {
    public class ProductController : Controller {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index(bool? forMen) {
            IEnumerable<Product> products = _unitOfWork.Products.GetAll(includeProperties: "Type,Category");
            if(forMen is not null)
            {
                products = products.Where(u => u.ForMen == forMen);
            }


            ICollection<ProductVM> productVMs = new List<ProductVM>();

            foreach(var prod in products) {
                productVMs.Add(new() {
                    ProductImageList = _unitOfWork.ProductImages.GetAll(u => u.ProductId == prod.Id).ToList(),
                    Product = prod,
                });
            }
          
            return View(productVMs);
        }

        public IActionResult Create() {
            ProductVM productVM = new() {
                TypesList = _unitOfWork.Types.GetAll().Select(u => new SelectListItem {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })

            };
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductVM obj) {
            if (ModelState.IsValid) {
                _unitOfWork.Products.Add(obj.Product);
                _unitOfWork.Save();

                int counter = 0;
                bool isMain = false;
                bool isSecondary = false;

                foreach (var image in obj.ImageList) {
                    
                    if (counter == 0) { isMain = true; } else { isMain = false; }
                    if(counter == 1) { isSecondary = true; } else { isSecondary = false; }

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @$"Images\{obj.Product.Id}");
                    if (!Directory.Exists(imagePath)) {
                        Directory.CreateDirectory(imagePath);
                    }

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    image.CopyTo(fileStream);

                    ProductImage productImage = new()
                    {

                        ImageUrl = @$"\Images\{obj.Product.Id}\" + fileName,
                        ProductId = obj.Product.Id,
                        IsMain = isMain,
                        IsSecondary = isSecondary

                    };

                    _unitOfWork.ProductImages.Add(productImage);
                    counter++;

                }
                
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id==0 || id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ProductVM objToEdit = new()
            {
                Product = _unitOfWork.Products.Get(u => u.Id == id),
                ProductImageList = _unitOfWork.ProductImages.GetAll(u => u.ProductId == id).ToList(),
                TypesList = _unitOfWork.Types.GetAll().Select(u=> new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            return View(objToEdit);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM objToEdit)
        {
            if (ModelState.IsValid)
            {
                if(objToEdit.Product.PromoPrice != 0)
                {
                    objToEdit.Product.OnSale = true;
                }
                else
                {
                    objToEdit.Product.OnSale = false;
                }

                _unitOfWork.Products.Update(objToEdit.Product);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(objToEdit);
        }

        public IActionResult Delete(int? id) {
            if (id == 0 || id == null) {
                return RedirectToAction(nameof(Index));
            }
            ProductVM objToDelete = new() {
                Product = _unitOfWork.Products.Get(u => u.Id == id),
                TypesList = _unitOfWork.Types.GetAll().Select(u => new SelectListItem {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                ProductImageList = _unitOfWork.ProductImages.GetAll(u => u.ProductId == id).ToList()
            };
            return View(objToDelete);
        }

        [HttpPost]
        public IActionResult Delete(ProductVM productVM) {
            Product? objToDelete = _unitOfWork.Products.Get(u => u.Id == productVM.Product.Id);
            if (objToDelete is not null) {

                if (productVM.ProductImageList is not null && productVM.ProductImageList.Count() > 0) {
                    var directoryPath = Path.Combine(_webHostEnvironment.WebRootPath, @$"Images\{productVM.Product.Id}");
                    if (Directory.Exists(directoryPath)) {
                        Directory.Delete(directoryPath, true);
                    }
                    _unitOfWork.ProductImages.Remove(productVM.ProductImageList);
                }
                
                _unitOfWork.Products.Remove(objToDelete);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }


        public IActionResult ImageError() {
            return View();
        }

        

    }
}



