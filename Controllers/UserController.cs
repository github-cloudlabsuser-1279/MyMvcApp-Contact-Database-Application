using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

    // GET: User
    public ActionResult Index()
    {
        return View(userlist);
    }        

    // GET: User/Details/5
    public ActionResult Details(int id)
    {
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // GET: User/Search
    public ActionResult Search(string name)
    {
        var users = userlist.Where(u => u.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        return View(users);
    }

    // GET: User/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: User/Create
    [HttpPost]
    public ActionResult Create(User user)
    {
        // Implement the Create method (POST) here
        if (ModelState.IsValid)
        {
            userlist.Add(user);
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    // GET: User/Edit/5
    public ActionResult Edit(int id)
    {
        // This method is responsible for displaying the view to edit an existing user with the specified ID.
        // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // POST: User/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, User updatedUser)
    {
        // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
        // It receives user input from the form submission and updates the corresponding user's information in the userlist.
        // If successful, it redirects to the Index action to display the updated list of users.
        // If no user is found with the provided ID, it returns a HttpNotFoundResult.
        // If an error occurs during the process, it returns the Edit view to display any validation errors.
        if (ModelState.IsValid)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            // Update other fields as necessary

            return RedirectToAction(nameof(Index));
        }
        return View(updatedUser);
    }

    // GET: User/Delete/5
    public ActionResult Delete(int id)
    {
        // Implement the Delete method here
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // POST: User/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        // Implement the Delete method (POST) here
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        userlist.Remove(user);
        return RedirectToAction(nameof(Index));
    }
}
