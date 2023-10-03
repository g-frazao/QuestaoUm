using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestaoUm.Models; 

public class QuestaoUmController : Controller
{
    private readonly DbContext _context;

    public QuestaoUmModel GetQuestaoUmModel()
    {
        return QuestaoUmModel;
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(long id, QuestaoUmModel questaoUmModel)
    {
        var seuModel = await _context.QuestaoUmModel.FindAsync(id);
        if (seuModel == null)
        {
            return NotFound();
        }

        _context.QuestaoUmModel.Remove(questaoUmModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var QuestaoUmModel = await _context.QuestaoUmModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (QuestaoUmModel == null)
        {
            return NotFound();
        }

        return View(QuestaoUmModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var QuestaoUmModel = await _context.QuestaoUmModel.FindAsync(id);
        if (QuestaoUmModel == null)
        {
            return NotFound();
        }

        _context.QuestaoUmModel.Remove(QuestaoUmModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}

