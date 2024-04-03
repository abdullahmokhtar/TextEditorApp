using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TextEditorApp.BLL.Interface;
using TextEditorApp.DAL.Entities;

namespace TextEditorApp.PL.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DocumentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //var documentss = await unitOfWork.DocumentRepository.GetAllAsync();
            var documents = unitOfWork.DocumentRepository.GetAllUserDocuments(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(documents);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Document document)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.DocumentRepository.AddAsync(document);
                await unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
                return BadRequest();

            var document = await unitOfWork.DocumentRepository.GetByIdAsync(id);

            if (document is null)
                return NotFound();

            return View(document);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Document document)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.DocumentRepository.Update(document);
                await unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var document = await unitOfWork.DocumentRepository.GetByIdAsync(id);

            if (document is null)
                return NotFound();

            unitOfWork.DocumentRepository.Delete(document);
            await unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
