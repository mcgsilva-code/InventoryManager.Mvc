using Microsoft.AspNetCore.Mvc;
using CrudMVCApp.Models;

using System.Linq;

namespace CrudMVCApp.Controllers
{
    public class ItemController : Controller
    {
        
        private readonly AppDbContext _context;

        public ItemController(AppDbContext context)
        {
            _context = context;
        }

        

        public IActionResult Index()
        {
            return View(_context.Itens.ToList()); // Usa o banco de dados
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);         
                _context.SaveChanges();      
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public IActionResult Edit(int? id) // Aceita ID nulo para segurança
        {
            if (id == null) return NotFound();
            var item = _context.Itens.Find(id); // Busca no banco de dados
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(int id, Item item)
        {
            if (id != item.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(item);       // Atualiza no contexto
                _context.SaveChanges();      
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Delete(int? id) // Aceita ID nulo
        {
            if (id == null) return NotFound();
            var item = _context.Itens.FirstOrDefault(m => m.Id == id); // Busca no DB
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _context.Itens.Find(id); // Busca no DB
            _context.Itens.Remove(item);         // Remove do contexto
            _context.SaveChanges();              
            return RedirectToAction("Index");
        }
    }
}

