#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Contexto _context;

        public ClientesController(Contexto context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }


            var orgaoExpedidor = new List<ItemSelect>();
            orgaoExpedidor.Add(new ItemSelect { Nome = "Secr. do Es" });
            orgaoExpedidor.Add(new ItemSelect { Nome = "DIC" });
            ViewData["orgaoExpedidor"] = new SelectList(orgaoExpedidor, "Nome", "Nome");

            var UF = new List<ItemSelect>();
            UF.Add(new ItemSelect { Nome = "SP" });
            UF.Add(new ItemSelect { Nome = "GO" });
            ViewData["UF"] = new SelectList(UF, "Nome", "Nome");


            var estadoCivil = new List<ItemSelect>();
            estadoCivil.Add(new ItemSelect { Nome = "CASADO(A)" });
            estadoCivil.Add(new ItemSelect { Nome = "SOLTEIRO(A)" });
            estadoCivil.Add(new ItemSelect { Nome = "OUTROS(A)" });
            ViewData["estadoCivil"] = new SelectList(estadoCivil, "Nome", "Nome");

            var sexo = new List<ItemSelect>();
            sexo.Add(new ItemSelect { Nome = "SP" });
            sexo.Add(new ItemSelect { Nome = "GO" });
            ViewData["Sexo"] = new SelectList(sexo, "Nome", "Nome");



            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            var orgaoExpedidor = new List<ItemSelect>();
            orgaoExpedidor.Add(new ItemSelect { Nome = "Secr. do Es" });
            orgaoExpedidor.Add(new ItemSelect { Nome = "DIC" });
            ViewData["orgaoExpedidor"] = new SelectList(orgaoExpedidor, "Nome", "Nome");

            var UF = new List<ItemSelect>();
            UF.Add(new ItemSelect { Nome = "SP" });
            UF.Add(new ItemSelect { Nome = "GO" });
            ViewData["UF"] = new SelectList(UF, "Nome", "Nome");


            var estadoCivil = new List<ItemSelect>();
            estadoCivil.Add(new ItemSelect { Nome = "CASADO(A)" });
            estadoCivil.Add(new ItemSelect { Nome = "SOLTEIRO(A)" });
            estadoCivil.Add(new ItemSelect { Nome = "OUTROS(A)" });
            ViewData["estadoCivil"] = new SelectList(estadoCivil, "Nome", "Nome");

            var sexo = new List<ItemSelect>();
            sexo.Add(new ItemSelect { Nome = "SP" });
            sexo.Add(new ItemSelect { Nome = "GO" });
            ViewData["Sexo"] = new SelectList(sexo, "Nome", "Nome");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CPF,Nome,RG,DataExpedicao,OrgaoExpedicao,UF_Expedicao,DataNascimento,Sexo,EstadoCivil,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,UF")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            var orgaoExpedidor = new List<ItemSelect>();
            orgaoExpedidor.Add(new ItemSelect { Nome = "Secr. do Es" });
            orgaoExpedidor.Add(new ItemSelect { Nome = "DIC" });
            ViewData["orgaoExpedidor"] = new SelectList(orgaoExpedidor, "Nome", "Nome");

            var UF = new List<ItemSelect>();
            UF.Add(new ItemSelect { Nome = "SP" });
            UF.Add(new ItemSelect { Nome = "GO" });
            ViewData["UF"] = new SelectList(UF, "Nome", "Nome");


            var estadoCivil = new List<ItemSelect>();
            estadoCivil.Add(new ItemSelect { Nome = "CASADO(A)" });
            estadoCivil.Add(new ItemSelect { Nome = "SOLTEIRO(A)" });
            estadoCivil.Add(new ItemSelect { Nome = "OUTROS(A)" });
            ViewData["estadoCivil"] = new SelectList(estadoCivil, "Nome", "Nome");

            var sexo = new List<ItemSelect>();
            sexo.Add(new ItemSelect { Nome = "SP" });
            sexo.Add(new ItemSelect { Nome = "GO" });
            ViewData["Sexo"] = new SelectList(sexo, "Nome", "Nome");
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CPF,Nome,RG,DataExpedicao,OrgaoExpedicao,UF_Expedicao,DataNascimento,Sexo,EstadoCivil,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,UF")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}
