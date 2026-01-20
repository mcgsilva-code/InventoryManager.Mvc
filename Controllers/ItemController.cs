using Microsoft.AspNetCore.Mvc;
using CrudMVCApp.Models; // Certifique-se de importar a classe Item
using System.Collections.Generic;

namespace CrudMVCApp.Controllers
{
    public class ItemController : Controller
    {
        // Lista de itens em memória
        private static List<Item> _itens = new List<Item>
        {
            new Item { Id = 1, Nome = "Item 1", Descricao = "Descrição do item 1" },
            new Item { Id = 2, Nome = "Item 2", Descricao = "Descrição do item 2" }
        };

        public IActionResult Index()
        {
            return View(_itens); // Passa a lista de itens para a view
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
                item.Id = _itens.Count + 1;
                _itens.Add(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            var item = _itens.Find(i => i.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            var index = _itens.FindIndex(i => i.Id == item.Id);
            if (index >= 0)
            {
                _itens[index] = item;
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            var item = _itens.Find(i => i.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _itens.Find(i => i.Id == id);
            if (item != null)
            {
                _itens.Remove(item);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
