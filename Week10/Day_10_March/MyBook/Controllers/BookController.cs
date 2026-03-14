using Microsoft.AspNetCore.Mvc;

public class BookController : Controller{
    private readonly BookDBContext _context;

    public BookController(BookDBContext context){
        _context = context;
    }

    public IActionResult Index(){
        var books = _context.books.ToList();
        return View(books);
    }
    public IActionResult AddBook() {
        return View();
    }
    public IActionResult EditBook(int id)
{
    var book = _context.books.Find(id);

    if (book == null)
    {
        return NotFound();
    }

    return View(book);
}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(BookModel book)
    {
        if (ModelState.IsValid)
        {
            _context.books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(book);
    }
    [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult EditBook(BookModel book)
{
    if (ModelState.IsValid)
    {
        _context.books.Update(book);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(book);
}
public IActionResult DeleteBook(int id)
{
    var book = _context.books.Find(id);

    if (book == null)
    {
        return NotFound();
    }

    _context.books.Remove(book);
    _context.SaveChanges();

    return RedirectToAction("Index");
}
}